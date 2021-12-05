﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Abstractions.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hope springs from the knowledge that there is light even in the darkest of shadows.",
                            Name = "Traitor of wood"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Judge your day by the seeds you plant for tomorrow",
                            Name = "Captains And Invaders"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Desire is the seed from which all achievements are harvested. The starting point of all achievement is desire. (Napoleon Hill)",
                            Name = "Enemies And Beasts"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Be the sunshine on someone's rainy day. Try to be a rainbow in someone's cloud. (Maya Angelou)",
                            Name = "Failure Of The New Age"
                        },
                        new
                        {
                            Id = 5,
                            Description = "It's not the words you speak, but the way you say them that matters. People may hear your words, but they feel your attitude. (John C. Maxwell)",
                            Name = "Defenseless Against A Nuclear Winter"
                        },
                        new
                        {
                            Id = 6,
                            Description = "All it takes to change your world is to change the way you think. Change your thoughts and you change your world. (Norman Vincent Peale)",
                            Name = "Failure Of Stardust"
                        });
                });

            modelBuilder.Entity("Abstractions.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = "fab4fac1-c546-41de-aebc-a14da6895711"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = "c7b013f0-5201-4317-abd8-c211f91b7330"
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = "c7b013f0-5201-4317-abd8-c211f91b7330"
                        });
                });

            modelBuilder.Entity("Abstractions.Entities.OrdersBooks", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("OrdersBooks");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            BookId = 1,
                            Number = 1
                        },
                        new
                        {
                            OrderId = 1,
                            BookId = 4,
                            Number = 2
                        },
                        new
                        {
                            OrderId = 1,
                            BookId = 5,
                            Number = 4
                        },
                        new
                        {
                            OrderId = 2,
                            BookId = 1,
                            Number = 10
                        },
                        new
                        {
                            OrderId = 2,
                            BookId = 2,
                            Number = 2
                        },
                        new
                        {
                            OrderId = 3,
                            BookId = 6,
                            Number = 1
                        },
                        new
                        {
                            OrderId = 3,
                            BookId = 1,
                            Number = 5
                        },
                        new
                        {
                            OrderId = 3,
                            BookId = 3,
                            Number = 2
                        },
                        new
                        {
                            OrderId = 3,
                            BookId = 4,
                            Number = 4
                        },
                        new
                        {
                            OrderId = 3,
                            BookId = 5,
                            Number = 3
                        });
                });

            modelBuilder.Entity("Abstractions.Entities.Sage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 26,
                            City = "Morris",
                            Name = "Louise D. Saunders"
                        },
                        new
                        {
                            Id = 2,
                            Age = 45,
                            City = "Concord",
                            Name = "Brandi J. Rubalcava"
                        },
                        new
                        {
                            Id = 3,
                            Age = 30,
                            City = "San Diego",
                            Name = "Craig V. Bates"
                        },
                        new
                        {
                            Id = 4,
                            Age = 22,
                            City = "Osula",
                            Name = "John J. Friend"
                        });
                });

            modelBuilder.Entity("Abstractions.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c8dfcb77-576f-4b11-99ba-0401df66c8b9",
                            EmailConfirmed = false,
                            FirstName = "Only",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedUserName = "ONLY_ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEDvvM/SsXngg0VQJlNJWh0GE6mAs3l7AwFLTPNUaeq8UukVlgnYcTbKlBs4Wy048CA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "549a3233-19c4-4e71-87bc-90b01c3993f8",
                            TwoFactorEnabled = false,
                            UserName = "OnlyAdmin"
                        },
                        new
                        {
                            Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bdfd5608-1463-411d-9367-15416f6e757c",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEMCGDdSau4IPy9lDKIhIxr+dKtLyQ7bo7pHAy96PGrZWn12EuUL56nLE68tN6P+mAA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d4604f86-766b-43e6-905b-e8c9297cd404",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81307a06-0d74-4b16-aa32-faeb3d3133f0",
                            EmailConfirmed = false,
                            FirstName = "Makar",
                            LastName = "Dziuba",
                            LockoutEnabled = false,
                            NormalizedUserName = "MAKAR",
                            PasswordHash = "AQAAAAEAACcQAAAAEFRlPF4KeaoaLD/K7nGVHs1zUksc/rWdWxuVp228mzII5v2AfA4IRTm4BG9To4o0/g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a2ae2733-0157-46cc-b0dc-a1f42ee5fefe",
                            TwoFactorEnabled = false,
                            UserName = "Makar"
                        },
                        new
                        {
                            Id = "29a2593f-acfd-47bf-a8a1-6f040ed740d4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff484b2e-9449-4ff3-9096-49dbc87ca517",
                            EmailConfirmed = false,
                            FirstName = "Sofia",
                            LastName = "Bender",
                            LockoutEnabled = false,
                            NormalizedUserName = "SOFIA",
                            PasswordHash = "AQAAAAEAACcQAAAAEF3ph9vtxtoxkG+g1YneG+qfMI9D1J2vuyg43KXZjg3I7yx5NeKmiHZyhBbt9bvB1A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c73dde60-6fb6-4f93-9889-f9c3443b9d4d",
                            TwoFactorEnabled = false,
                            UserName = "Sofia"
                        });
                });

            modelBuilder.Entity("BookSage", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("SagesId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "SagesId");

                    b.HasIndex("SagesId");

                    b.ToTable("SageBook");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "b31d34e3-7c8d-4ab2-a334-4e4ff24eb604",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            ConcurrencyStamp = "4583d9f5-a4fd-4c3c-8b5c-75c53f8da31b",
                            Name = "CUSTOMER",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "fab4fac1-c546-41de-aebc-a14da6895711",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "fab4fac1-c546-41de-aebc-a14da6895711",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        },
                        new
                        {
                            UserId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        },
                        new
                        {
                            UserId = "29a2593f-acfd-47bf-a8a1-6f040ed740d4",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Abstractions.Entities.Order", b =>
                {
                    b.HasOne("Abstractions.Entities.User", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Abstractions.Entities.OrdersBooks", b =>
                {
                    b.HasOne("Abstractions.Entities.Book", "Book")
                        .WithMany("OrdersDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abstractions.Entities.Order", "Order")
                        .WithMany("OrdersDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookSage", b =>
                {
                    b.HasOne("Abstractions.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abstractions.Entities.Sage", null)
                        .WithMany()
                        .HasForeignKey("SagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Abstractions.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Abstractions.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abstractions.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Abstractions.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Abstractions.Entities.Book", b =>
                {
                    b.Navigation("OrdersDetails");
                });

            modelBuilder.Entity("Abstractions.Entities.Order", b =>
                {
                    b.Navigation("OrdersDetails");
                });

            modelBuilder.Entity("Abstractions.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
