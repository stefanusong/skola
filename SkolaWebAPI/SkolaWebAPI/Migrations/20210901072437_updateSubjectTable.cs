using Microsoft.EntityFrameworkCore.Migrations;

namespace SkolaWebAPI.Migrations
{
    public partial class updateSubjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Terms_termId",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_termId",
                table: "subjects",
                newName: "IX_subjects_termId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjects",
                table: "subjects",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_Terms_termId",
                table: "subjects",
                column: "termId",
                principalTable: "Terms",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subjects_Terms_termId",
                table: "subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjects",
                table: "subjects");

            migrationBuilder.RenameTable(
                name: "subjects",
                newName: "Subject");

            migrationBuilder.RenameIndex(
                name: "IX_subjects_termId",
                table: "Subject",
                newName: "IX_Subject_termId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Terms_termId",
                table: "Subject",
                column: "termId",
                principalTable: "Terms",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
