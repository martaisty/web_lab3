using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SageBook",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    SagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SageBook", x => new { x.BooksId, x.SagesId });
                    table.ForeignKey(
                        name: "FK_SageBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SageBook_Sages_SagesId",
                        column: x => x.SagesId,
                        principalTable: "Sages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersBooks",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersBooks", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "b31d34e3-7c8d-4ab2-a334-4e4ff24eb604", "ADMIN", "ADMIN" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "4583d9f5-a4fd-4c3c-8b5c-75c53f8da31b", "CUSTOMER", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "c8dfcb77-576f-4b11-99ba-0401df66c8b9", null, false, "Only", "Admin", false, null, null, "ONLY_ADMIN", "AQAAAAEAACcQAAAAEDvvM/SsXngg0VQJlNJWh0GE6mAs3l7AwFLTPNUaeq8UukVlgnYcTbKlBs4Wy048CA==", null, false, "549a3233-19c4-4e71-87bc-90b01c3993f8", false, "OnlyAdmin" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", 0, "bdfd5608-1463-411d-9367-15416f6e757c", null, false, "Admin", null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMCGDdSau4IPy9lDKIhIxr+dKtLyQ7bo7pHAy96PGrZWn12EuUL56nLE68tN6P+mAA==", null, false, "d4604f86-766b-43e6-905b-e8c9297cd404", false, "Admin" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", 0, "81307a06-0d74-4b16-aa32-faeb3d3133f0", null, false, "Makar", "Dziuba", false, null, null, "MAKAR", "AQAAAAEAACcQAAAAEFRlPF4KeaoaLD/K7nGVHs1zUksc/rWdWxuVp228mzII5v2AfA4IRTm4BG9To4o0/g==", null, false, "a2ae2733-0157-46cc-b0dc-a1f42ee5fefe", false, "Makar" },
                    { "29a2593f-acfd-47bf-a8a1-6f040ed740d4", 0, "ff484b2e-9449-4ff3-9096-49dbc87ca517", null, false, "Sofia", "Bender", false, null, null, "SOFIA", "AQAAAAEAACcQAAAAEF3ph9vtxtoxkG+g1YneG+qfMI9D1J2vuyg43KXZjg3I7yx5NeKmiHZyhBbt9bvB1A==", null, false, "c73dde60-6fb6-4f93-9889-f9c3443b9d4d", false, "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Hope springs from the knowledge that there is light even in the darkest of shadows.", "Traitor of wood" },
                    { 2, "Judge your day by the seeds you plant for tomorrow", "Captains And Invaders" },
                    { 3, "Desire is the seed from which all achievements are harvested. The starting point of all achievement is desire. (Napoleon Hill)", "Enemies And Beasts" },
                    { 4, "Be the sunshine on someone's rainy day. Try to be a rainbow in someone's cloud. (Maya Angelou)", "Failure Of The New Age" },
                    { 5, "It's not the words you speak, but the way you say them that matters. People may hear your words, but they feel your attitude. (John C. Maxwell)", "Defenseless Against A Nuclear Winter" },
                    { 6, "All it takes to change your world is to change the way you think. Change your thoughts and you change your world. (Norman Vincent Peale)", "Failure Of Stardust" }
                });

            migrationBuilder.InsertData(
                table: "Sages",
                columns: new[] { "Id", "Age", "City", "Name" },
                values: new object[,]
                {
                    { 1, 26, "Morris", "Louise D. Saunders" },
                    { 2, 45, "Concord", "Brandi J. Rubalcava" },
                    { 3, 30, "San Diego", "Craig V. Bates" },
                    { 4, 22, "Osula", "John J. Friend" }
                });
            
            migrationBuilder.InsertData(
                table: "SageBook",
                columns: new[] { "SagesId", "BooksId" },
                values: new object[,]
                {
                    { 1, 2},
                    { 1, 5},
                    { 2, 1},
                    { 2, 4},
                    { 2, 6},
                    { 3, 1},
                    { 3, 3},
                    { 4, 5},
                    { 4, 6}
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "c7b013f0-5201-4317-abd8-c211f91b7330" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "29a2593f-acfd-47bf-a8a1-6f040ed740d4" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId" },
                values: new object[,]
                {
                    { 1, "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 2, "c7b013f0-5201-4317-abd8-c211f91b7330" },
                    { 3, "c7b013f0-5201-4317-abd8-c211f91b7330" }
                });

            migrationBuilder.InsertData(
                table: "OrdersBooks",
                columns: new[] { "BookId", "OrderId", "Number" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 1, 2 },
                    { 5, 1, 4 },
                    { 1, 2, 10 },
                    { 2, 2, 2 },
                    { 6, 3, 1 },
                    { 1, 3, 5 },
                    { 3, 3, 2 },
                    { 4, 3, 4 },
                    { 5, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersBooks_BookId",
                table: "OrdersBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_SageBook_SagesId",
                table: "SageBook",
                column: "SagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrdersBooks");

            migrationBuilder.DropTable(
                name: "SageBook");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Sages");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
