using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_01_ef_core_modeling_drills.Migrations
{
    /// <inheritdoc />
    public partial class Drill3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Students_StudentID",
                table: "StudentProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile");

            migrationBuilder.RenameTable(
                name: "StudentProfile",
                newName: "StudentProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles",
                column: "StudentID");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingTracks_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTracks_InstructorId",
                table: "TrainingTracks",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_Students_StudentID",
                table: "StudentProfiles",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_Students_StudentID",
                table: "StudentProfiles");

            migrationBuilder.DropTable(
                name: "TrainingTracks");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles");

            migrationBuilder.RenameTable(
                name: "StudentProfiles",
                newName: "StudentProfile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Students_StudentID",
                table: "StudentProfile",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
