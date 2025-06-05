using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd_12.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    IdTrip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.IdTrip);
                });

            migrationBuilder.CreateTable(
                name: "ClientTrip",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdTrip = table.Column<int>(type: "int", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTrip", x => new { x.IdClient, x.IdTrip });
                    table.ForeignKey(
                        name: "FK_ClientTrip_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTrip_Trip_IdTrip",
                        column: x => x.IdTrip,
                        principalTable: "Trip",
                        principalColumn: "IdTrip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTrip",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdTrip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTrip", x => new { x.IdTrip, x.IdCountry });
                    table.ForeignKey(
                        name: "FK_CountryTrip_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTrip_Trip_IdTrip",
                        column: x => x.IdTrip,
                        principalTable: "Trip",
                        principalColumn: "IdTrip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Pesel", "Telephone" },
                values: new object[,]
                {
                    { 1001, "john@doe.com", "John", "Doe", "1265E789AD", "0888888888" },
                    { 1002, "maryjane@yahoo.com", "Mary", "Jane", "TR3434PO10", "0715931422" },
                    { 1003, "jade79@gmail.com", "Jade", "Aldemir", "EM7LP82112", "0553412210" },
                    { 1004, "kcrane@yahoo.com", "Kyle", "Crane", "10APOL300F", "0567002120" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "IdCountry", "Name" },
                values: new object[,]
                {
                    { 1, "Canada" },
                    { 2, "Turkey" },
                    { 3, "Poland" }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "IdTrip", "DateFrom", "DateTo", "Description", "MaxPeople", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A quick little tour to Canada.", 10, "Niagara Falls Excursion" },
                    { 2, new DateTime(2015, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mission to retrieve a file capable to save humanity.", 5, "Harran Expedition" },
                    { 3, new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "A cozy vacation at breathtaking range of Carpathians mountains.", 8, "Zakopane Vacation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTrip_IdTrip",
                table: "ClientTrip",
                column: "IdTrip");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTrip_IdCountry",
                table: "CountryTrip",
                column: "IdCountry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTrip");

            migrationBuilder.DropTable(
                name: "CountryTrip");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
