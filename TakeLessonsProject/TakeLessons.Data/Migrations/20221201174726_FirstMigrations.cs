using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLessons.Data.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "StateOfEducationsLevels",
                columns: table => new
                {
                    StateOfEducationsLevelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOfEducationsLevels", x => x.StateOfEducationsLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateOfEducationsLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Locations = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StateOfEducationsLevels_StateOfEducationsLevelId",
                        column: x => x.StateOfEducationsLevelId,
                        principalTable: "StateOfEducationsLevels",
                        principalColumn: "StateOfEducationsLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniversityGraduatedFrom = table.Column<string>(type: "TEXT", nullable: true),
                    HourlyPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFaceToFace = table.Column<bool>(type: "INTEGER", nullable: false),
                    CertifiedTrainer = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    StateOfEducationsLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Locations = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_StateOfEducationsLevels_StateOfEducationsLevelId",
                        column: x => x.StateOfEducationsLevelId,
                        principalTable: "StateOfEducationsLevels",
                        principalColumn: "StateOfEducationsLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAndStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAndStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherAndStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAndStudents_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 1, "Math" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 2, "English" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 3, "Chemistry" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 4, "Music" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 5, "Physics" });

            migrationBuilder.InsertData(
                table: "StateOfEducationsLevels",
                columns: new[] { "StateOfEducationsLevelId", "Name", "Url" },
                values: new object[] { 1, "High School", null });

            migrationBuilder.InsertData(
                table: "StateOfEducationsLevels",
                columns: new[] { "StateOfEducationsLevelId", "Name", "Url" },
                values: new object[] { 2, "Middle School", null });

            migrationBuilder.InsertData(
                table: "StateOfEducationsLevels",
                columns: new[] { "StateOfEducationsLevelId", "Name", "Url" },
                values: new object[] { 3, "Primary School", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "DateOfRegistration", "Description", "FirstName", "Gender", "Image", "IsDeleted", "LastName", "Locations", "StateOfEducationsLevelId", "Url" },
                values: new object[] { 1, 14, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2867), "Hi There :)", "Bernard ", "Male", "1.jpg", false, "Anna", "New York", 1, "students" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "BranchId", "CertifiedTrainer", "DateOfRegistration", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "Image", "IsDeleted", "IsFaceToFace", "LastName", "Locations", "StateOfEducationsLevelId", "UniversityGraduatedFrom", "Url" },
                values: new object[] { 1, 47, 1, true, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2968), "Hello, I'm a math teacher", "engin_niyazi@gmail.com", "Engin Niyazi", "Male", 300, "24.jpg", false, true, "Ergül", "New York", 1, "Stanford Universty", "engin-niyazi-ergül" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "BranchId", "CertifiedTrainer", "DateOfRegistration", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "Image", "IsDeleted", "IsFaceToFace", "LastName", "Locations", "StateOfEducationsLevelId", "UniversityGraduatedFrom", "Url" },
                values: new object[] { 2, 35, 2, true, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2971), "Hello, I'm a english teacher", "Goldschmidt@gmail.com", "Goldschmidt", "Male", 100, "2.jpg", false, true, "Forguson", "Alaska", 2, "Stanford Universty", "Goldschmidt" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "BranchId", "CertifiedTrainer", "DateOfRegistration", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "Image", "IsDeleted", "IsFaceToFace", "LastName", "Locations", "StateOfEducationsLevelId", "UniversityGraduatedFrom", "Url" },
                values: new object[] { 3, 31, 3, true, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2973), "Hi I'am a chemistry teacher", "Bagel_Jean@gmail.com", "Bagel", "Female", 150, "4.jpg", false, false, "Jean", "Florida", 2, "Stanford Universty", "Bagel" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "BranchId", "CertifiedTrainer", "DateOfRegistration", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "Image", "IsDeleted", "IsFaceToFace", "LastName", "Locations", "StateOfEducationsLevelId", "UniversityGraduatedFrom", "Url" },
                values: new object[] { 4, 28, 2, true, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2975), "Hi I'am a english teacher", "Miconi_autier@gmail.com", "Autier", "Male", 200, "5.jpg", false, true, "Miconi", "Virginia", 1, "Stanford Universty", "Autier" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "BranchId", "CertifiedTrainer", "DateOfRegistration", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "Image", "IsDeleted", "IsFaceToFace", "LastName", "Locations", "StateOfEducationsLevelId", "UniversityGraduatedFrom", "Url" },
                values: new object[] { 5, 25, 1, true, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2977), "Hello, I'm a music teacher", "Eggerer_alax@gmail.com", "Eggerer", "Male", 80, "6.jpg", false, false, "Alex", "Hawaii", 3, "Stanford Universty", "Eggerer" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "BranchId", "CertifiedTrainer", "DateOfRegistration", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "Image", "IsDeleted", "IsFaceToFace", "LastName", "Locations", "StateOfEducationsLevelId", "UniversityGraduatedFrom", "Url" },
                values: new object[] { 6, 42, 5, true, new DateTime(2022, 12, 1, 20, 47, 26, 231, DateTimeKind.Local).AddTicks(2979), "Hi I'am a Physics teacher", "George_Male@gmail.com", "Li", "Male", 100, "7.jpg", false, true, "George", "Kaliforniya", 2, "Stanford Universty", "Li" });

            migrationBuilder.InsertData(
                table: "TeacherAndStudents",
                columns: new[] { "StudentId", "TeacherId", "Url" },
                values: new object[] { 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StateOfEducationsLevelId",
                table: "Students",
                column: "StateOfEducationsLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAndStudents_StudentId",
                table: "TeacherAndStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_BranchId",
                table: "Teachers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StateOfEducationsLevelId",
                table: "Teachers",
                column: "StateOfEducationsLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAndStudents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "StateOfEducationsLevels");
        }
    }
}
