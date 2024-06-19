using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class prodcut_spesifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specifications",
                schema: "default",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specifications",
                schema: "default",
                table: "Products");
        }
    }
}
