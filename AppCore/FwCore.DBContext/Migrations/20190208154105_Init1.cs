using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "tenderCategories",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderCategories", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "tenderTypes",
                columns: table => new
                {
                    ProcurementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcurementType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderTypes", x => x.ProcurementId);
                });

            migrationBuilder.CreateTable(
                name: "tenders",
                columns: table => new
                {
                    TenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentUpdload = table.Column<string>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    AllowReSubmission = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    ContactType = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    BidOpeningDate = table.Column<DateTime>(nullable: false),
                    BidClosingDate = table.Column<DateTime>(nullable: false),
                    StatusID = table.Column<int>(nullable: true),
                    ProcurementId = table.Column<int>(nullable: true),
                    CatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenders", x => x.TenderID);
                    table.ForeignKey(
                        name: "FK_tenders_tenderCategories_CatId",
                        column: x => x.CatId,
                        principalTable: "tenderCategories",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tenders_tenderTypes_ProcurementId",
                        column: x => x.ProcurementId,
                        principalTable: "tenderTypes",
                        principalColumn: "ProcurementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tenders_statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "submissions",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quentity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TenderID = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submissions", x => x.SId);
                    table.ForeignKey(
                        name: "FK_submissions_tenders_TenderID",
                        column: x => x.TenderID,
                        principalTable: "tenders",
                        principalColumn: "TenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLists",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: false),
                    ProductTitle = table.Column<string>(nullable: false),
                    Quentity = table.Column<double>(nullable: false),
                    ProductCategory = table.Column<string>(nullable: false),
                    Discription = table.Column<string>(nullable: false),
                    TenderID = table.Column<int>(nullable: false),
                    SubmissionSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLists", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductLists_submissions_SubmissionSId",
                        column: x => x.SubmissionSId,
                        principalTable: "submissions",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLists_tenders_TenderID",
                        column: x => x.TenderID,
                        principalTable: "tenders",
                        principalColumn: "TenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLists_SubmissionSId",
                table: "ProductLists",
                column: "SubmissionSId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLists_TenderID",
                table: "ProductLists",
                column: "TenderID");

            migrationBuilder.CreateIndex(
                name: "IX_submissions_TenderID",
                table: "submissions",
                column: "TenderID");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_CatId",
                table: "tenders",
                column: "CatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenders_ProcurementId",
                table: "tenders",
                column: "ProcurementId",
                unique: true,
                filter: "[ProcurementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_StatusID",
                table: "tenders",
                column: "StatusID",
                unique: true,
                filter: "[StatusID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLists");

            migrationBuilder.DropTable(
                name: "submissions");

            migrationBuilder.DropTable(
                name: "tenders");

            migrationBuilder.DropTable(
                name: "tenderCategories");

            migrationBuilder.DropTable(
                name: "tenderTypes");

            migrationBuilder.DropTable(
                name: "statuses");
        }
    }
}
