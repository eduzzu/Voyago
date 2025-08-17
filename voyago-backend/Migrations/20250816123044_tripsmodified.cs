using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace voyago_backend.Migrations
{
    /// <inheritdoc />
    public partial class tripsmodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_DriverId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_TripUser_Users_PassagersUserId",
                table: "TripUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripUser",
                table: "TripUser");

            migrationBuilder.DropIndex(
                name: "IX_TripUser_UserTripsTripId",
                table: "TripUser");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "PassagersUserId",
                table: "TripUser",
                newName: "UserTripsUserId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripUser",
                table: "TripUser",
                columns: new[] { "UserTripsTripId", "UserTripsUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_TripUser_UserTripsUserId",
                table: "TripUser",
                column: "UserTripsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripUser_Users_UserTripsUserId",
                table: "TripUser",
                column: "UserTripsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripUser_Users_UserTripsUserId",
                table: "TripUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripUser",
                table: "TripUser");

            migrationBuilder.DropIndex(
                name: "IX_TripUser_UserTripsUserId",
                table: "TripUser");

            migrationBuilder.RenameColumn(
                name: "UserTripsUserId",
                table: "TripUser",
                newName: "PassagersUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Trips",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripUser",
                table: "TripUser",
                columns: new[] { "PassagersUserId", "UserTripsTripId" });

            migrationBuilder.CreateIndex(
                name: "IX_TripUser_UserTripsTripId",
                table: "TripUser",
                column: "UserTripsTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverId",
                table: "Trips",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_DriverId",
                table: "Trips",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripUser_Users_PassagersUserId",
                table: "TripUser",
                column: "PassagersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
