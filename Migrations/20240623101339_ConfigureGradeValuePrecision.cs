using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSProject.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureGradeValuePrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Submissions_SubmissionID",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SubmissionID",
                table: "Grades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubmissionID",
                table: "Grades",
                column: "SubmissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Submissions_SubmissionID",
                table: "Grades",
                column: "SubmissionID",
                principalTable: "Submissions",
                principalColumn: "SubmissionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
