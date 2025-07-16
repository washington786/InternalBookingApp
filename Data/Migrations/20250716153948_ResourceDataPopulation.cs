using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InternalBookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ResourceDataPopulation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Capacity", "Description", "IsAvailable", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 20, "Main conference room with video conferencing", true, "Floor 1, West Wing", "Conference Room A" },
                    { 2, 15, "Training room with projector and whiteboards", false, "Floor 2, East Wing", "Training Room B" },
                    { 3, 8, "Private meeting room for executive staff", true, "Floor 3, North Wing", "Executive Suite" },
                    { 4, 50, "Shared collaborative workspace", true, "Floor 1, Central Area", "Open Workspace" },
                    { 5, 1, "Soundproof booth for private calls", true, "Floor 2, Near Elevators", "Phone Booth" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
