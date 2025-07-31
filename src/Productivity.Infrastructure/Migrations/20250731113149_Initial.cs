using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Productivity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    ItemsPerPage = table.Column<int>(type: "int", nullable: false),
                    DefaultTimeZoneId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnabledChannelsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MutedNotificationTypesJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthenticationProvider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
