using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Migrations
{
    public partial class typesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711f0144-dacb-46ea-b481-b9cf7eafe843");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781c7a2e-56dc-452e-9a7a-b8e87fdfe8d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a28115a5-c764-48ef-8c92-b9a8330f8615");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e4966b3-038d-45f3-aed3-2155d2fd0f12", "1af24125-8861-46c0-8d48-bce838daa41b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd1d1533-773e-4c7d-a4f5-57fdbb15fb49", "130930cb-d9b0-4637-8e96-11babcd3720e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3db2c8f-9a84-4588-a3df-229ad4e046e3", "4580a976-2f77-4dbf-8bb9-cfff81ecb127", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e4966b3-038d-45f3-aed3-2155d2fd0f12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd1d1533-773e-4c7d-a4f5-57fdbb15fb49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3db2c8f-9a84-4588-a3df-229ad4e046e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "711f0144-dacb-46ea-b481-b9cf7eafe843", "c2b621a5-fd43-4305-9b64-99ff1adc0f60", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "781c7a2e-56dc-452e-9a7a-b8e87fdfe8d2", "b4677b5b-e364-4f47-b0cf-0ee093bb986d", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a28115a5-c764-48ef-8c92-b9a8330f8615", "8a8a43d5-f389-4a45-8b62-d2e90a0f89a2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
