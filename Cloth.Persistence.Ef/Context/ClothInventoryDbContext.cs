namespace Cloth.Persistence.Ef.Context;

using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class ClothInventoryDbContext : DbContext
{
    public DbSet<Cloth> Cloths { get; set; }
    public DbSet<Domain.Entities.ClothSize> ClothSizes { get; set; }
    public DbSet<ClothGroup> ClothGroups { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLines> OrderLines { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketLine> BasketLines { get; set; }

    public ClothInventoryDbContext(DbContextOptions<ClothInventoryDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.Database.Migrate();

        base.OnModelCreating(builder);
    }
}