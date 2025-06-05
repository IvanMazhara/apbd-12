using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd_12.Migrations
{
    /// <inheritdoc />
    public partial class AddClientTripAndCountryTripSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientTrip",
                columns: new[] { "IdClient", "IdTrip", "PaymentDate", "RegisteredAt" },
                values: new object[,]
                {
                    { 1001, 1, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1003, 2, null, new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1004, 2, new DateTime(2015, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CountryTrip",
                columns: new[] { "IdCountry", "IdTrip" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientTrip",
                keyColumns: new[] { "IdClient", "IdTrip" },
                keyValues: new object[] { 1001, 1 });

            migrationBuilder.DeleteData(
                table: "ClientTrip",
                keyColumns: new[] { "IdClient", "IdTrip" },
                keyValues: new object[] { 1003, 2 });

            migrationBuilder.DeleteData(
                table: "ClientTrip",
                keyColumns: new[] { "IdClient", "IdTrip" },
                keyValues: new object[] { 1004, 2 });

            migrationBuilder.DeleteData(
                table: "CountryTrip",
                keyColumns: new[] { "IdCountry", "IdTrip" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CountryTrip",
                keyColumns: new[] { "IdCountry", "IdTrip" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CountryTrip",
                keyColumns: new[] { "IdCountry", "IdTrip" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
