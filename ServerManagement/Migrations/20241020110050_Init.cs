using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRunning = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "City", "IsRunning", "Name" },
                values: new object[,]
                {
                    { 1, "Calgary", true, "Server1" },
                    { 2, "Halifax", false, "Server2" },
                    { 3, "Toronto", false, "Server3" },
                    { 4, "Ottawa", false, "Server4" },
                    { 5, "Montreal", false, "Server5" },
                    { 6, "Calgary", true, "Server6" },
                    { 7, "Calgary", true, "Server7" },
                    { 8, "Halifax", false, "Server8" },
                    { 9, "Halifax", false, "Server9" },
                    { 10, "Toronto", true, "Server10" },
                    { 11, "Toronto", false, "Server11" },
                    { 12, "Ottawa", true, "Server12" },
                    { 13, "Ottawa", false, "Server13" },
                    { 14, "Montreal", false, "Server14" },
                    { 15, "Montreal", false, "Server15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
