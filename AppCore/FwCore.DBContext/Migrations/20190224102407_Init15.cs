using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenderProducts_tenders_TendersTenderID",
                table: "tenderProducts");

            migrationBuilder.RenameColumn(
                name: "TendersTenderID",
                table: "tenderProducts",
                newName: "TenderID");

            migrationBuilder.RenameIndex(
                name: "IX_tenderProducts_TendersTenderID",
                table: "tenderProducts",
                newName: "IX_tenderProducts_TenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_tenderProducts_tenders_TenderID",
                table: "tenderProducts",
                column: "TenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenderProducts_tenders_TenderID",
                table: "tenderProducts");

            migrationBuilder.RenameColumn(
                name: "TenderID",
                table: "tenderProducts",
                newName: "TendersTenderID");

            migrationBuilder.RenameIndex(
                name: "IX_tenderProducts_TenderID",
                table: "tenderProducts",
                newName: "IX_tenderProducts_TendersTenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_tenderProducts_tenders_TendersTenderID",
                table: "tenderProducts",
                column: "TendersTenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
