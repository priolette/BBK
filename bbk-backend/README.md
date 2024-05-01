# Back-end local setup

**Requirements:**
- Git 
- .NET 8 SDK
- Visual Studio or JetBrains Rider
- [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) CLI tool (*optional*)
- Docker Desktop

**Steps**
1. Clone the repository
2. Open the .sln file in Visual Studio or Rider
3. In the solution explorer, right click on the docker-compose project and select "Set as Startup Project"
4. If the project contains any database migrations: using the PowerShell from the project directory (containing BKK.API.csproj) run the following command: `dotnet ef database update`
5. If you're creating the first migration, run the following in PowerShell: `dotnet ef migrations add Initial -o ./Data/Migrations`. The `-o` flag is not needed for subsequent migrations.