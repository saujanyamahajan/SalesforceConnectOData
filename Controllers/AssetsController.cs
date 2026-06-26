using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SalesforceConnectOData.Data;
using SalesforceConnectOData.Models;

namespace SalesforceConnectOData.Controllers;

/// <summary>
/// OData controller for Asset entity — provides full CRUD operations.
/// Salesforce Connect calls these endpoints to read/write External Object records.
/// 
/// Flow: Salesforce UI → Salesforce Connect (External Data Source) → this OData API → SQL Server DB
/// 
/// Endpoints:
///   GET    /odata/Assets            — List all assets (supports $filter, $select, $orderby, $top, $skip)
///   GET    /odata/Assets('key')     — Get a single asset by Id
///   POST   /odata/Assets            — Create a new asset (SF sends this on External Object record creation)
///   PATCH  /odata/Assets('key')     — Partial update (SF sends this on field edits)
///   PUT    /odata/Assets('key')     — Full replace / upsert
///   DELETE /odata/Assets('key')     — Delete an asset record
/// </summary>
/// 
public class AssetsController : ODataController
{
    private readonly AppDbContext _db;

    public AssetsController(AppDbContext db) => _db = db;

    // ─── READ ────────────────────────────────────────────────────────────────────

    // GET /odata/Assets
    // Returns all assets. Supports OData query options ($filter, $select, $orderby, $top, $skip, $count).
    [EnableQuery]
    public IQueryable<Asset> Get() => _db.Assets;

    // GET /odata/Assets('key')
    // Returns a single asset by its primary key (Id).
    [EnableQuery]
    public SingleResult<Asset> Get([FromRoute] string key) =>
        SingleResult.Create(_db.Assets.Where(a => a.Id == key));

    // ─── CREATE ──────────────────────────────────────────────────────────────────

    // POST /odata/Assets
    // Creates a new Asset record in the database.
    // If Salesforce doesn't supply an Id, a GUID is generated server-side.
    // Returns HTTP 201 Created with the new entity in the response body.
    public async Task<IActionResult> Post([FromBody] Asset asset)
    {
        if (string.IsNullOrEmpty(asset.Id))
            asset.Id = Guid.NewGuid().ToString();

        var now = DateTime.UtcNow.ToString("o");

        // Default date fields to current UTC timestamp if not provided
        if (string.IsNullOrEmpty(asset.CreatedDate))
            asset.CreatedDate = now;
        if (string.IsNullOrEmpty(asset.LastModifiedDate))
            asset.LastModifiedDate = now;
        if (string.IsNullOrEmpty(asset.SystemModstamp))
            asset.SystemModstamp = now;

        // Default ById fields to "system" if not provided
        if (string.IsNullOrEmpty(asset.CreatedById))
            asset.CreatedById = "system";
        if (string.IsNullOrEmpty(asset.LastModifiedById))
            asset.LastModifiedById = "system";

        _db.Assets.Add(asset);
        await _db.SaveChangesAsync();
        return Created(asset);
    }

    // ─── UPDATE (PARTIAL) ────────────────────────────────────────────────────────

    // PATCH /odata/Assets('key')
    // Applies a partial update using OData Delta<T>.
    // Only the fields included in the request body are updated; others remain unchanged.
    // This is the method Salesforce Connect uses when a user edits fields on an External Object.
    // Returns HTTP 204 No Content on success, or 404 if the record doesn't exist.
    public async Task<IActionResult> Patch([FromRoute] string key, [FromBody] Delta<Asset> delta)
    {
        var entity = await _db.Assets.FindAsync(key);
        if (entity == null)
            return NotFound();

        delta.Patch(entity);
        await _db.SaveChangesAsync();
        return Updated(entity);
    }

    // ─── UPDATE (FULL REPLACE / UPSERT) ──────────────────────────────────────────

    // PUT /odata/Assets('key')
    // Replaces all fields of an existing asset, or creates it if it doesn't exist (upsert).
    // Returns HTTP 204 on update, or HTTP 201 on creation.
    public async Task<IActionResult> Put([FromRoute] string key, [FromBody] Asset asset)
    {
        var entity = await _db.Assets.FindAsync(key);
        if (entity == null)
        {
            // Record doesn't exist — create it with the given key
            asset.Id = key;
            _db.Assets.Add(asset);
            await _db.SaveChangesAsync();
            return Created(asset);
        }

        // Record exists — overwrite all fields
        entity.AccountId = asset.AccountId;
        entity.RootAssetId = asset.RootAssetId;
        entity.Product2Id = asset.Product2Id;
        entity.ProductDescription = asset.ProductDescription;
        entity.IsCompetitorProduct = asset.IsCompetitorProduct;
        entity.CreatedDate = asset.CreatedDate;
        entity.CreatedById = asset.CreatedById;
        entity.LastModifiedDate = asset.LastModifiedDate;
        entity.LastModifiedById = asset.LastModifiedById;
        entity.SystemModstamp = asset.SystemModstamp;
        entity.IsDeleted = asset.IsDeleted;
        entity.Name = asset.Name;
        entity.Status = asset.Status;
        entity.Price = asset.Price;

        await _db.SaveChangesAsync();
        return Updated(entity);
    }

    // ─── DELETE ──────────────────────────────────────────────────────────────────

    // DELETE /odata/Assets('key')
    // Permanently removes the asset record from the database.
    // Returns HTTP 204 No Content on success, or 404 if the record doesn't exist.
    public async Task<IActionResult> Delete([FromRoute] string key)
    {
        var entity = await _db.Assets.FindAsync(key);
        if (entity == null)
            return NotFound();

        _db.Assets.Remove(entity);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
