



namespace SalesforceConnectOData.Middleware;

public class ApiKeyMiddleware
{
    private const string ApiKeyHeaderName = "X-API-KEY";
    private readonly RequestDelegate _next;
    private readonly string _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration["ApiSettings:ApiKey"]
            ?? throw new InvalidOperationException("ApiSettings:ApiKey is not configured.");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Allow $metadata requests without auth (SF Connect needs this for discovery)
        if (context.Request.Path.StartsWithSegments("/odata/$metadata"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey)
            || !string.Equals(extractedApiKey, _apiKey, StringComparison.Ordinal))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid or missing API key.");
            return;
        }

        await _next(context);
    }
}

