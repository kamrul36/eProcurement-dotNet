using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsId",
                table: "submits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodsName = table.Column<string>(nullable: false),
                    quentity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    SubmitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_Goods_submits_SubmitId",
                        column: x => x.SubmitId,
                        principalTable: "submits",
                        principalColumn: "SubmitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_SubmitId",
                table: "Goods",
                column: "SubmitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "submits");
        }
    }
}
