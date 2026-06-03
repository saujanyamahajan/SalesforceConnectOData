using System.Net.Http.Headers;
using System.Text;

namespace SalesforceConnectOData.Middleware;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _username;
    private readonly string _password;

    public BasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _username = configuration["BasicAuth:Username"]
            ?? throw new InvalidOperationException("BasicAuth:Username is not configured.");
        _password = configuration["BasicAuth:Password"]
            ?? throw new InvalidOperationException("BasicAuth:Password is not configured.");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Allow $metadata requests without auth (SF Connect needs this for discovery)
        if (context.Request.Path.StartsWithSegments("/odata/$metadata"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"SalesforceConnectOData\"";
            await context.Response.WriteAsync("Missing Authorization header.");
            return;
        }

        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]!);
            if (authHeader.Scheme != "Basic" || string.IsNullOrEmpty(authHeader.Parameter))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid authentication scheme. Use Basic.");
                return;
            }

            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);

            if (credentials.Length != 2 ||
                !string.Equals(credentials[0], _username, StringComparison.Ordinal) ||
                !string.Equals(credentials[1], _password, StringComparison.Ordinal))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid Authorization header.");
            return;
        }

        await _next(context);
    }
}
