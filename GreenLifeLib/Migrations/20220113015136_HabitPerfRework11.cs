using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeLib.Migrations
{
    public partial class HabitPerfRework11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habit_performance_usr_UserId",
                table: "habit_performance");

            migrationBuilder.DropIndex(
                name: "IX_habit_performance_UserId",
                table: "habit_performance");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "habit_performance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "habit_performance",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_habit_performance_UserId",
                table: "habit_performance",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_habit_performance_usr_UserId",
                table: "habit_performance",
                column: "UserId",
                principalTable: "usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
