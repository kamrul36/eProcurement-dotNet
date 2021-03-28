using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmitId",
                table: "ProductLists",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Submit",
                columns: table => new
                {
                    SubmitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodsName = table.Column<string>(nullable: false),
                    quentity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TenderID = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submit", x => x.SubmitId);
                    table.ForeignKey(
                        name: "FK_Submit_tenders_TenderID",
                        column: x => x.TenderID,
                        principalTable: "tenders",
                        principalColumn: "TenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLists_SubmitId",
                table: "ProductLists",
                column: "SubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_Submit_TenderID",
                table: "Submit",
                column: "TenderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_Submit_SubmitId",
                table: "ProductLists",
                column: "SubmitId",
                principalTable: "Submit",
                principalColumn: "SubmitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_Submit_SubmitId",
                table: "ProductLists");

            migrationBuilder.DropTable(
                name: "Submit");

            migrationBuilder.DropIndex(
                name: "IX_ProductLists_SubmitId",
                table: "ProductLists");

            migrationBuilder.DropColumn(
                name: "SubmitId",
                table: "ProductLists");
        }
    }
}
