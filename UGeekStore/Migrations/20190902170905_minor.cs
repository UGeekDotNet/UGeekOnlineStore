using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGeekStore.Migrations
{
    public partial class minor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserName_Email",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Shippers_Phone_Email",
                table: "Shippers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldDefaultValue: new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "Products",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldDefaultValue: new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 2, 21, 9, 5, 46, DateTimeKind.Local).AddTicks(4329),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 8, 31, 22, 15, 18, 335, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 2, 21, 9, 5, 55, DateTimeKind.Local).AddTicks(6395),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 8, 31, 22, 15, 18, 342, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserName",
                table: "Users",
                column: "UserName");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Shippers_Email",
                table: "Shippers",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Shippers_Phone",
                table: "Shippers",
                column: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserName",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Shippers_Email",
                table: "Shippers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Shippers_Phone",
                table: "Shippers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldDefaultValue: new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "Products",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldDefaultValue: new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 22, 15, 18, 335, DateTimeKind.Local).AddTicks(3116),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 2, 21, 9, 5, 46, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(2019, 8, 31, 22, 15, 18, 342, DateTimeKind.Local).AddTicks(3362),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 2, 21, 9, 5, 55, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserName_Email",
                table: "Users",
                columns: new[] { "UserName", "Email" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Shippers_Phone_Email",
                table: "Shippers",
                columns: new[] { "Phone", "Email" });
        }
    }
}
