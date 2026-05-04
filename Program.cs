using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using SalesforceConnectOData.Data;
using SalesforceConnectOData.Middleware;
using SalesforceConnectOData.Models;

var builder = WebApplication.CreateBuilder(args);

// EF Core → SQL Server
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Build OData EDM model
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<Account>("Accounts");

// Register OData
builder.Services.AddControllers()
    .AddOData(opts =>
        opts.Select().Filter().OrderBy().Expand().Count().SetMaxTop(1000)
            .AddRouteComponents("odata", odataBuilder.GetEdmModel()));

var app = builder.Build();
app.UseMiddleware<ApiKeyMiddleware>();
app.MapControllers();
app.Run();

