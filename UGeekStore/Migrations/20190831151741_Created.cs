using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGeekStore.Migrations
{
    public partial class Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserName_Email",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Suppliers_CompanyName",
                table: "Suppliers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_CategoryName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ShipPostalCode",
                table: "Users",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "ShipAddress",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserName_FirstName_LastName",
                table: "Users",
                newName: "IX_Users_Name_FirstName_LastName");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Rolies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                newName: "IX_Products_Name");

            migrationBuilder.RenameColumn(
                name: "ShipPostalCode",
                table: "Orders",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "ShipCountry",
                table: "Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "ShipCity",
                table: "Orders",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ShipAddress",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Messages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrDate",
                table: "Users",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 664, DateTimeKind.Local).AddTicks(5462),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 640, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Shippers",
                nullable: false,
                defaultValue: 80000m,
                oldClrType: typeof(decimal),
                oldNullable: true,
                oldDefaultValue: 80000m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "Products",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 680, DateTimeKind.Local).AddTicks(3314),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 658, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 690, DateTimeKind.Local).AddTicks(3631),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 666, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 670, DateTimeKind.Local).AddTicks(3007),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 646, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Name_Email",
                table: "Users",
                columns: new[] { "Name", "Email" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Suppliers_Name",
                table: "Suppliers",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Name_Email",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Suppliers_Name",
                table: "Suppliers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Users",
                newName: "ShipPostalCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "ShipAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Name_FirstName_LastName",
                table: "Users",
                newName: "IX_Users_UserName_FirstName_LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Suppliers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rolies",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Name",
                table: "Products",
                newName: "IX_Products_ProductName");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Orders",
                newName: "ShipPostalCode");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Orders",
                newName: "ShipCountry");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Orders",
                newName: "ShipCity");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "ShipAddress");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrDate",
                table: "Users",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 640, DateTimeKind.Local).AddTicks(9980),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 664, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Shippers",
                nullable: true,
                defaultValue: 80000m,
                oldClrType: typeof(decimal),
                oldDefaultValue: 80000m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "Products",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 658, DateTimeKind.Local).AddTicks(6472),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 680, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 666, DateTimeKind.Local).AddTicks(8228),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 690, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 29, 23, 55, 32, 646, DateTimeKind.Local).AddTicks(8776),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2019, 8, 31, 19, 17, 40, 670, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserName_Email",
                table: "Users",
                columns: new[] { "UserName", "Email" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Suppliers_CompanyName",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName");
        }
    }
}
