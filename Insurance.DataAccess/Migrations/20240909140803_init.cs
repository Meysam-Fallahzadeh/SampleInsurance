using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumAmount = table.Column<double>(type: "float", nullable: false),
                    MaximumAmount = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPremium = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCoverageDemand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    InsuranceDemandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCoverageDemand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceCoverageDemand_Coverages_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "Coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceCoverageDemand_Demands_InsuranceDemandId",
                        column: x => x.InsuranceDemandId,
                        principalTable: "Demands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCoverageDemand_CoverageId",
                table: "InsuranceCoverageDemand",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCoverageDemand_InsuranceDemandId",
                table: "InsuranceCoverageDemand",
                column: "InsuranceDemandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceCoverageDemand");

            migrationBuilder.DropTable(
                name: "Coverages");

            migrationBuilder.DropTable(
                name: "Demands");
        }
    }
}
