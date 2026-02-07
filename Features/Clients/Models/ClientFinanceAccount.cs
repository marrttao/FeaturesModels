namespace WebApplication1.Features.Clients.Models;

using ClientClass = Client;

public class ClientFinanceAccount
{
    public Guid ClientId { get; set; }
    public ClientClass Client { get; set; } = null!;

    public Guid FinanceAccountId { get; set; }
    public FinanceAccount FinanceAccount { get; set; } = null!;
}