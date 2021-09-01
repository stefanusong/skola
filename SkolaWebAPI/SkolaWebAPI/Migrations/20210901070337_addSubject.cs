using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkolaWebAPI.Migrations
{
    public partial class addSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    termId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.subjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Terms_termId",
                        column: x => x.termId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_termId",
                table: "Subject",
                column: "termId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
