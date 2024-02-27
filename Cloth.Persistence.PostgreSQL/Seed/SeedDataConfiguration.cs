namespace Cloth.Persistence.Ef.Seed;

using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class SeedDataConfiguration :
    IEntityTypeConfiguration<Brand>,
    IEntityTypeConfiguration<Size>,
    IEntityTypeConfiguration<OrderStatus>,
    IEntityTypeConfiguration<User>,
    IEntityTypeConfiguration<Basket>,
    IEntityTypeConfiguration<Role>,
    IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        //Seed Brands
        builder.HasData(
            new Brand { Id = Guid.Parse("11111110-1111-1111-1111-111111111111"), Name = "Chanel" },
            new Brand { Id = Guid.Parse("22222220-2222-2222-2222-111111111111"), Name = "Nike" }
        );
    }

    public void Configure(EntityTypeBuilder<Size> builder)
    {
        //Seed Sizes
        builder.HasData(
            new Size { Id = Guid.Parse("33333330-3333-3333-3333-111111111111"), Name = Domain.Enumarations.ClothSize.Small },
            new Size { Id = Guid.Parse("44444440-4444-4444-4444-111111111111"), Name = Domain.Enumarations.ClothSize.Medium },
            new Size { Id = Guid.Parse("55555550-5555-5555-5555-111111111111"), Name = Domain.Enumarations.ClothSize.Large }
        );
    }

    public void Configure(EntityTypeBuilder<Group> builder)
    {
        //Seed Groups
        builder.HasData(
            new Group { Id = Guid.Parse("88888880-8888-8888-8888-111111111111"), Name = "Men" },
            new Group { Id = Guid.Parse("99999990-9999-9999-9999-111111111111"), Name = "Women" }
        );
    }

    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        //Seed OrderStatus
        builder.HasData(
            new OrderStatus { Id = Guid.Parse("66666660-6666-6666-6666-111111111111"), Name = Domain.Enumarations.OrderStatus.Processing },
            new OrderStatus { Id = Guid.Parse("66666661-6666-6666-6666-111111111111"), Name = Domain.Enumarations.OrderStatus.Shipped },
            new OrderStatus { Id = Guid.Parse("77777770-7777-7777-7777-111111111111"), Name = Domain.Enumarations.OrderStatus.Completed },
            new OrderStatus { Id = Guid.Parse("77777771-7777-7777-7777-111111111111"), Name = Domain.Enumarations.OrderStatus.Cancelled }
        );
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
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
    }

    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasData(
             new Basket
             {
                 Id = Guid.Parse("11111110-1111-1111-1111-111111111133"),
                 UserId = Guid.Parse("11111110-1111-1111-1111-111111111122"),
             }
        );
    }

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        //Seed Roles
        var roles = new[]
        {
            new Role { Id = Guid.Parse("11111110-1111-1111-1111-111111111144"), Name = "admin" }
        };

        builder.HasData(roles);
    }

    public void Configure(EntityTypeBuilder<UserRoles> builder)
    {
        //Seed UserRoles
        var userRole = new UserRoles
        {
            UserId = Guid.Parse("11111110-1111-1111-1111-111111111122"),
            RoleId = Guid.Parse("11111110-1111-1111-1111-111111111144")
        };

        builder.HasData(userRole);
    }
}