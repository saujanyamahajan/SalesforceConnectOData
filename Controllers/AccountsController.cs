using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SalesforceConnectOData.Data;
using SalesforceConnectOData.Models;

namespace SalesforceConnectOData.Controllers;
// <summary>
/// OData controller for Account entity — provides full CRUD operations.
/// Salesforce Connect calls these endpoints to read/write External Object records.
///
/// Flow: Salesforce UI → Salesforce Connect (External Data Source) → this OData API → SQL Server DB
///
/// Endpoints:
///   GET    /odata/Accounts            — List all accounts (supports $filter, $select, $orderby, $top, $skip)
///   GET    /odata/Accounts('key')     — Get a single account by Id
///   POST   /odata/Accounts            — Create a new account
///   PATCH  /odata/Accounts('key')     — Partial update
///   PUT    /odata/Accounts('key')     — Full replace / upsert
///   DELETE /odata/Accounts('key')     — Delete an account record
/// </summary>