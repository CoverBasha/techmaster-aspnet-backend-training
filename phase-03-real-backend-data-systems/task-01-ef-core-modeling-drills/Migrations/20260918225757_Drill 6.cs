using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace task_01_ef_core_modeling_drills.Migrations
{
    /// <inheritdoc />
    public partial class Drill6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Fullname" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Ahmed Hassan" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Mariam Ibrahim" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Email", "Fullname", "IsActive" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.hassan@example.com", "Omar Hassan", false },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.ahmed@example.com", "Youssef Ahmed", false },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "karim.mahmoud@example.com", "Karim Mahmoud", false },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.adel@example.com", "Mariam Adel", false },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.khaled@example.com", "Nour Khaled", false }
                });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "StudentID", "Address", "DateOfBirth", "EmergencyPhone", "NationalId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Nasr City, Cairo", new DateTime(2002, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "01012345678", "30101234567891" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Maadi, Cairo", new DateTime(2001, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "01123456789", "30202345678912" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Heliopolis, Cairo", new DateTime(2003, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "01234567890", "30303456789123" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "New Cairo, Cairo", new DateTime(2002, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "01098765432", "30404567891234" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Dokki, Giza", new DateTime(2001, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "01187654321", "30505678912345" }
                });

            migrationBuilder.InsertData(
                table: "TrainingTracks",
                columns: new[] { "Id", "InstructorId", "Name" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), ".NET Backend Development" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("11111111-1111-1111-1111-111111111111"), "Database Fundamentals" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("22222222-2222-2222-2222-222222222222"), "Cloud Development" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "EnrollmentDate", "FinalGrade", "StudentId", "TrackId" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.5f, new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 92f, new Guid("22222222-2222-2222-2222-222222222222"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.5f, new Guid("33333333-3333-3333-3333-333333333333"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 81f, new Guid("55555555-5555-5555-5555-555555555555"), new Guid("33333333-3333-3333-3333-333333333333") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "StudentID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "StudentID",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "StudentID",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "StudentID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "StudentID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
