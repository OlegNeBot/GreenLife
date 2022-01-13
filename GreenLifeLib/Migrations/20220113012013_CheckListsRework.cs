using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeLib.Migrations
{
    public partial class CheckListsRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_checklist_usr_UserId",
                table: "checklist");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "checklist",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_checklist_UserId",
                table: "checklist",
                newName: "IX_checklist_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_checklist_account_AccountId",
                table: "checklist",
                column: "AccountId",
                principalTable: "account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_checklist_account_AccountId",
                table: "checklist");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "checklist",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_checklist_AccountId",
                table: "checklist",
                newName: "IX_checklist_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_checklist_usr_UserId",
                table: "checklist",
                column: "UserId",
                principalTable: "usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
