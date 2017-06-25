using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSSample.Migrations
{
    public partial class AwksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Interaction",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "Interaction",
                newName: "Top");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Interaction",
                newName: "Left");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Interaction",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "Top",
                table: "Interaction",
                newName: "X");

            migrationBuilder.RenameColumn(
                name: "Left",
                table: "Interaction",
                newName: "Weight");
        }
    }
}
