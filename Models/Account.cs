using System.ComponentModel.DataAnnotations;

namespace SalesforceConnectOData.Models;

public class Account
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; }
}

