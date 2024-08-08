using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefenseSimulator.Migrations
{
    /// <inheritdoc />
    public partial class Migrate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arsenal",
                columns: table => new
                {
                    Counter = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arsenal", x => x.Counter);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arsenal");
        }
    }
}
