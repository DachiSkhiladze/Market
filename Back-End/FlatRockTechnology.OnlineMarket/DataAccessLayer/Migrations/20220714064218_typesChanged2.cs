using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Migrations
{
    public partial class typesChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9c7e616c-efa1-4cbb-8c5a-f14432ab639d", "22c10bd4-d056-4a8b-8e52-58abeca6946e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fc0577d-cce5-4c86-8660-edcff0abdaf5", "f999ef25-dd6d-4c2d-86c9-b20a76d3b853", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a433072d-f0d1-4417-9672-c7bb25b7cc21", "5795d00a-0491-4343-aade-078f1ad0f49f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c7e616c-efa1-4cbb-8c5a-f14432ab639d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc0577d-cce5-4c86-8660-edcff0abdaf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a433072d-f0d1-4417-9672-c7bb25b7cc21");

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
    }
}
