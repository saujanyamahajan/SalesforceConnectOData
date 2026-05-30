using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesforceConnectOData.Models;

[Table("Account")]
public class Account
{
    [Key]
    public string Id { get; set; } = string.Empty;
    public string? IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? BillingStreet { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingState { get; set; }
    public string? BillingPostalCode { get; set; }
    public string? BillingCountry { get; set; }
    public string? Street { get; set; }
    public string? ShippingStreet { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }
    public string? ShippingPostalCode { get; set; }
    public string? ShippingCountry { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? AccountNumber { get; set; }
    public string? Sic { get; set; }
    public string? Industry { get; set; }
    public string? AnnualRevenue { get; set; }
    public string? NumberOfEmployees { get; set; }
    public string? Ownership { get; set; }
    public string? TickerSymbol { get; set; }
    public string? Description { get; set; }
    public string? Rating { get; set; }
    public string? CreatedDate { get; set; }
    public string? CreatedById { get; set; }
    public string? LastModifiedDate { get; set; }
    public string? LastModifiedById { get; set; }
    public string? SystemModstamp { get; set; }
}