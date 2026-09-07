using Microsoft.EntityFrameworkCore;

namespace EstimaNow.Infrastructure.DataAccess;

public class EstimaNowDbContext : DbContext
{
    public EstimaNowDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Domain.Entities.CategoryOfService> CategoriesOfServices { get; set; }
    public DbSet<Domain.Entities.Client> Clients { get; set; }
    public DbSet<Domain.Entities.OrderOfService> OrdersOfSerives { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.OrderOfService>()
            .HasOne(o => o.Client)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Domain.Entities.OrderOfService>()
            .HasOne(o => o.CategoryOfService)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CategoryOfServiceId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Domain.Entities.CategoryOfService>().HasData(
            new Domain.Entities.CategoryOfService { Id = 1, Name = "Manutenção", Description = "Serviços de manutenção preventiva e corretiva" },
            new Domain.Entities.CategoryOfService { Id = 2, Name = "Consultoria", Description = "Serviços de consultoria e assessoria" },
            new Domain.Entities.CategoryOfService { Id = 3, Name = "Instalação", Description = "Serviços de instalação de equipamentos e sistemas" },
            new Domain.Entities.CategoryOfService { Id = 4, Name = "Treinamento", Description = "Serviços de treinamento e capacitação" }
        );
    }
}