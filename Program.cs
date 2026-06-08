using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using SalesforceConnectOData.Data;
using SalesforceConnectOData.Middleware;
using SalesforceConnectOData.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var odataBuilder = new ODataConventionModelBuilder();


// Configure Assets - full CRUD as well

builder.Services.AddControllers()
    .AddOData(opts =>
        opts.Select()
            .Filter()
            .OrderBy()
            .Expand()
            .Count()
            .SetMaxTop(5000)
            .AddRouteComponents("odata", odataBuilder.GetEdmModel()));

var app = builder.Build();
app.UseMiddleware<HttpMethodOverrideMiddleware>(); // OPTIONS preflight + X-HTTP-Method-Override (must be before auth)
app.UseMiddleware<BasicAuthMiddleware>();
app.MapControllers();
app.Run();

