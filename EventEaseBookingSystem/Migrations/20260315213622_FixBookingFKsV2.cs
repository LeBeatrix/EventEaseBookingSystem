using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEaseBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixBookingFKsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_EventId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "VenueId1",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VenueId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId1",
                table: "Bookings",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueId1",
                table: "Bookings",
                column: "VenueId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId1",
                table: "Bookings",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueId1",
                table: "Bookings",
                column: "VenueId1",
                principalTable: "Venues",
                principalColumn: "VenueId");
        }
    }
}
