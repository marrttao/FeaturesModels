﻿namespace WebApplication1.Features.Clients.Models;

using System.ComponentModel.DataAnnotations;
using ClientClass = Client;

public class Address
{
    public Guid Id { get; set; }
    public string Country { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string? Area { get; set; }
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Building { get; set; } = null!;
    public string? Apartment { get; set; }
    public string? Entrance { get; set; }
    public string? Room { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public Guid ClientId { get; set; }
    public ClientClass Client { get; set; } = null!;
}