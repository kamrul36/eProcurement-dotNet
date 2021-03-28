using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PTotalCost",
                table: "tenders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "submitGoods",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PTotalCost",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "submitGoods");
        }
    }
}
