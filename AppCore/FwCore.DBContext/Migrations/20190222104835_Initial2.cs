using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submits_tenders_TenderID",
                table: "submits");

            migrationBuilder.DropIndex(
                name: "IX_submits_TenderID",
                table: "submits");

            migrationBuilder.AlterColumn<int>(
                name: "TenderID",
                table: "submits",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "submits",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_submits_TenderID",
                table: "submits",
                column: "TenderID",
                unique: true,
                filter: "[TenderID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_submits_tenders_TenderID",
                table: "submits",
                column: "TenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submits_tenders_TenderID",
                table: "submits");

            migrationBuilder.DropIndex(
                name: "IX_submits_TenderID",
                table: "submits");

            migrationBuilder.AlterColumn<int>(
                name: "TenderID",
                table: "submits",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "submits",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_submits_TenderID",
                table: "submits",
                column: "TenderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_submits_tenders_TenderID",
                table: "submits",
                column: "TenderID",
                principalTable: "tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
