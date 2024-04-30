using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IdentityLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "IdentityUserRole",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("3db8d9e1-4ef2-41ef-be43-472da8a746ec"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldDefaultValue: new Guid("64db894c-3eaf-414d-abcb-c9d3169c793a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 13, 40, 27, 940, DateTimeKind.Utc).AddTicks(5827),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 13, 40, 27, 940, DateTimeKind.Utc).AddTicks(5624),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.CreateTable(
                name: "IdentityLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsConsumed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityLogin_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityLogin_UserId",
                table: "IdentityLogin",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityLogin");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "IdentityUserRole",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("64db894c-3eaf-414d-abcb-c9d3169c793a"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldDefaultValue: new Guid("3db8d9e1-4ef2-41ef-be43-472da8a746ec"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 13, 40, 27, 940, DateTimeKind.Utc).AddTicks(5827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 10, 28, 43, 326, DateTimeKind.Utc).AddTicks(4416),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 13, 40, 27, 940, DateTimeKind.Utc).AddTicks(5624));
        }
    }
}
