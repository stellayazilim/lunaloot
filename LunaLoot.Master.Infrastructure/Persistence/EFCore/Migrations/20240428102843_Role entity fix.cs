using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Roleentityfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "IdentityUserRole",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("64db894c-3eaf-414d-abcb-c9d3169c793a"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldDefaultValue: new Guid("42b36546-2ad2-4074-a580-476622d35634"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4416),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(4836));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "IdentityUserRole",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("42b36546-2ad2-4074-a580-476622d35634"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldDefaultValue: new Guid("64db894c-3eaf-414d-abcb-c9d3169c793a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(5009),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(4836),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4416));
        }
    }
}
