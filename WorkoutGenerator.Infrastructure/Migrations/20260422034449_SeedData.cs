using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkoutGenerator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "Discriminator", "Name", "Phone" },
                values: new object[] { 1, "Coach", "Coach Mike", "12345678" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Strength" },
                    { 2, "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "DifficultyLevelId", "Name" },
                values: new object[,]
                {
                    { 1, "Beginner" },
                    { 2, "Intermediate" },
                    { 3, "Advanced" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "CoachId", "Discriminator", "Name", "Phone" },
                values: new object[] { 2, 1, "Customer", "John Doe", "87654321" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "CategoryId", "DifficultyLevelId", "ExerciseDescription", "ExerciseName" },
                values: new object[,]
                {
                    { 1, 1, 2, "Chest exercise with barbell", "Bench Press" },
                    { 2, 1, 2, "Leg exercise with barbell", "Squat" },
                    { 3, 2, 1, "Core stability exercise", "Plank" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "WorkoutId", "CoachId", "CustomerId", "IsArchived", "IsTemplate", "WorkoutDescription", "WorkoutTitle" },
                values: new object[] { 1, 1, 2, false, false, "Simple beginner workout", "Full Body Beginner" });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "WorkoutExerciseId", "Duration", "ExerciseId", "Notes", "Order", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[,]
                {
                    { 1, null, 1, null, 1, 10, 3, null, 1 },
                    { 2, null, 2, null, 2, 8, 3, null, 1 },
                    { 3, 60, 3, null, 3, null, null, null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "WorkoutExerciseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "WorkoutExerciseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "WorkoutExerciseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
