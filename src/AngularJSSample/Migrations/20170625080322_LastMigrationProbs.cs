using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularJSSample.Migrations
{
    public partial class LastMigrationProbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nuetral",
                table: "Interaction",
                newName: "Neutral");

            migrationBuilder.RenameColumn(
                name: "Disguest",
                table: "Interaction",
                newName: "Disgust");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Neutral",
                table: "Interaction",
                newName: "Nuetral");

            migrationBuilder.RenameColumn(
                name: "Disgust",
                table: "Interaction",
                newName: "Disguest");
        }
    }
}
