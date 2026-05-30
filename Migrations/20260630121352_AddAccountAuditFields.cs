using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesforceConnectOData.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Account",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Account",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AnnualRevenue",
                table: "Account",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillingPostalCode",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingState",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingStreet",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedDate",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmployees",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ownership",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingCity",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingCountry",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingPostalCode",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingState",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingStreet",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sic",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemModstamp",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TickerSymbol",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootAssetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product2Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompetitorProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemModstamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AnnualRevenue",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingPostalCode",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingState",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingStreet",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "NumberOfEmployees",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Ownership",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ShippingCity",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ShippingCountry",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ShippingPostalCode",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ShippingState",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ShippingStreet",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Sic",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "SystemModstamp",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "TickerSymbol",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Accounts",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

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
    }
}
