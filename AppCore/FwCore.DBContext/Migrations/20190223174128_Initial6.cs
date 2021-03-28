using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_submits_SubmitId",
                table: "Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

            migrationBuilder.RenameTable(
                name: "Goods",
                newName: "goods");

            migrationBuilder.RenameIndex(
                name: "IX_Goods_SubmitId",
                table: "goods",
                newName: "IX_goods_SubmitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_goods",
                table: "goods",
                column: "GoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_goods_submits_SubmitId",
                table: "goods",
                column: "SubmitId",
                principalTable: "submits",
                principalColumn: "SubmitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goods_submits_SubmitId",
                table: "goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_goods",
                table: "goods");

            migrationBuilder.RenameTable(
                name: "goods",
                newName: "Goods");

            migrationBuilder.RenameIndex(
                name: "IX_goods_SubmitId",
                table: "Goods",
                newName: "IX_Goods_SubmitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "GoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_submits_SubmitId",
                table: "Goods",
                column: "SubmitId",
                principalTable: "submits",
                principalColumn: "SubmitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
