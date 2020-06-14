using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Country", "Name", "Points" },
                values: new object[] { 1, 35, 0, "Kaloyan", 378 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Country", "Name", "Points" },
                values: new object[] { 2, 37, 3, "Stefan", 1127 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Country", "Name", "Points" },
                values: new object[] { 3, 42, 2, "Peter", 3587 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
