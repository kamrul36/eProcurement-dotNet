using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_Submit_SubmitId",
                table: "ProductLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Submit_tenders_TenderID",
                table: "Submit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submit",
                table: "Submit");

            migrationBuilder.RenameTable(
                name: "Submit",
                newName: "submits");

            migrationBuilder.RenameIndex(
                name: "IX_Submit_TenderID",
                table: "submits",
                newName: "IX_submits_TenderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_submits",
                table: "submits",
                column: "SubmitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_submits_SubmitId",
                table: "ProductLists",
                column: "SubmitId",
                principalTable: "submits",
                principalColumn: "SubmitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_submits_tenders_TenderID",
                table: "submits",
                column: "TenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_submits_SubmitId",
                table: "ProductLists");

            migrationBuilder.DropForeignKey(
                name: "FK_submits_tenders_TenderID",
                table: "submits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_submits",
                table: "submits");

            migrationBuilder.RenameTable(
                name: "submits",
                newName: "Submit");

            migrationBuilder.RenameIndex(
                name: "IX_submits_TenderID",
                table: "Submit",
                newName: "IX_Submit_TenderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submit",
                table: "Submit",
                column: "SubmitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_Submit_SubmitId",
                table: "ProductLists",
                column: "SubmitId",
                principalTable: "Submit",
                principalColumn: "SubmitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Submit_tenders_TenderID",
                table: "Submit",
                column: "TenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
