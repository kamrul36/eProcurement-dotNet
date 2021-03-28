using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsName",
                table: "submits");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "submits");

            migrationBuilder.DropColumn(
                name: "quentity",
                table: "submits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoodsName",
                table: "submits",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "submits",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "quentity",
                table: "submits",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
