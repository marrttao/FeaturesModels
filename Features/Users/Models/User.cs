namespace WebApplication1.Features.Users.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    public Guid Id { get; set; }

    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    // Foreign keys
    public Guid? StatusId { get; set; }
    public Status? Status { get; set; }

    public Guid? RoleId { get; set; }
    public Role? Role { get; set; }
}
