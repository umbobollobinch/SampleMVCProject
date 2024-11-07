using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample001.Migrations.SchoolDB
{
    public partial class _211104_remake_dbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Covid19Results",
                columns: table => new
                {
                    pubDate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    patientNum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid19Results", x => x.pubDate);
                });

            migrationBuilder.CreateTable(
                name: "FukuiResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prefCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prefName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pubDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    developDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientSex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientSymptom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    travelRecord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recoverOrNot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FukuiResults", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GunmaResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pubDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientSex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunmaResults", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KanagawaResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pubDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientSex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanagawaResults", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covid19Results");

            migrationBuilder.DropTable(
                name: "FukuiResults");

            migrationBuilder.DropTable(
                name: "GunmaResults");

            migrationBuilder.DropTable(
                name: "KanagawaResults");
        }
    }
}
