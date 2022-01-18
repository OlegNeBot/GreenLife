using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GreenLifeLib.Migrations
{
    public partial class DbRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "plcol_col_fk",
                table: "planet");

            migrationBuilder.DropForeignKey(
                name: "plel_el_fk",
                table: "planet");

            migrationBuilder.DropForeignKey(
                name: "FK_usr_role_RoleId",
                table: "usr");

            migrationBuilder.DropTable(
                name: "checklist_user");

            migrationBuilder.DropTable(
                name: "CheckListHabitsHabit");

            migrationBuilder.DropTable(
                name: "ColorPlanetColors");

            migrationBuilder.DropTable(
                name: "ElementPlanetElement");

            migrationBuilder.DropTable(
                name: "checklist_habit");

            migrationBuilder.DropTable(
                name: "planet_color");

            migrationBuilder.DropTable(
                name: "planet_element");

            migrationBuilder.DropIndex(
                name: "IX_planet_PlanetColorsId",
                table: "planet");

            migrationBuilder.DropIndex(
                name: "IX_planet_PlanetElementId",
                table: "planet");

            migrationBuilder.DropColumn(
                name: "PlanetColorsId",
                table: "planet");

            migrationBuilder.DropColumn(
                name: "PlanetElementId",
                table: "planet");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "usr",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckListId",
                table: "habit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "elem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "color",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "checklist",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CheckListHabit",
                columns: table => new
                {
                    CheckListId = table.Column<int>(type: "integer", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListHabit", x => new { x.CheckListId, x.HabitId });
                    table.ForeignKey(
                        name: "FK_CheckListHabit_checklist_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListHabit_habit_HabitId",
                        column: x => x.HabitId,
                        principalTable: "habit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorPlanet",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    PlanetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorPlanet", x => new { x.ColorId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_ColorPlanet_color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorPlanet_planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementPlanet",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    PlanetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementPlanet", x => new { x.ElementId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_ElementPlanet_elem_ElementId",
                        column: x => x.ElementId,
                        principalTable: "elem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementPlanet_planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checklist_UserId",
                table: "checklist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListHabit_HabitId",
                table: "CheckListHabit",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorPlanet_PlanetId",
                table: "ColorPlanet",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementPlanet_PlanetId",
                table: "ElementPlanet",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_checklist_usr_UserId",
                table: "checklist",
                column: "UserId",
                principalTable: "usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usr_role_RoleId",
                table: "usr",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_checklist_usr_UserId",
                table: "checklist");

            migrationBuilder.DropForeignKey(
                name: "FK_usr_role_RoleId",
                table: "usr");

            migrationBuilder.DropTable(
                name: "CheckListHabit");

            migrationBuilder.DropTable(
                name: "ColorPlanet");

            migrationBuilder.DropTable(
                name: "ElementPlanet");

            migrationBuilder.DropIndex(
                name: "IX_checklist_UserId",
                table: "checklist");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "habit");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "elem");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "color");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "checklist");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "usr",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PlanetColorsId",
                table: "planet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetElementId",
                table: "planet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "checklist_habit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckListId = table.Column<int>(type: "integer", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("checklist_habit_pk", x => x.Id);
                    table.ForeignKey(
                        name: "chlha_chl_fk",
                        column: x => x.CheckListId,
                        principalTable: "checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "checklist_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckListId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("checklist_user_pk", x => x.Id);
                    table.ForeignKey(
                        name: "chlu_chl_fk",
                        column: x => x.CheckListId,
                        principalTable: "checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_checklist_user_usr_UserId",
                        column: x => x.UserId,
                        principalTable: "usr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "planet_color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_colors_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "planet_element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ElementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_elem_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckListHabitsHabit",
                columns: table => new
                {
                    CheckListHabitsId = table.Column<int>(type: "integer", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListHabitsHabit", x => new { x.CheckListHabitsId, x.HabitId });
                    table.ForeignKey(
                        name: "FK_CheckListHabitsHabit_checklist_habit_CheckListHabitsId",
                        column: x => x.CheckListHabitsId,
                        principalTable: "checklist_habit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListHabitsHabit_habit_HabitId",
                        column: x => x.HabitId,
                        principalTable: "habit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorPlanetColors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    PlanetColorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorPlanetColors", x => new { x.ColorId, x.PlanetColorsId });
                    table.ForeignKey(
                        name: "FK_ColorPlanetColors_color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorPlanetColors_planet_color_PlanetColorsId",
                        column: x => x.PlanetColorsId,
                        principalTable: "planet_color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementPlanetElement",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    PlanetElementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementPlanetElement", x => new { x.ElementId, x.PlanetElementId });
                    table.ForeignKey(
                        name: "FK_ElementPlanetElement_elem_ElementId",
                        column: x => x.ElementId,
                        principalTable: "elem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementPlanetElement_planet_element_PlanetElementId",
                        column: x => x.PlanetElementId,
                        principalTable: "planet_element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planet_PlanetColorsId",
                table: "planet",
                column: "PlanetColorsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_planet_PlanetElementId",
                table: "planet",
                column: "PlanetElementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_checklist_habit_CheckListId",
                table: "checklist_habit",
                column: "CheckListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_checklist_user_CheckListId",
                table: "checklist_user",
                column: "CheckListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_checklist_user_UserId",
                table: "checklist_user",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListHabitsHabit_HabitId",
                table: "CheckListHabitsHabit",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorPlanetColors_PlanetColorsId",
                table: "ColorPlanetColors",
                column: "PlanetColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementPlanetElement_PlanetElementId",
                table: "ElementPlanetElement",
                column: "PlanetElementId");

            migrationBuilder.AddForeignKey(
                name: "plcol_col_fk",
                table: "planet",
                column: "PlanetColorsId",
                principalTable: "planet_color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "plel_el_fk",
                table: "planet",
                column: "PlanetElementId",
                principalTable: "planet_element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usr_role_RoleId",
                table: "usr",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
