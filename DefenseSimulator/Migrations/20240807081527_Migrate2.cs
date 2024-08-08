using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefenseSimulator.Migrations
{
    /// <inheritdoc />
    public partial class Migrate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Threat",
                columns: table => new
                {
                    ThreatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threat", x => x.ThreatId);
                    table.ForeignKey(
                        name: "FK_Threat_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreatId = table.Column<int>(type: "int", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterceptTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Threat_ThreatId",
                        column: x => x.ThreatId,
                        principalTable: "Threat",
                        principalColumn: "ThreatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Response_ThreatId",
                table: "Response",
                column: "ThreatId");

            migrationBuilder.CreateIndex(
                name: "IX_Threat_WeaponId",
                table: "Threat",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Threat");
        }
    }
}
