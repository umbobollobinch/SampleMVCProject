using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample001.Migrations.AccountDB
{
    public partial class _211104_remake_adbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => new { x.User, x.Pass });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInfo");
        }
    }
}
