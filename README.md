# SalesforceConnectOData

A .NET 8 middleware layer that bridges SQL Server and Salesforce Connect.  
Exposes SQL tables as OData 4.0 endpoints, which Salesforce consumes as External Objects — enabling real-time data access without ETL or manual sync.

## Stack
- ASP.NET Core 8 Web API
- Microsoft.AspNetCore.OData
- Entity Framework Core + SQL Server
- Salesforce Connect (OData 4.0)


## Overview
This service acts as a .NET OData layer between an on-premise/local SQL Server 
database and Salesforce Connect. Rather than duplicating data into Salesforce, 
Salesforce reads it live from SQL via the OData 4.0 protocol.

## How It Works
1. SQL Server holds the source data
2. This .NET API exposes it as OData-compliant endpoints
3. Salesforce Connect is configured to point at this API
4. Salesforce surfaces the data as External Objects (read or read/write)

## Use Case
Ideal for orgs that want Salesforce visibility into SQL data  
without migrating or duplicating records.
