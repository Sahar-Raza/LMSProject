using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserCourseConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "EnrolledDate",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "IsEnrolled",
                table: "UserCourses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "UserCourses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserCourses",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                newName: "IX_UserCourses_CourseID");

            migrationBuilder.RenameColumn(
                name: "AssignmentTitle",
                table: "Assignments",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "AssignmentDescription",
                table: "Assignments",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CourseDescription",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseID",
                table: "UserCourses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UserID",
                table: "UserCourses",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseID",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UserID",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "UserCourses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserCourses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourses_CourseID",
                table: "UserCourses",
                newName: "IX_UserCourses_CourseId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Assignments",
                newName: "AssignmentTitle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Assignments",
                newName: "AssignmentDescription");

            migrationBuilder.AddColumn<DateTime>(
                name: "EnrolledDate",
                table: "UserCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnrolled",
                table: "UserCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseDescription",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
