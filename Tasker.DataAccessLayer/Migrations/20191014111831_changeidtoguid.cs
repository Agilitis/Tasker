using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasker.DataAccessLayer.Migrations
{
    public partial class changeidtoguid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Deadline", "Description", "Priority", "State", "Title" },
                values: new object[] { -1, new DateTime(2019, 10, 14, 13, 18, 31, 272, DateTimeKind.Local).AddTicks(1889), "Test description", 1, 1, "Test title" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Deadline", "Description", "Priority", "State", "Title" },
                values: new object[] { -2, new DateTime(2019, 10, 14, 13, 18, 31, 274, DateTimeKind.Local).AddTicks(7079), "Lorem ipsum", 2, 1, "Test blabla" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Deadline", "Description", "Priority", "State", "Title" },
                values: new object[] { -3, new DateTime(2019, 10, 14, 13, 18, 31, 274, DateTimeKind.Local).AddTicks(7118), "Sit dolor am alet nem tudom hogy van", 3, 1, "Test 123" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Deadline", "Description", "Priority", "State", "Title" },
                values: new object[] { -4, new DateTime(2019, 10, 14, 13, 18, 31, 274, DateTimeKind.Local).AddTicks(7122), "Test description", 4, 1, "Test aefawf" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Deadline", "Description", "Priority", "State", "Title" },
                values: new object[] { -5, new DateTime(2019, 10, 14, 13, 18, 31, 274, DateTimeKind.Local).AddTicks(7125), "Test description", 5, 1, "Test w1rawer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
