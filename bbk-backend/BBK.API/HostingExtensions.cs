using BBK.API.Data;
using BBK.API.Filters;
using BBK.API.Services.Recipes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

namespace BBK.API;

/// <summary>
/// Extension methods for configuring the application.
/// </summary>
public static class HostingExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddConfiguration(GetConfiguration()).Build();
    }

    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetRequiredValue("ConnectionString"));
        });
    }

    public static void AddAuth(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = builder.Configuration.GetRequiredValue("Identity:Url");
            options.Audience = builder.Configuration.GetRequiredValue("Identity:Audience");
        });

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("Administration", policy => policy.RequireClaim("permissions", "administration"));
    }

    public static void AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRecipeService, RecipeService>();
    }

    public static void AddOpenApi(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        var openApi = configuration.GetRequiredSection("OpenApi");

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            var document = openApi.GetRequiredSection("Document");
            var version = document.GetRequiredValue("Version");

            options.SwaggerDoc(version, new OpenApiInfo
            {
                Title = document.GetRequiredValue("Title"),
                Version = version,
                Description = document.GetValue<string>("Description")
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            var identitySection = configuration.GetSection("Identity");
            var scopesSection = identitySection.GetSection("Scopes");
            Dictionary<string, string?> scopes = [];

            if (identitySection.Exists() && scopesSection.Exists())
            {
                scopes = scopesSection.GetChildren().ToDictionary(p => p.Key, p => p.Value);

                var identityUrl = identitySection.GetRequiredValue("Url");

                options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{identityUrl}/authorize"),
                            TokenUrl = new Uri($"{identityUrl}/oauth/token"),
                            RefreshUrl = new Uri($"{identityUrl}/oauth/token"),
                            Scopes = scopes,
                        }
                    }
                });
            }

            options.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT auth",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<AuthorizeCheckOperationFilter>([scopes.Keys.ToArray()]);
        });
    }

    public static void UseOpenApi(this WebApplication app)
    {
        var configuration = app.Configuration;
        var openApiSection = configuration.GetRequiredSection("OpenApi");

        app.UseSwagger(options =>
        {
            options.RouteTemplate = "swagger/{documentName}/swagger.json";
        });
        app.UseSwaggerUI(options =>
        {
            var documentSection = openApiSection.GetRequiredSection("Document");
            var version = documentSection.GetRequiredValue("Version");
            var endpoint = $"{version}/swagger.json";

            options.SwaggerEndpoint(endpoint, documentSection["Title"]);

            var scopesSection = configuration.GetSection("Identity:Scopes");
            if (scopesSection.Exists())
            {
                var scopes = scopesSection.GetChildren().Select(scope => scope.Key).ToArray();
                options.OAuthScopes(scopes);
            }

            var clientSection = configuration.GetSection("Identity:Client");
            if (clientSection.Exists())
            {
                options.OAuthClientId(clientSection.GetRequiredValue("Id"));
                options.OAuthClientSecret(clientSection.GetRequiredValue("Secret"));
                options.OAuthAdditionalQueryStringParams(new Dictionary<string, string>
                {
                    ["audience"] = configuration.GetRequiredValue("Identity:Audience")
                });
            }

            options.OAuthUsePkce();
        });

        // Add a redirect from the root of the app to the swagger endpoint
        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
    }

    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();

        context.Database.Migrate();
    }

    private static IConfigurationRoot GetConfiguration()
    {
        var builder=  new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        return builder.Build();
    }

    private static string GetRequiredValue(this IConfiguration configuration, string name) =>
        configuration[name] ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");
}
