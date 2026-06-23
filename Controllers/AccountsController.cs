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
/// 
public class AccountsController : ODataController
{
       private readonly AppDbContext _db;

    public AccountsController(AppDbContext db) => _db = db;

    // ─── READ ────────────────────────────────────────────────────────────────────
  // GET /odata/Accounts
    [EnableQuery]
    public IQueryable<Account> Get() => _db.Accounts;

    // GET /odata/Accounts('key')
    [EnableQuery]
    public SingleResult<Account> Get([FromRoute] string key) =>
        SingleResult.Create(_db.Accounts.Where(a => a.Id == key));
 // ─── CREATE ──────────────────────────────────────────────────────────────────

    // POST /odata/Accounts
    public async Task<IActionResult> Post([FromBody] Account account)
    {
        if (string.IsNullOrEmpty(account.Id))
            account.Id = Guid.NewGuid().ToString();

        var now = DateTime.UtcNow.ToString("o");
        account.CreatedDate       ??= now;
        account.LastModifiedDate  ??= now;
        account.SystemModstamp    ??= now;
        account.CreatedById       ??= "system";
        account.LastModifiedById  ??= "system";

        _db.Accounts.Add(account);
        await _db.SaveChangesAsync();
        return Created(account);
    }

    // ─── UPDATE (PARTIAL) ────────────────────────────────────────────────────────

    // PATCH /odata/Accounts('key')
    public async Task<IActionResult> Patch([FromRoute] string key, [FromBody] Delta<Account> delta)
    {
        var entity = await _db.Accounts.FindAsync(key);
        if (entity == null)
            return NotFound();

        delta.Patch(entity);
        await _db.SaveChangesAsync();
        return Updated(entity);
    }
 // ─── UPDATE (FULL REPLACE / UPSERT) ──────────────────────────────────────────

    // PUT /odata/Accounts('key')
    public async Task<IActionResult> Put([FromRoute] string key, [FromBody] Account account)
    {
        var entity = await _db.Accounts.FindAsync(key);
        if (entity == null)
        {
            account.Id = key;
            _db.Accounts.Add(account);
            await _db.SaveChangesAsync();
            return Created(account);
        }

        entity.IsDeleted       = account.IsDeleted;
        entity.Name            = account.Name;
        entity.Type            = account.Type;
        entity.BillingStreet   = account.BillingStreet;
        entity.BillingCity     = account.BillingCity;
        entity.BillingState    = account.BillingState;
        entity.BillingPostalCode = account.BillingPostalCode;
        entity.BillingCountry  = account.BillingCountry;
        entity.Street          = account.Street;
        entity.ShippingStreet  = account.ShippingStreet;
        entity.ShippingCity    = account.ShippingCity;
        entity.ShippingState   = account.ShippingState;
        entity.ShippingPostalCode = account.ShippingPostalCode;
        entity.ShippingCountry = account.ShippingCountry;
        entity.Phone           = account.Phone;
        entity.Fax             = account.Fax;
        entity.AccountNumber   = account.AccountNumber;
        entity.Sic             = account.Sic;
        entity.Industry        = account.Industry;
        entity.AnnualRevenue   = account.AnnualRevenue;
        entity.NumberOfEmployees = account.NumberOfEmployees;
        entity.Ownership       = account.Ownership;
        entity.TickerSymbol    = account.TickerSymbol;
        entity.Description     = account.Description;
        entity.Rating            = account.Rating;
        entity.LastModifiedDate  = DateTime.UtcNow.ToString("o");
        entity.LastModifiedById  = account.LastModifiedById ?? "system";
        entity.SystemModstamp    = DateTime.UtcNow.ToString("o");

        await _db.SaveChangesAsync();
        return Updated(entity);
    }


}
