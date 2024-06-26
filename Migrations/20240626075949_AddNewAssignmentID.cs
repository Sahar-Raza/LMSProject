using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSProject.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAssignmentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewAssignmentID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Assignments SET NewAssignmentID = AssignmentID");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "NewAssignmentID",
                table: "Assignments",
                newName: "AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "AssignmentID");

            migrationBuilder.Sql("ALTER TABLE Assignments ADD CONSTRAINT PK_Assignments PRIMARY KEY CLUSTERED (AssignmentID)");

            migrationBuilder.Sql("ALTER TABLE Assignments ALTER COLUMN AssignmentID ADD IDENTITY(1,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "NewAssignmentID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Assignments SET NewAssignmentID = AssignmentID");

            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "NewAssignmentID",
                table: "Assignments",
                newName: "AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "AssignmentID");
        }
    }
}