using Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataSeeder
{
    public static class DataSeeder
    {
        public static void Initialize(this ModelBuilder modelBuilder)
        {
            CreateRoles(modelBuilder);
            CreateUsers(modelBuilder);
            AssignUserRoles(modelBuilder);

            CreateBooks(modelBuilder);
            CreateSages(modelBuilder);
            CreateOrders(modelBuilder);
            CreateOrderDetails(modelBuilder);
        }

        private static void CreateRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    {Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "ADMIN", NormalizedName = "ADMIN"},
                new IdentityRole
                    {Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", Name = "CUSTOMER", NormalizedName = "CUSTOMER"}
            );
        }

        private static void CreateUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                    UserName = "OnlyAdmin",
                    NormalizedUserName = "ONLY_ADMIN",
                    FirstName = "Only",
                    LastName = "Admin",
                    LockoutEnabled = false,
                    PasswordHash = hasher.HashPassword(null, "OnlyAdmin")
                },
                new User
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "Admin",
                    LockoutEnabled = false,
                    PasswordHash = hasher.HashPassword(null, "Admin")
                },
                new User
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserName = "Makar",
                    NormalizedUserName = "MAKAR",
                    FirstName = "Makar",
                    LastName = "Dziuba",
                    LockoutEnabled = false,
                    PasswordHash = hasher.HashPassword(null, "Makar123")
                },
                new User
                {
                    Id = "29a2593f-acfd-47bf-a8a1-6f040ed740d4",
                    UserName = "Sofia",
                    NormalizedUserName = "SOFIA",
                    FirstName = "Sofia",
                    LastName = "Bender",
                    LockoutEnabled = false,
                    PasswordHash = hasher.HashPassword(null, "Sofia123")
                }
            );
        }

        private static void AssignUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                // OnlyAdmin - ADMIN
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                },
                // Admin - ADMIN, CUSTOMER
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "fab4fac1-c546-41de-aebc-a14da6895711"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserId = "fab4fac1-c546-41de-aebc-a14da6895711"
                },
                // Makar - CUSTOMER
                new IdentityUserRole<string>
                {
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserId = "c7b013f0-5201-4317-abd8-c211f91b7330"
                },
                // Sofia - CUSTOMER
                new IdentityUserRole<string>
                {
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserId = "29a2593f-acfd-47bf-a8a1-6f040ed740d4"
                }
            );
        }

        private static void CreateBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Traitor of wood",
                    Description = "Hope springs from the knowledge that there is light even in the darkest of shadows."
                },
                new Book
                {
                    Id = 2,
                    Name = "Captains And Invaders",
                    Description = "Judge your day by the seeds you plant for tomorrow"
                },
                new Book
                {
                    Id = 3,
                    Name = "Enemies And Beasts",
                    Description =
                        "Desire is the seed from which all achievements are harvested. The starting point of all achievement is desire. (Napoleon Hill)"
                },
                new Book
                {
                    Id = 4,
                    Name = "Failure Of The New Age",
                    Description =
                        "Be the sunshine on someone's rainy day. Try to be a rainbow in someone's cloud. (Maya Angelou)"
                },
                new Book
                {
                    Id = 5,
                    Name = "Defenseless Against A Nuclear Winter",
                    Description =
                        "It's not the words you speak, but the way you say them that matters. People may hear your words, but they feel your attitude. (John C. Maxwell)"
                },
                new Book
                {
                    Id = 6,
                    Name = "Failure Of Stardust",
                    Description =
                        "All it takes to change your world is to change the way you think. Change your thoughts and you change your world. (Norman Vincent Peale)"
                }
            );
        }

        private static void CreateSages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sage>().HasData(
                new Sage
                {
                    Id = 1,
                    Name = "Louise D. Saunders",
                    Age = 26,
                    City = "Morris"
                },
                new Sage
                {
                    Id = 2,
                    Name = "Brandi J. Rubalcava",
                    Age = 45,
                    City = "Concord"
                },
                new Sage
                {
                    Id = 3,
                    Name = "Craig V. Bates",
                    Age = 30,
                    City = "San Diego"
                },
                new Sage
                {
                    Id = 4,
                    Name = "John J. Friend",
                    Age = 22,
                    City = "Osula",
                }
            );
        }

        private static void CreateOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                // Admin
                new Order {Id = 1, CustomerId = "fab4fac1-c546-41de-aebc-a14da6895711"},
                // Makar
                new Order {Id = 2, CustomerId = "c7b013f0-5201-4317-abd8-c211f91b7330"},
                new Order {Id = 3, CustomerId = "c7b013f0-5201-4317-abd8-c211f91b7330"}
            );
        }

        private static void CreateOrderDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersBooks>().HasData(
                // 1
                new OrdersBooks {OrderId = 1, BookId = 1, Number = 1},
                new OrdersBooks {OrderId = 1, BookId = 4, Number = 2},
                new OrdersBooks {OrderId = 1, BookId = 5, Number = 4},
                // 2
                new OrdersBooks {OrderId = 2, BookId = 1, Number = 10},
                new OrdersBooks {OrderId = 2, BookId = 2, Number = 2},
                // 3
                new OrdersBooks {OrderId = 3, BookId = 6, Number = 1},
                new OrdersBooks {OrderId = 3, BookId = 1, Number = 5},
                new OrdersBooks {OrderId = 3, BookId = 3, Number = 2},
                new OrdersBooks {OrderId = 3, BookId = 4, Number = 4},
                new OrdersBooks {OrderId = 3, BookId = 5, Number = 3}
            );
        }
    }
}