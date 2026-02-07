using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Tests;

public class ClientTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);   
    }
}