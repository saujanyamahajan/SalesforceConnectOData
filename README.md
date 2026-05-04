# SalesforceConnectOData

A .NET 8 middleware layer that bridges SQL Server and Salesforce Connect.  
Exposes SQL tables as OData 4.0 endpoints, which Salesforce consumes as External Objects — enabling real-time data access without ETL or manual sync.

## Stack
- ASP.NET Core 8 Web API
- Microsoft.AspNetCore.OData
- Entity Framework Core + SQL Server
- Salesforce Connect (OData 4.0)
