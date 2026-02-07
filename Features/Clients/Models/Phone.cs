using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Features.Clients.Models;

using ClientClass = Client;

public class Phone
{
    public Guid Id { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Column(TypeName = "varchar(50)")]
    public string Number { get; set; } = null!;
    public CountryCode CountryCode { get; set; } = CountryCode.UA;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    
    public Guid ClientId { get; set; }
    public ClientClass Client { get; set; } = null!;
}

public enum CountryCode
{
    UA = 380,
    US = 1,
    GB = 44,
    DE = 49,
    FR = 33
}