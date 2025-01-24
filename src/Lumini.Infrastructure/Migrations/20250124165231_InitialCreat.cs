using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lumini.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Origin = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Destination = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Value = table.Column<decimal>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => new { x.Origin, x.Destination });
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Destination", "Origin", "Value" },
                values: new object[,]
                {
                    { "SCL", "BRC", 5m },
                    { "BRC", "GRU", 10m },
                    { "CDG", "GRU", 75m },
                    { "ORL", "GRU", 56m },
                    { "SCL", "GRU", 20m },
                    { "CDG", "ORL", 5m },
                    { "ORL", "SCL", 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
