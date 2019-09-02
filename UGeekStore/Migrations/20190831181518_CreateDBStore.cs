using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGeekStore.Migrations
{
    public partial class CreateDBStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.UniqueConstraint("AK_Categories_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR(30)", nullable: false),
                    IsDefault = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: false),
                    Salary = table.Column<decimal>(nullable: false, defaultValue: 80000m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                    table.UniqueConstraint("AK_Shippers_Phone_Email", x => new { x.Phone, x.Email });
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    City = table.Column<string>(type: "NVARCHAR(25)", nullable: true),
                    Country = table.Column<string>(type: "NVARCHAR(30)", nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(30)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(40)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATE", nullable: false, defaultValue: new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Local)),
                    Address = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    City = table.Column<string>(type: "NVARCHAR(30)", nullable: true),
                    Country = table.Column<string>(type: "NVARCHAR(30)", nullable: true),
                    PostalCode = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserName_Email", x => new { x.UserName, x.Email });
                    table.ForeignKey(
                        name: "FK_Users_Roles_AccessID",
                        column: x => x.AccessID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(40)", nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    Weight = table.Column<float>(nullable: false, defaultValue: 0f),
                    Description = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    AddDate = table.Column<DateTime>(type: "DATE", nullable: false, defaultValue: new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Local)),
                    Count = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderID = table.Column<int>(nullable: false),
                    ReciverID = table.Column<int>(nullable: false),
                    Mesagge = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 31, 22, 15, 18, 342, DateTimeKind.Local).AddTicks(3362)),
                    ReadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReciverID",
                        column: x => x.ReciverID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderID",
                        column: x => x.SenderID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 31, 22, 15, 18, 335, DateTimeKind.Local).AddTicks(3116)),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    ShipperID = table.Column<int>(nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    PostalCode = table.Column<string>(type: "NVARCHAR(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1),
                    Discount = table.Column<float>(nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.ProductID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReciverID",
                table: "Messages",
                column: "ReciverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperID",
                table: "Orders",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CompanyName",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccessID",
                table: "Users",
                column: "AccessID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstName",
                table: "Users",
                column: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
