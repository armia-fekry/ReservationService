using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Api.Migrations
{
    public partial class reservationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_ReservedByUserID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedByUserID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedByUserID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "ReservedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                newName: "IX_Reservations_ReservedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_ReservedBy",
                table: "Reservations",
                column: "ReservedBy",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_ReservedBy",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservedBy",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ReservedBy",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ReservedByUserID",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedByUserID",
                table: "Reservations",
                column: "ReservedByUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_ReservedByUserID",
                table: "Reservations",
                column: "ReservedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
