using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeInventario.Migrations
{
    public partial class BuyDateOnBuysEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellDate",
                table: "Buys",
                newName: "BuyDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuyDate",
                table: "Buys",
                newName: "SellDate");
        }
    }
}
