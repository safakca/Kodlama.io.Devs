using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgLangEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgLangEntities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgLangEntities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "ProgLangEntities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Java" });

            migrationBuilder.InsertData(
                table: "ProgLangEntities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Pyhton" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgLangEntities");
        }
    }
}
