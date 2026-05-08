using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEaseBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialAzureV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueId1",
                table: "Bookings",
                column: "VenueId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueId1",
                table: "Bookings",
                column: "VenueId1",
                principalTable: "Venues",
                principalColumn: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "VenueId1",
                table: "Bookings");
        }
    }
}
