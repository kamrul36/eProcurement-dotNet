using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "tenders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tenders",
                nullable: true);
        }
    }
}
