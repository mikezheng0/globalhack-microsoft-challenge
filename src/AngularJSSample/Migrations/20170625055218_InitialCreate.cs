using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularJSSample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cordinates");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropTable(
                name: "Interaction");
        }
    }
}
