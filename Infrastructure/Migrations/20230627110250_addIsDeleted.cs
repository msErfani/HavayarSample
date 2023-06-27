using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31c5ef3f-ac1f-4320-a269-6b76ca7cb469",
                column: "ConcurrencyStamp",
                value: "ebd2d9a3-0ea8-42d3-bda0-7f634228396e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7169D087-8B01-4208-A11C-382ADA23F0DF",
                column: "ConcurrencyStamp",
                value: "deb51798-380b-479b-b705-685173e67ae4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31c5ef3f-ac1f-4320-a269-6b76ca7cb469",
                column: "ConcurrencyStamp",
                value: "cb917d2e-4009-4f12-8580-252b2045d6ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7169D087-8B01-4208-A11C-382ADA23F0DF",
                column: "ConcurrencyStamp",
                value: "de2faa90-9081-4498-9312-005db5d6d121");
        }
    }
}
