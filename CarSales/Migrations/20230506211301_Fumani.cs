using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSales.Migrations
{
    public partial class Fumani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CusId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");
        }
    }
}
