using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform45_MarsRoverChallenge_Michal_Malujlo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rovers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bearing = table.Column<int>(type: "int", nullable: false),
                    Y_Position = table.Column<int>(type: "int", nullable: false),
                    X_Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rovers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rovers");
        }
    }
}
