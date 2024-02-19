namespace Cloth.Persistence.Ef.Context;

using Cloth.Domain.Entities;
using Cloth.Domain.Enumarations;
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
    public DbSet<Domain.Entities.OrderStatus> OrderStatus { get; set; }
    public DbSet<Domain.Entities.Payment> Payments { get; set; }
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
        //seed
        //Seed Brands
        builder.Entity<Brand>().HasData(
            new Brand { Id = Guid.Parse("11111110-1111-1111-1111-111111111111"), Name = "Chanel" },
            new Brand { Id = Guid.Parse("22222220-2222-2222-2222-111111111111"), Name = "Nike" }
        );

        //Seed Sizes
        builder.Entity<Size>().HasData(
            new Size { Id = Guid.Parse("33333330-3333-3333-3333-111111111111"), Name = Domain.Enumarations.ClothSize.Small },
            new Size { Id = Guid.Parse("44444440-4444-4444-4444-111111111111"), Name = Domain.Enumarations.ClothSize.Medium },
            new Size { Id = Guid.Parse("55555550-5555-5555-5555-111111111111"), Name = Domain.Enumarations.ClothSize.Large }
        );

        //Seed Groups
        builder.Entity<Group>().HasData(
            new Group { Id = Guid.Parse("88888880-8888-8888-8888-111111111111"), Name = "Men" },
            new Group { Id = Guid.Parse("99999990-9999-9999-9999-111111111111"), Name = "Women" }
        );

        //Seed OrderStatus
        builder.Entity<Domain.Entities.OrderStatus>().HasData(
            new Domain.Entities.OrderStatus { Id = Guid.Parse("66666660-6666-6666-6666-111111111111"), Name = Domain.Enumarations.OrderStatus.Processing },
            new Domain.Entities.OrderStatus { Id = Guid.Parse("66666661-6666-6666-6666-111111111111"), Name = Domain.Enumarations.OrderStatus.Shipped },
            new Domain.Entities.OrderStatus { Id = Guid.Parse("77777770-7777-7777-7777-111111111111"), Name = Domain.Enumarations.OrderStatus.Received },
            new Domain.Entities.OrderStatus { Id = Guid.Parse("77777771-7777-7777-7777-111111111111"), Name = Domain.Enumarations.OrderStatus.Canceled }
        );

        builder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("11111110-1111-1111-1111-111111111122"),
                FirstName = "Serdzhan",
                LastName = "Ahmedov",
                Email = "s.r.a@example.com",
                Password = "password",
                Phone = "1234567890",
                Address = "Address example",
                Orders = new List<Order>()
            }
        );

        builder.Entity<Basket>().HasData(
             new Basket
             {
                 Id = Guid.Parse("11111110-1111-1111-1111-111111111133"),
                 UserId = Guid.Parse("11111110-1111-1111-1111-111111111122"),
             }
        );

        //Seed Roles
        var roles = new[]
        {
            new Role { Id = Guid.Parse("11111110-1111-1111-1111-111111111144"), Name = "admin" }
        };

        builder.Entity<Role>().HasData(roles);

        //Seed UserRoles
        var userRole = new UserRoles
        {
            UserId = Guid.Parse("11111110-1111-1111-1111-111111111122"),
            RoleId = Guid.Parse("11111110-1111-1111-1111-111111111144")
        };

        builder.Entity<UserRoles>().HasData(userRole);
        base.OnModelCreating(builder);
    }
}