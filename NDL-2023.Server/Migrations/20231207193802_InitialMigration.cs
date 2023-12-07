using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NDL_2023.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "true_or_false",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    statement = table.Column<string>(type: "text", nullable: false),
                    additional_explanation = table.Column<string>(type: "text", nullable: false),
                    true_or_false = table.Column<bool>(type: "boolean", nullable: false),
                    difficulty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_true_or_false", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "true_or_false");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
