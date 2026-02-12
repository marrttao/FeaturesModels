namespace WebApplication1.Features.Clients.ViewModels;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Features.Clients.Models;
public class ClientViewModel
{
  
    [Required] //NOT NULL
    [StringLength(50)]
    public string Surname { get; set; } = null!;
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [StringLength(50)]
    public string? Patronymic { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }

}