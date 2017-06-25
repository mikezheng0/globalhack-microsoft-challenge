using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSSample.Migrations
{
    public partial class SurpriseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Suprise",
                table: "Interaction",
                newName: "Surprise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surprise",
                table: "Interaction",
                newName: "Suprise");
        }
    }
}
