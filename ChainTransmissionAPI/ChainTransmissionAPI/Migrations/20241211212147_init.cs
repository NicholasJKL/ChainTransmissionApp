using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChainTransmissionAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    KU = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NU = table.Column<string>(type: "text", nullable: false),
                    TU = table.Column<string>(type: "text", nullable: false),
                    TN = table.Column<string>(type: "text", nullable: false),
                    VU = table.Column<string>(type: "text", nullable: false),
                    N = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.KU);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyUnits",
                columns: table => new
                {
                    KSE = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TSE = table.Column<string>(type: "text", nullable: false),
                    SM = table.Column<string>(type: "text", nullable: false),
                    t = table.Column<double>(type: "double precision", nullable: false),
                    s = table.Column<string>(type: "text", nullable: false),
                    NSE = table.Column<string>(type: "text", nullable: false),
                    UnitKU = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyUnits", x => x.KSE);
                    table.ForeignKey(
                        name: "FK_AssemblyUnits_Units_UnitKU",
                        column: x => x.UnitKU,
                        principalTable: "Units",
                        principalColumn: "KU");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    KD = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ND = table.Column<string>(type: "text", nullable: false),
                    TD = table.Column<string>(type: "text", nullable: false),
                    VD = table.Column<string>(type: "text", nullable: true),
                    NaD = table.Column<string>(type: "text", nullable: true),
                    z = table.Column<int>(type: "integer", nullable: true),
                    AssemblyUnitKSE = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.KD);
                    table.ForeignKey(
                        name: "FK_Parts_AssemblyUnits_AssemblyUnitKSE",
                        column: x => x.AssemblyUnitKSE,
                        principalTable: "AssemblyUnits",
                        principalColumn: "KSE");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyUnits_UnitKU",
                table: "AssemblyUnits",
                column: "UnitKU");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_AssemblyUnitKSE",
                table: "Parts",
                column: "AssemblyUnitKSE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "AssemblyUnits");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
