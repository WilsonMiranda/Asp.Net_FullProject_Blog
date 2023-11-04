using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class CretingAuthDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b4f6009-7c3f-4791-8306-571190d42ee1",
                column: "ConcurrencyStamp",
                value: "0b4f6009-7c3f-4791-8306-571190d42ee1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37471c9-08f5-4c02-b1b2-625ab9de713f",
                column: "ConcurrencyStamp",
                value: "c37471c9-08f5-4c02-b1b2-625ab9de713f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6817ce4-0424-4adf-adb4-c7d3b8cd3e65",
                column: "ConcurrencyStamp",
                value: "f6817ce4-0424-4adf-adb4-c7d3b8cd3e65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47f99196-20ed-4496-ba4a-8d68fbea6fe7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a2133e-5aab-4600-a18c-2d67a6405966", "AQAAAAIAAYagAAAAECMfxldHnKpoVyIePRU/WKbBSLG3u9voXVVCzA8698hizAKMj1GhLjT/+dw10BFOsw==", "d29eeb9c-3928-4ac6-8cf3-c4f9e27285f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b4f6009-7c3f-4791-8306-571190d42ee1",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37471c9-08f5-4c02-b1b2-625ab9de713f",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6817ce4-0424-4adf-adb4-c7d3b8cd3e65",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47f99196-20ed-4496-ba4a-8d68fbea6fe7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b8e9f0c-61c3-4b1b-8225-7adda9b61dab", "AQAAAAIAAYagAAAAEI5PVmA+Fd2cIbjxB7CLVHiJY/Vw7DzEJb4Z1EPSEi9qw2p8T/tvGKS9pEvc9JEI7A==", "b0ea07bc-3182-4dcb-abd7-0b46fd69343c" });
        }
    }
}
