using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__1788CCAC01FFF667", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityIndex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Home = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK__Delivery__Apartm__2C3393D0",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK__Item__CategoryId__29572725",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    DealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Basket__E5B28166DD84923A", x => x.DealId);
                    table.ForeignKey(
                        name: "FK__Basket__ItemID__2F10007B",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK__Basket__UserID__300424B4",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeliveryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__C3905BAFE9E8EE37", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__OrderItem__ItemI__33D4B598",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK__OrderItem__UserI__32E0915F",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK__Review__ItemId__37A5467C",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK__Review__Photo__36B12243",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Account__5E55825BA519871A",
                table: "Account",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ItemID",
                table: "Basket",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserID",
                table: "Basket",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_UserID",
                table: "Delivery",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemID",
                table: "OrderItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_UserId",
                table: "OrderItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ItemId",
                table: "Review",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                table: "Review",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
