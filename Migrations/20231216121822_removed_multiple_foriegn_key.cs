using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bar_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class removed_multiple_foriegn_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubUnitInvoce");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubUnitInvoce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Empty = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    NotRecived = table.Column<int>(type: "int", nullable: false),
                    Qnt = table.Column<int>(type: "int", nullable: false),
                    TotalPurchasePrice = table.Column<double>(type: "float", nullable: false),
                    TotalSellPrice = table.Column<double>(type: "float", nullable: false),
                    VAT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubUnitInvoce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubUnitInvoce_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SubUnitInvoce_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubUnitInvoce_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubUnitInvoce_BranchId",
                table: "SubUnitInvoce",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubUnitInvoce_InvoiceId",
                table: "SubUnitInvoce",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubUnitInvoce_ProductID",
                table: "SubUnitInvoce",
                column: "ProductID");
        }
    }
}
