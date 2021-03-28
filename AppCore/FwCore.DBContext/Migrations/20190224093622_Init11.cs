using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tenders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tenderProdudcts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TGoodsName = table.Column<string>(nullable: false),
                    TendersTenderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderProdudcts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tenderProdudcts_tenders_TendersTenderID",
                        column: x => x.TendersTenderID,
                        principalTable: "tenders",
                        principalColumn: "TenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tenderProdudcts_TendersTenderID",
                table: "tenderProdudcts",
                column: "TendersTenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenderProdudcts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tenders");
        }
    }
}
