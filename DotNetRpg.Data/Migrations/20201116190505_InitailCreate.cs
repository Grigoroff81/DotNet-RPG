using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetRpg.Data.Migrations
{
    public partial class InitailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    RpgClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RpgClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.RpgClassId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Hitpoints = table.Column<int>(type: "int", nullable: false),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    Inelligence = table.Column<int>(type: "int", nullable: false),
                    RpgClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_RpgClassId",
                        column: x => x.RpgClassId,
                        principalTable: "Classes",
                        principalColumn: "RpgClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "RpgClassId", "RpgClassName" },
                values: new object[] { 1, "Hobit" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Defence", "Hitpoints", "Inelligence", "Name", "RpgClassId", "Strenght" },
                values: new object[] { 1, 10, 100, 10, "Frodo", 1, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RpgClassId",
                table: "Characters",
                column: "RpgClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
