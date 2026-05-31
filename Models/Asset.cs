using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesforceConnectOData.Models;

[Table("Asset")]
public class Asset
{
    [Key]
    public string Id { get; set; } = string.Empty;
    public string? AccountId { get; set; }
    public string? RootAssetId { get; set; } 
    public string? Product2Id { get; set; }
    public string? ProductDescription { get; set; }
    public string? IsCompetitorProduct { get; set; }
    public string? CreatedDate { get; set; }
    public string? CreatedById { get; set; }
    public string? LastModifiedDate { get; set; }
    public string? LastModifiedById { get; set; }
    public string? SystemModstamp { get; set; }
    public string? IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public string? Price { get; set; }
}
