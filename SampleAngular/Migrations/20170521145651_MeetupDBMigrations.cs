using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleAngular.Migrations
{
    public partial class MeetupDBMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetupSpeakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetupSpeakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetupEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<int>(nullable: false),
                    EventDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    EventName = table.Column<string>(maxLength: 255, nullable: true),
                    SpeakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetupEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetupEvents_MeetupSpeakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "MeetupSpeakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetupEvents_SpeakerId",
                table: "MeetupEvents",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetupEvents");

            migrationBuilder.DropTable(
                name: "MeetupSpeakers");
        }
    }
}
