using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SalesforceConnectOData.Data;
using SalesforceConnectOData.Models;

namespace SalesforceConnectOData.Controllers;

public class AccountsController : ODataController
{
    private readonly AppDbContext _db;

    public AccountsController(AppDbContext db) => _db = db;

    // GET /odata/Accounts
    [EnableQuery]
    public IQueryable<Account> Get() => _db.Accounts;

    // GET /odata/Accounts(5)
    [EnableQuery]
    public SingleResult<Account> Get([FromRoute] int key) =>
        SingleResult.Create(_db.Accounts.Where(a => a.Id == key));
}
