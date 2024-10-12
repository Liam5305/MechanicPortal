using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicPortal.Migrations
{
    public partial class AddDateAddedToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            UPDATE Employee
            SET DateAdded = datetime('now')
            WHERE DateAdded IS NULL OR DateAdded = '0001-01-01 00:00:00'
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Employee");
        }
    }
}