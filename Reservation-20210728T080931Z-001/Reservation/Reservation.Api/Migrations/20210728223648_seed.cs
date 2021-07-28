using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Api.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "CityName", "Content", "CreationDate", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "cairo", "test", new DateTime(2021, 7, 28, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(219), "test", "cairo trip", 23.399999999999999 },
                    { 2, "Alex", "test", new DateTime(2021, 8, 27, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(2526), "test", "alex trip", 233.40000000000001 },
                    { 3, "misr", "test", new DateTime(2021, 8, 12, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(2688), "test", "misr trip", 900.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "Armia@fekry.com", new byte[] { 181, 45, 32, 255, 250, 23, 114, 94, 238, 34, 159, 108, 100, 1, 120, 207, 246, 175, 31, 173, 14, 213, 79, 59, 55, 162, 32, 162, 92, 201, 93, 176, 32, 147, 128, 141, 200, 27, 152, 39, 89, 52, 194, 18, 187, 42, 185, 138, 164, 235, 70, 82, 251, 46, 179, 59, 126, 231, 143, 241, 4, 83, 91, 252 }, new byte[] { 106, 33, 10, 19, 143, 40, 72, 170, 144, 229, 81, 223, 77, 54, 191, 140, 105, 23, 85, 185, 248, 250, 248, 23, 49, 128, 108, 71, 36, 42, 30, 9, 243, 150, 122, 212, 182, 19, 169, 101, 49, 65, 215, 226, 170, 90, 65, 162, 139, 182, 128, 252, 52, 0, 96, 138, 121, 181, 187, 35, 246, 183, 9, 208, 238, 152, 178, 162, 252, 120, 107, 54, 116, 255, 60, 240, 168, 145, 32, 108, 164, 183, 135, 22, 193, 11, 198, 186, 113, 249, 228, 23, 195, 139, 31, 5, 54, 49, 223, 131, 57, 77, 164, 99, 66, 69, 40, 218, 24, 21, 203, 113, 206, 50, 26, 55, 97, 196, 240, 9, 2, 30, 62, 42, 61, 18, 22, 149 } });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ResevationId", "CreationDate", "CustomerName", "Notes", "ReservationDate", "ReservedBy", "TripId" },
                values: new object[] { 1, new DateTime(2021, 7, 28, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(4010), "cust one", "this is notes ", new DateTime(2021, 7, 31, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(4735), 1, 2 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ResevationId", "CreationDate", "CustomerName", "Notes", "ReservationDate", "ReservedBy", "TripId" },
                values: new object[] { 2, new DateTime(2021, 7, 28, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(7058), "cust two", "this is notes two ", new DateTime(2021, 7, 31, 22, 36, 48, 266, DateTimeKind.Utc).AddTicks(7063), 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ResevationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ResevationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
