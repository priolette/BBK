"use client";

export default function Error({
  error,
  reset,
}: {
  error: Error & { digest?: string };
  reset: () => void;
}) {
  return (
    <div className="flex h-full flex-col items-center justify-center">
      <h1 className="text-4xl font-bold text-red-500">Error</h1>
      <p className="text-lg text-gray-600">{error.message}</p>
      <button
        onClick={reset}
        className="mt-4 rounded-md bg-red-500 px-4 py-2 text-white"
      >
        Try again
      </button>
    </div>
  );
}
