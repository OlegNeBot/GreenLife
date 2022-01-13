using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeLib.Migrations
{
    public partial class HabitPerfRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "habit_performance",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_habit_performance_AccountId",
                table: "habit_performance",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_habit_performance_account_AccountId",
                table: "habit_performance",
                column: "AccountId",
                principalTable: "account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habit_performance_account_AccountId",
                table: "habit_performance");

            migrationBuilder.DropIndex(
                name: "IX_habit_performance_AccountId",
                table: "habit_performance");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "habit_performance");
        }
    }
}
