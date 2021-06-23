﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompareProduct", b =>
                {
                    b.Property<int>("ComparesId")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComparesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("CompareProduct");
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.Property<int>("FavoritesId")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoritesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("FavoritesProduct");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserContactId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserContactId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Compare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Compares");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.NoGegisterUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CartLifeTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("NoGegisterUsers");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InfoStatus")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a153b13e-d35d-4ba2-8c90-30dc25900b9a"),
                            Cost = 81295m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation u",
                            Image = "/img/Products/5.jpg",
                            Name = "Пелёнка"
                        },
                        new
                        {
                            Id = new Guid("468c1867-7a43-464d-a65b-83de90b9bfb1"),
                            Cost = 47521m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut e",
                            Image = "/img/Products/6.jpg",
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("9b5d6d1a-7ed2-4fac-8145-7439acfd4e9a"),
                            Cost = 51764m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occ",
                            Image = "/img/Products/2.jpg",
                            Name = "Соска"
                        },
                        new
                        {
                            Id = new Guid("39386be6-48a0-4414-bd45-d2c36f54ec1c"),
                            Cost = 61570m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nu",
                            Image = "/img/Products/6.jpg",
                            Name = "Памперсы"
                        },
                        new
                        {
                            Id = new Guid("1ac50387-f968-42a9-b9a9-202374a6fd5c"),
                            Cost = 12177m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in volup",
                            Image = "/img/Products/6.jpg",
                            Name = "Распашонка"
                        },
                        new
                        {
                            Id = new Guid("f8eecce2-53e4-4cae-8654-fdc1d5a60b92"),
                            Cost = 69151m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exerc",
                            Image = "/img/Products/2.jpg",
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("90949e50-358b-4a79-a85c-b4321b3e6a81"),
                            Cost = 91729m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cil",
                            Image = "/img/Products/4.jpg",
                            Name = "Трусы"
                        },
                        new
                        {
                            Id = new Guid("59224cf6-6213-4542-951b-c1e539c68551"),
                            Cost = 31702m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut e",
                            Image = "/img/Products/5.jpg",
                            Name = "Распашонка"
                        },
                        new
                        {
                            Id = new Guid("eac5756b-1328-4c53-8bcb-39861ff0b2f8"),
                            Cost = 92184m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et do",
                            Image = "/img/Products/5.jpg",
                            Name = "Журнал"
                        },
                        new
                        {
                            Id = new Guid("13c536af-8e63-42ae-9e6b-5d4a6df6bcbe"),
                            Cost = 42655m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi u",
                            Image = "/img/Products/5.jpg",
                            Name = "Крем"
                        },
                        new
                        {
                            Id = new Guid("715c67ae-03d0-47ad-9d94-2b45eef6e380"),
                            Cost = 47635m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupid",
                            Image = "/img/Products/6.jpg",
                            Name = "Мишка"
                        },
                        new
                        {
                            Id = new Guid("61e62c52-080c-4c24-9651-033cd8ce2aca"),
                            Cost = 21687m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor ",
                            Image = "/img/Products/6.jpg",
                            Name = "Памперсы"
                        },
                        new
                        {
                            Id = new Guid("7addfed6-1353-4f1d-aeb2-26f495bc0853"),
                            Cost = 59253m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et",
                            Image = "/img/Products/5.jpg",
                            Name = "Чашка"
                        },
                        new
                        {
                            Id = new Guid("a2730322-7633-449b-bd03-ba9000e20955"),
                            Cost = 41010m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad ",
                            Image = "/img/Products/6.jpg",
                            Name = "Распашонка"
                        },
                        new
                        {
                            Id = new Guid("01666a00-aacb-471b-b471-f7726f64d1c0"),
                            Cost = 7824m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscin",
                            Image = "/img/Products/4.jpg",
                            Name = "Вилка"
                        },
                        new
                        {
                            Id = new Guid("31e345ed-caed-4350-81c2-91e94cdc9207"),
                            Cost = 61448m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis ",
                            Image = "/img/Products/2.jpg",
                            Name = "Мячик"
                        },
                        new
                        {
                            Id = new Guid("fb770e3f-23a7-48a2-8ec6-4ce4f357e854"),
                            Cost = 99802m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud",
                            Image = "/img/Products/2.jpg",
                            Name = "Ползунки"
                        },
                        new
                        {
                            Id = new Guid("26c081c9-b4c7-434c-9b12-0794eb3f255e"),
                            Cost = 97437m,
                            Description = "Lorem ipsum dolor sit amet, consectetu",
                            Image = "/img/Products/1.jpg",
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("92d22e64-5f33-4812-9b3c-b32ae27a5982"),
                            Cost = 80144m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt moll",
                            Image = "/img/Products/6.jpg",
                            Name = "Трусы"
                        },
                        new
                        {
                            Id = new Guid("ef8e6484-a2fa-4170-ac65-3760ec21bea6"),
                            Cost = 47896m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed ",
                            Image = "/img/Products/3.jpg",
                            Name = "Журнал"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("CompareProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Compare", null)
                        .WithMany()
                        .HasForeignKey("ComparesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Favorites", null)
                        .WithMany()
                        .HasForeignKey("FavoritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.HasOne("OnlineShop.Db.Models.UserContact", "UserContact")
                        .WithMany()
                        .HasForeignKey("UserContactId");

                    b.Navigation("Cart");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("UserContact");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.NoGegisterUser", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserContact", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Order", "Order")
                        .WithOne("UserContacts")
                        .HasForeignKey("OnlineShop.Db.Models.UserContact", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("UserContacts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
