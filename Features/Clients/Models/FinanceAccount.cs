﻿namespace WebApplication1.Features.Clients.Models;

using ClientClass = Client;

public class FinanceAccount
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public ICollection<ClientFinanceAccount> ClientFinanceAccounts { get; set; } = new List<ClientFinanceAccount>();
}