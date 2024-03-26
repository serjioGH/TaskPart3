﻿// <auto-generated />
using System;
using Cloth.Persistence.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cloth.Persistence.PostgreSQL.Migrations
{
    [DbContext(typeof(ClothInventoryDbContext))]
    partial class ClothInventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cloth.Domain.Entities.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Baskets", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111110-1111-1111-1111-111111111133"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("11111110-1111-1111-1111-111111111122")
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.BasketLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClothId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ClothId");

                    b.HasIndex("SizeId");

                    b.ToTable("BasketLines", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111110-1111-1111-1111-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chanel"
                        },
                        new
                        {
                            Id = new Guid("22222220-2222-2222-2222-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nike"
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Cloth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Cloths", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.ClothGroup", b =>
                {
                    b.Property<Guid>("ClothId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.HasKey("ClothId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("ClothGroups", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.ClothSize", b =>
                {
                    b.Property<Guid>("ClothId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uuid");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("integer");

                    b.HasKey("ClothId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ClothSizes", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("88888880-8888-8888-8888-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Men"
                        },
                        new
                        {
                            Id = new Guid("99999990-9999-9999-9999-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Women"
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.OrderLines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClothId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SizeId");

                    b.ToTable("OrderLines", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66666660-6666-6666-6666-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Processing"
                        },
                        new
                        {
                            Id = new Guid("66666661-6666-6666-6666-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Shipped"
                        },
                        new
                        {
                            Id = new Guid("77777770-7777-7777-7777-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Completed"
                        },
                        new
                        {
                            Id = new Guid("77777771-7777-7777-7777-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111110-1111-1111-1111-111111111144"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Sizes", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33333330-3333-3333-3333-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Small"
                        },
                        new
                        {
                            Id = new Guid("44444440-4444-4444-4444-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("55555550-5555-5555-5555-111111111111"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeactivated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("TokenExpiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111110-1111-1111-1111-111111111122"),
                            Address = "Address example",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "s.r.a@example.com",
                            FirstName = "Serdzhan",
                            IsDeactivated = false,
                            LastName = "Ahmedov",
                            Password = "password",
                            Phone = "1234567890",
                            TokenExpiration = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "Serj"
                        });
                });

            modelBuilder.Entity("Cloth.Domain.Entities.UserRoles", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "public");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Basket", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.User", "User")
                        .WithOne("Basket")
                        .HasForeignKey("Cloth.Domain.Entities.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.BasketLine", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Basket", "Basket")
                        .WithMany("BasketLines")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.Cloth", "Cloth")
                        .WithMany("BasketLines")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.Size", "Size")
                        .WithMany("BasketLines")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Cloth");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Cloth", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Brand", "Brand")
                        .WithMany("Cloths")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.ClothGroup", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Cloth", "Cloth")
                        .WithMany("ClothGroups")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.Group", "Group")
                        .WithMany("ClothGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.ClothSize", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Cloth", "Cloth")
                        .WithMany("ClothSizes")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.Size", "Size")
                        .WithMany("ClothSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Order", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.OrderLines", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Cloth", "Cloth")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.Size", "Size")
                        .WithMany("OrderLines")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");

                    b.Navigation("Order");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Payment", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Cloth.Domain.Entities.Payment", "PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.UserRoles", b =>
                {
                    b.HasOne("Cloth.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cloth.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Basket", b =>
                {
                    b.Navigation("BasketLines");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Cloths");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Cloth", b =>
                {
                    b.Navigation("BasketLines");

                    b.Navigation("ClothGroups");

                    b.Navigation("ClothSizes");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Group", b =>
                {
                    b.Navigation("ClothGroups");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderLines");

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("Cloth.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.Size", b =>
                {
                    b.Navigation("BasketLines");

                    b.Navigation("ClothSizes");

                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("Cloth.Domain.Entities.User", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
