using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRoleIdentityUser");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "IdentityUserRole",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("42b36546-2ad2-4074-a580-476622d35634"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldDefaultValue: new Guid("da5bfd28-8d13-4687-870c-f94708dfb7ae"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(5009),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 7, 9, 54, 438, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(4836),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 7, 9, 54, 438, DateTimeKind.Utc).AddTicks(7501));

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole_IdentityRoleId",
                table: "IdentityUserRole",
                column: "IdentityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityRole_IdentityRoleId",
                table: "IdentityUserRole",
                column: "IdentityRoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityUser_IdentityUserId",
                table: "IdentityUserRole",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityRole_IdentityRoleId",
                table: "IdentityUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityUser_IdentityUserId",
                table: "IdentityUserRole");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUserRole_IdentityRoleId",
                table: "IdentityUserRole");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "IdentityUserRole",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("da5bfd28-8d13-4687-870c-f94708dfb7ae"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldDefaultValue: new Guid("42b36546-2ad2-4074-a580-476622d35634"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 7, 9, 54, 438, DateTimeKind.Utc).AddTicks(7682),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 7, 9, 54, 438, DateTimeKind.Utc).AddTicks(7501),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 28, 7, 21, 48, 284, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.CreateTable(
                name: "IdentityRoleIdentityUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleIdentityUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_IdentityRoleIdentityUser_IdentityRole_RolesId",
                        column: x => x.RolesId,
                        principalTable: "IdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityRoleIdentityUser_IdentityUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleIdentityUser_UsersId",
                table: "IdentityRoleIdentityUser",
                column: "UsersId");
        }
    }
}
