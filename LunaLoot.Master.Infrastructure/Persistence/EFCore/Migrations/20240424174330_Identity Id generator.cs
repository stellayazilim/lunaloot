using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IdentityIdgenerator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "RVJrqv_K",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 17, 43, 30, 315, DateTimeKind.Utc).AddTicks(4251),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 17, 37, 27, 684, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 17, 43, 30, 315, DateTimeKind.Utc).AddTicks(4037),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 17, 37, 27, 684, DateTimeKind.Utc).AddTicks(4421));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "RVJrqv_K");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 17, 37, 27, 684, DateTimeKind.Utc).AddTicks(4606),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 17, 43, 30, 315, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 17, 37, 27, 684, DateTimeKind.Utc).AddTicks(4421),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 17, 43, 30, 315, DateTimeKind.Utc).AddTicks(4037));
        }
    }
}
