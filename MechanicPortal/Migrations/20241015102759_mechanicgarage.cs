using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicPortal.Migrations
{
    /// <inheritdoc />
    public partial class mechanicgarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    GarageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GarageName = table.Column<string>(type: "TEXT", nullable: false),
                    GarageDescription = table.Column<string>(type: "TEXT", nullable: false),
                    GarageType = table.Column<string>(type: "TEXT", nullable: false),
                    GarageLocation = table.Column<string>(type: "TEXT", nullable: false),
                    AssignedEmployee = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.GarageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateAdded",
                table: "Employee",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
