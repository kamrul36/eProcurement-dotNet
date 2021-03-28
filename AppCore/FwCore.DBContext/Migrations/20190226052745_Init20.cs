using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "submitGoods",
                columns: table => new
                {
                    SubmitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenderRefNumber = table.Column<string>(nullable: false),
                    TenderTitle = table.Column<string>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submitGoods", x => x.SubmitId);
                });

            migrationBuilder.CreateTable(
                name: "newGoods",
                columns: table => new
                {
                    GoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodsName = table.Column<string>(nullable: false),
                    quentity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    SubmitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newGoods", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_newGoods_submitGoods_SubmitId",
                        column: x => x.SubmitId,
                        principalTable: "submitGoods",
                        principalColumn: "SubmitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_newGoods_SubmitId",
                table: "newGoods",
                column: "SubmitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newGoods");

            migrationBuilder.DropTable(
                name: "submitGoods");
        }
    }
}
