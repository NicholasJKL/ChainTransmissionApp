using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChainTransmissionAPI.Migrations.StaticVariables
{
    /// <inheritdoc />
    public partial class initSV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssemblyUnitProps",
                columns: table => new
                {
                    tc = table.Column<double>(type: "double precision", nullable: false),
                    SM = table.Column<string>(type: "text", nullable: false),
                    v = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyUnitProps", x => new { x.tc, x.SM });
                });

            migrationBuilder.CreateTable(
                name: "Chains",
                columns: table => new
                {
                    ND = table.Column<string>(type: "text", nullable: false),
                    tc = table.Column<double>(type: "double precision", nullable: false),
                    S = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chains", x => x.ND);
                });

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    z = table.Column<int>(type: "integer", nullable: false),
                    tc = table.Column<double>(type: "double precision", nullable: false),
                    N = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => new { x.z, x.tc });
                });

            migrationBuilder.CreateTable(
                name: "UnitProps",
                columns: table => new
                {
                    TN = table.Column<string>(type: "text", nullable: false),
                    TU = table.Column<string>(type: "text", nullable: false),
                    K_d = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitProps", x => new { x.TN, x.TU });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyUnitProps");

            migrationBuilder.DropTable(
                name: "Chains");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "UnitProps");
        }
    }
}
