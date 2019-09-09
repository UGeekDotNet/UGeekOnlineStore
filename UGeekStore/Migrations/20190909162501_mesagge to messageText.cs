using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGeekStore.Migrations
{
    public partial class mesaggetomessageText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mesagge",
                table: "Messages",
                newName: "MessageText");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 329, DateTimeKind.Local).AddTicks(9311),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 17, 22, 44, 278, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 337, DateTimeKind.Local).AddTicks(5114),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 17, 22, 44, 288, DateTimeKind.Local).AddTicks(2344));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Messages",
                newName: "Mesagge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 17, 22, 44, 278, DateTimeKind.Local).AddTicks(3216),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 329, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 17, 22, 44, 288, DateTimeKind.Local).AddTicks(2344),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 337, DateTimeKind.Local).AddTicks(5114));
        }
    }
}
