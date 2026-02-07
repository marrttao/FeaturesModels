using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Features.Clients.Models;

public class Client
{
    [Key] //Позначає проперті як первинний ключ
    //Генерація Id за рахунок бази
    [DatabaseGenerated (DatabaseGeneratedOption. Identity)] //(AUTO_INCREMENT, IDENTITY (SERIAL))
    // [DatabaseGenerated (DatabaseGeneratedoption. None)]
    //Відключення автогенерації, ручне встановлення ID через код
    // [DatabaseGenerated (DatabaseGeneratedoption.Computed)] //Значення обчислюється базою (тригер, формула)
    public Guid Id { get; set; }
    
    [Required] //NOT NULL
    [MaxLength(50)]
    [MinLength(1)]
    // [StringLength(50)]
    [Display(Name = "ClientSurname")]
    [DataType(DataType.Text)]
    public string Surname { get; set; } = null!;
    [StringLength(50)]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public string? Patronymic { get; set; } = null;
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    
    public DateOnly BirthDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    
    public ICollection<Phone> Phones { get; set; } = new List<Phone>();
    public Address? Address { get; set; } = null;
    public ICollection<ClientFinanceAccount> ClientFinanceAccounts { get; set; } = new List<ClientFinanceAccount>();
}