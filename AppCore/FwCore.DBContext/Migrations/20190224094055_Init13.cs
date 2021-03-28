using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenderProdudcts_tenders_TendersTenderID",
                table: "tenderProdudcts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tenderProdudcts",
                table: "tenderProdudcts");

            migrationBuilder.RenameTable(
                name: "tenderProdudcts",
                newName: "tenderProducts");

            migrationBuilder.RenameIndex(
                name: "IX_tenderProdudcts_TendersTenderID",
                table: "tenderProducts",
                newName: "IX_tenderProducts_TendersTenderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tenderProducts",
                table: "tenderProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tenderProducts_tenders_TendersTenderID",
                table: "tenderProducts",
                column: "TendersTenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenderProducts_tenders_TendersTenderID",
                table: "tenderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tenderProducts",
                table: "tenderProducts");

            migrationBuilder.RenameTable(
                name: "tenderProducts",
                newName: "tenderProdudcts");

            migrationBuilder.RenameIndex(
                name: "IX_tenderProducts_TendersTenderID",
                table: "tenderProdudcts",
                newName: "IX_tenderProdudcts_TendersTenderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tenderProdudcts",
                table: "tenderProdudcts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tenderProdudcts_tenders_TendersTenderID",
                table: "tenderProdudcts",
                column: "TendersTenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
