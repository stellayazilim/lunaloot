using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LunaLoot.Master.Infrastructure.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Addresses = table.Column<string>(type: "text", nullable: false),
                    AccountUserRef = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    City = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Province = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Town = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Street = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    PostCode = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 18, 17, 36, 22, 461, DateTimeKind.Utc).AddTicks(9793)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 18, 17, 36, 22, 462, DateTimeKind.Utc).AddTicks(257)),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReceiptName = table.Column<string>(type: "text", nullable: false),
                    ReceiptTitle = table.Column<string>(type: "text", nullable: false),
                    ReceiptTaxAdministration = table.Column<string>(type: "text", nullable: false),
                    ReceiptAddressRef = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuerName = table.Column<string>(type: "text", nullable: false),
                    IssuerTitle = table.Column<string>(type: "text", nullable: false),
                    IssuerTaxAdministration = table.Column<string>(type: "text", nullable: false),
                    IssuerAddressRef = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceType = table.Column<int>(type: "integer", nullable: false),
                    InvoiceItems = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false),
                    ParentRef1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentRef = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_ParentRef", x => x.ParentRef);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentRef1",
                        column: x => x.ParentRef1,
                        principalTable: "Products",
                        principalColumn: "ParentRef");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InvoiceId = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityLogins",
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
                    table.PrimaryKey("PK_IdentityLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityLogins_IdentityUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRoles",
                columns: table => new
                {
                    IdentityUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentityRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("0f06a74c-6df2-45c7-8591-0eae25944c98")),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRoles", x => new { x.IdentityUserId, x.IdentityRoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_IdentityRoles_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "IdentityRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_IdentityUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "CreatedAt", "DeleteReason", "DeletedAt", "Description", "Name", "Permissions", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { new Guid("6f56a218-f732-4db4-b733-c768c9b897f3"), new DateTime(2024, 5, 18, 17, 36, 19, 22, DateTimeKind.Utc).AddTicks(3085), null, null, "Tanants of the application", "Tenant", 0, new DateTime(2024, 5, 18, 17, 36, 19, 22, DateTimeKind.Utc).AddTicks(3085), 1 },
                    { new Guid("b06725ab-db5e-4d2f-b7bd-4938fa13e582"), new DateTime(2024, 5, 18, 17, 36, 19, 22, DateTimeKind.Utc).AddTicks(3087), null, null, "Anonymous user of application", "anonymous", 0, new DateTime(2024, 5, 18, 17, 36, 19, 22, DateTimeKind.Utc).AddTicks(3087), 0 },
                    { new Guid("df93739f-ac5a-403c-8627-14816449cadc"), new DateTime(2024, 5, 18, 17, 36, 19, 22, DateTimeKind.Utc).AddTicks(3077), null, null, "Administrator user of application", "Administrator", -1, new DateTime(2024, 5, 18, 17, 36, 19, 22, DateTimeKind.Utc).AddTicks(3078), 999 }
                });

            migrationBuilder.InsertData(
                table: "IdentityUsers",
                columns: new[] { "Id", "CreatedAt", "DeleteReason", "DeletedAt", "Email", "Password", "PhoneNumber", "UpdatedAt" },
                values: new object[] { new Guid("61be0adb-a0fd-4fd0-89d0-63f140c2be09"), new DateTime(2024, 5, 18, 17, 36, 22, 456, DateTimeKind.Utc).AddTicks(5368), null, null, "administrator@master.lunaloot", "$2a$16$FcM8a4tv.I3n6Pi.CSYMUOPS6Z7ViqrsU7m7DqZtAePkjOQohbEZW", "12345678910", new DateTime(2024, 5, 18, 17, 36, 22, 456, DateTimeKind.Utc).AddTicks(5371) });

            migrationBuilder.InsertData(
                table: "IdentityUserRoles",
                columns: new[] { "IdentityRoleId", "IdentityUserId", "CreatedAt", "DeleteReason", "DeletedAt", "Id", "UpdatedAt" },
                values: new object[] { new Guid("df93739f-ac5a-403c-8627-14816449cadc"), new Guid("61be0adb-a0fd-4fd0-89d0-63f140c2be09"), new DateTime(2024, 5, 18, 17, 36, 22, 456, DateTimeKind.Utc).AddTicks(5412), null, null, new Guid("94d507c9-2333-4e23-8daf-903604d4debd"), new DateTime(2024, 5, 18, 17, 36, 22, 456, DateTimeKind.Utc).AddTicks(5412) });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityLogins_UserId",
                table: "IdentityLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoles_Name",
                table: "IdentityRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRoles_IdentityRoleId",
                table: "IdentityUserRoles",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_Email",
                table: "IdentityUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentRef1",
                table: "Products",
                column: "ParentRef1");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AccountId",
                table: "Subscriptions",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "IdentityLogins");

            migrationBuilder.DropTable(
                name: "IdentityUserRoles");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "IdentityRoles");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
