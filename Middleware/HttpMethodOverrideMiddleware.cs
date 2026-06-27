namespace SalesforceConnectOData.Middleware;

/// <summary>
/// Handles two cases Salesforce Connect may use:
/// 1. OPTIONS preflight — respond 200 immediately with allowed verbs (no auth required)
/// 2. POST with X-HTTP-Method-Override header — rewrite to PATCH/PUT/DELETE before routing
/// </summary>
public class HttpMethodOverrideMiddleware
{
    private readonly RequestDelegate _next;

    public HttpMethodOverrideMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Handle OPTIONS preflight — return 200 with allowed methods immediately
        if (context.Request.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.Headers["Allow"] = "GET, POST, PUT, PATCH, DELETE, OPTIONS";
            context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, PATCH, DELETE, OPTIONS";
            context.Response.Headers["Access-Control-Allow-Headers"] = "Authorization, Content-Type, Accept, X-HTTP-Method-Override, X-HTTP-Method, X-Method-Override";
            return;
        }

        // Salesforce Connect may send MERGE as the request verb for partial updates.
        if (context.Request.Method.Equals("MERGE", StringComparison.OrdinalIgnoreCase))
        {
            context.Request.Method = HttpMethods.Patch;
        }

        // Handle X-HTTP-Method-Override — Salesforce may POST with this header instead of PATCH
        if (context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
        {
            var overrideMethod = context.Request.Headers["X-HTTP-Method-Override"].FirstOrDefault()
                ?? context.Request.Headers["X-HTTP-Method"].FirstOrDefault()
                ?? context.Request.Headers["X-Method-Override"].FirstOrDefault();

            if (!string.IsNullOrEmpty(overrideMethod))
            {
                context.Request.Method = overrideMethod.Equals("MERGE", StringComparison.OrdinalIgnoreCase)
                    ? HttpMethods.Patch
                    : overrideMethod.ToUpperInvariant();
            }
            else
            {
                var path = context.Request.Path.Value ?? string.Empty;
                // OData keyed URLs: /Entity('key') or URL-encoded /Entity(%27key%27)
                // Salesforce Connect OData 4.0 sends POST to a keyed URL for updates.
                if (path.Contains("('") || path.Contains("(%27", StringComparison.OrdinalIgnoreCase))
                {
                    context.Request.Method = HttpMethods.Patch;
                }
            }
        }

        await _next(context);
    }
}