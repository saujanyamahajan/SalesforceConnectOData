using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesforceConnectOData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@acme.com", "Acme Corporation", "555-0101" },
                    { 2, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@globex.com", "Globex Industries", "555-0102" },
                    { 3, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "hello@initech.com", "Initech LLC", "555-0103" },
                    { 4, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sales@umbrella.com", "Umbrella Corp", "555-0104" },
                    { 5, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "tony@stark.com", "Stark Enterprises", "555-0105" },
                    { 6, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "bruce@wayne.com", "Wayne Industries", "555-0106" },
                    { 7, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "norman@oscorp.com", "Oscorp", "555-0107" },
                    { 8, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@cyberdyne.com", "Cyberdyne Systems", "555-0108" },
                    { 9, new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "willy@wonka.com", "Wonka Industries", "555-0109" },
                    { 10, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael@dundermifflin.com", "Dunder Mifflin", "555-0110" },
                    { 11, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "richard@piedpiper.com", "Pied Piper", "555-0111" },
                    { 12, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavin@hooli.com", "Hooli", "555-0112" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}

