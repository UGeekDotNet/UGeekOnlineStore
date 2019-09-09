using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGeekStore.Migrations
{
    public partial class fixmessagedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 21, 52, 54, 956, DateTimeKind.Local).AddTicks(5935),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 329, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 21, 52, 54, 963, DateTimeKind.Local).AddTicks(7614),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 337, DateTimeKind.Local).AddTicks(5114));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 329, DateTimeKind.Local).AddTicks(9311),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 21, 52, 54, 956, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 9, 20, 25, 1, 337, DateTimeKind.Local).AddTicks(5114),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 9, 21, 52, 54, 963, DateTimeKind.Local).AddTicks(7614));
        }
    }
}
