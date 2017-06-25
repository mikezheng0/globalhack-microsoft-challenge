using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularJSSample.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cordinates");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.AddColumn<float>(
                name: "Anger",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Contempt",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Disguest",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fear",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Happiness",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Interaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Nuetral",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Sadness",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Suprise",
                table: "Interaction",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Interaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Interaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Interaction",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anger",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Contempt",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Disguest",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Fear",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Happiness",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Nuetral",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Sadness",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Suprise",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Interaction");

            migrationBuilder.CreateTable(
                name: "Cordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Height = table.Column<int>(nullable: false),
                    InteractionId = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cordinates_Interaction_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anger = table.Column<float>(nullable: false),
                    Contempt = table.Column<float>(nullable: false),
                    Disguest = table.Column<float>(nullable: false),
                    Fear = table.Column<float>(nullable: false),
                    Happiness = table.Column<float>(nullable: false),
                    InteractionId = table.Column<int>(nullable: false),
                    Nuetral = table.Column<float>(nullable: false),
                    Sadness = table.Column<float>(nullable: false),
                    Suprise = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emotions_Interaction_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cordinates_InteractionId",
                table: "Cordinates",
                column: "InteractionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emotions_InteractionId",
                table: "Emotions",
                column: "InteractionId",
                unique: true);
        }
    }
}
