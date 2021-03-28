using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "goods");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "submits",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "submits");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "goods",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
