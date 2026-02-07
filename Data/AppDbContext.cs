namespace WebApplication1.Data;

using WebApplication1.Features.Clients.Models;
using WebApplication1.Features.Users.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; private set; }
    public DbSet<Phone> Phones { get; private set; }
    public DbSet<Address> Addresses { get; private set; }
    public DbSet<FinanceAccount> FinanceAccounts { get; private set; }
    public DbSet<ClientFinanceAccount> ClientFinanceAccounts { get; private set; }

    public DbSet<User> Users { get; private set; }
    public DbSet<Status> Statuses { get; private set; }
    public DbSet<Role> Roles { get; private set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .HasIndex(client => client.Email)
            .IsUnique();

        // Client - Phones (One-to-Many)
        modelBuilder.Entity<Phone>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Phones)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Client - Address (One-to-One)
        modelBuilder.Entity<Client>()
            .HasOne(c => c.Address)
            .WithOne(a => a.Client)
            .HasForeignKey<Address>(a => a.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Address column types and nullability
        modelBuilder.Entity<Address>(b =>
        {
            b.Property(a => a.Country).HasColumnType("varchar(100)").IsRequired();
            b.Property(a => a.Region).HasColumnType("varchar(100)").IsRequired();
            b.Property(a => a.Area).HasColumnType("varchar(100)").IsRequired(false);
            b.Property(a => a.City).HasColumnType("varchar(100)").IsRequired();
            b.Property(a => a.Street).HasColumnType("varchar(150)").IsRequired();
            b.Property(a => a.Building).HasColumnType("varchar(20)").IsRequired();
            b.Property(a => a.Apartment).HasColumnType("varchar(20)").IsRequired(false);
            b.Property(a => a.Entrance).HasColumnType("varchar(10)").IsRequired(false);
            b.Property(a => a.Room).HasColumnType("varchar(20)").IsRequired(false);

            b.Property(a => a.CreatedAt).HasColumnType("timestamp with time zone");
            b.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
        });

        // Client - FinanceAccount many-to-many via ClientFinanceAccount
        modelBuilder.Entity<ClientFinanceAccount>(b =>
        {
            b.HasKey(cfa => new { cfa.ClientId, cfa.FinanceAccountId });

            b.HasOne(cfa => cfa.Client)
                .WithMany(c => c.ClientFinanceAccounts)
                .HasForeignKey(cfa => cfa.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(cfa => cfa.FinanceAccount)
                .WithMany(fa => fa.ClientFinanceAccounts)
                .HasForeignKey(cfa => cfa.FinanceAccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // FinanceAccount timestamps
        modelBuilder.Entity<FinanceAccount>(b =>
        {
            b.Property(f => f.Balance).HasColumnType("numeric");
            b.Property(f => f.CreatedAt).HasColumnType("timestamp with time zone");
            b.Property(f => f.UpdatedAt).HasColumnType("timestamp with time zone");
        });

        // Phone timestamps
        modelBuilder.Entity<Phone>(b =>
        {
            b.Property(p => p.Number).HasColumnType("varchar(50)");
            b.Property(p => p.CreatedAt).HasColumnType("timestamp with time zone");
            b.Property(p => p.UpdatedAt).HasColumnType("timestamp with time zone");
        });

        // Users, Status, Role configuration
        modelBuilder.Entity<User>(b =>
        {
            b.Property(u => u.Login).HasColumnType("varchar(50)").IsRequired();
            b.Property(u => u.Password).HasColumnType("varchar(255)").IsRequired();
            b.Property(u => u.Email).HasColumnType("varchar(100)").IsRequired();
            b.Property(u => u.CreatedAt).HasColumnType("timestamp with time zone");
            b.Property(u => u.UpdatedAt).HasColumnType("timestamp with time zone");

            b.HasOne(u => u.Status)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Status>(b =>
        {
            b.Property(s => s.Name).HasColumnType("varchar(50)").IsRequired();
        });

        modelBuilder.Entity<Role>(b =>
        {
            b.Property(r => r.Name).HasColumnType("varchar(50)").IsRequired();
        });
    }
}