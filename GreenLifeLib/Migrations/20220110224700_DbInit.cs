using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GreenLifeLib.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    advice_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("advice_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "checklist_habit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("checklist_habit_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "checklist_mark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_marked = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CheckListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("checklist_mark_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    color_name = table.Column<string>(type: "text", nullable: false),
                    PlanetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("color_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "day_phrase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phrase_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("day_phrase_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "habit_phrase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("habit_phrase_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "habit_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("hab_type_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "memo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    memo_name = table.Column<string>(type: "text", nullable: false),
                    memo_ref = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("memo_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "page_advice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_adv_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "page_phrase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("page_phrase_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phrase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phrase_text = table.Column<string>(type: "text", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("phrase_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "planet_color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_colors_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "planet_elem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    elem_descript = table.Column<string>(type: "text", nullable: false),
                    elem_ref = table.Column<string>(type: "text", nullable: false),
                    PlanetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("plan_elem_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "planet_element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_elem_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quest_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quest_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvicePageAdvice",
                columns: table => new
                {
                    AdviceId = table.Column<int>(type: "integer", nullable: false),
                    PageAdviceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvicePageAdvice", x => new { x.AdviceId, x.PageAdviceId });
                    table.ForeignKey(
                        name: "FK_AdvicePageAdvice_advice_AdviceId",
                        column: x => x.AdviceId,
                        principalTable: "advice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvicePageAdvice_page_advice_PageAdviceId",
                        column: x => x.PageAdviceId,
                        principalTable: "page_advice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayPhrasePagePhrase",
                columns: table => new
                {
                    DayPhraseId = table.Column<int>(type: "integer", nullable: false),
                    PagePhraseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayPhrasePagePhrase", x => new { x.DayPhraseId, x.PagePhraseId });
                    table.ForeignKey(
                        name: "FK_DayPhrasePagePhrase_day_phrase_DayPhraseId",
                        column: x => x.DayPhraseId,
                        principalTable: "day_phrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayPhrasePagePhrase_page_phrase_PagePhraseId",
                        column: x => x.PagePhraseId,
                        principalTable: "page_phrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitPhrasePhrase",
                columns: table => new
                {
                    HabitPhraseId = table.Column<int>(type: "integer", nullable: false),
                    PhraseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitPhrasePhrase", x => new { x.HabitPhraseId, x.PhraseId });
                    table.ForeignKey(
                        name: "FK_HabitPhrasePhrase_habit_phrase_HabitPhraseId",
                        column: x => x.HabitPhraseId,
                        principalTable: "habit_phrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitPhrasePhrase_phrase_PhraseId",
                        column: x => x.PhraseId,
                        principalTable: "phrase",
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
                        name: "FK_ElementPlanetElement_planet_elem_ElementId",
                        column: x => x.ElementId,
                        principalTable: "planet_elem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementPlanetElement_planet_element_PlanetElementId",
                        column: x => x.PlanetElementId,
                        principalTable: "planet_element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    answer_text = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("answ_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_answer_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    score_sum = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    RoleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usr_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "varchar(64)", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    familyname = table.Column<string>(type: "text", nullable: false),
                    sex = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_pk", x => x.Id);
                    table.ForeignKey(
                        name: "usr_acc_fk",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "checklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    exec_status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    checklist_name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("checklist_pk", x => x.Id);
                    table.ForeignKey(
                        name: "chlha_chl_fk",
                        column: x => x.Id,
                        principalTable: "checklist_habit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "chm_ch_fk",
                        column: x => x.Id,
                        principalTable: "checklist_mark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_checklist_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "habit_performance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    exec_property = table.Column<string>(type: "text", nullable: false),
                    num_of_execs = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    date_of_exec = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("hab_perf_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_habit_performance_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "start_page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("start_pk", x => x.Id);
                    table.ForeignKey(
                        name: "padv_stpa_fk",
                        column: x => x.Id,
                        principalTable: "page_advice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "paph_stpa_fk",
                        column: x => x.Id,
                        principalTable: "page_phrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "us_start_fk",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "user_answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: true),
                    AnswerId = table.Column<int>(type: "integer", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("us_an_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_answer_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_answer_answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_answer_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "habit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    habit_name = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    HabitTypeId = table.Column<int>(type: "integer", nullable: true),
                    CheckListId = table.Column<int>(type: "integer", nullable: false),
                    HabitPerformanceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("habit_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_habit_habit_performance_HabitPerformanceId",
                        column: x => x.HabitPerformanceId,
                        principalTable: "habit_performance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_habit_habit_type_HabitTypeId",
                        column: x => x.HabitTypeId,
                        principalTable: "habit_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "haph_ha_fk",
                        column: x => x.Id,
                        principalTable: "habit_phrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    planet_ref = table.Column<string>(type: "text", nullable: false),
                    StartPageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("plan_pk", x => x.Id);
                    table.ForeignKey(
                        name: "plcol_col_fk",
                        column: x => x.Id,
                        principalTable: "planet_color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "plel_el_fk",
                        column: x => x.Id,
                        principalTable: "planet_element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "start_plan_fk",
                        column: x => x.Id,
                        principalTable: "start_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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

            migrationBuilder.CreateIndex(
                name: "IX_AdvicePageAdvice_PageAdviceId",
                table: "AdvicePageAdvice",
                column: "PageAdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_answer_QuestionId",
                table: "answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_checklist_UserId",
                table: "checklist",
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
                name: "IX_DayPhrasePagePhrase_PagePhraseId",
                table: "DayPhrasePagePhrase",
                column: "PagePhraseId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementPlanetElement_PlanetElementId",
                table: "ElementPlanetElement",
                column: "PlanetElementId");

            migrationBuilder.CreateIndex(
                name: "IX_habit_HabitPerformanceId",
                table: "habit",
                column: "HabitPerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_habit_HabitTypeId",
                table: "habit",
                column: "HabitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_habit_performance_UserId",
                table: "habit_performance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitPhrasePhrase_PhraseId",
                table: "HabitPhrasePhrase",
                column: "PhraseId");

            migrationBuilder.CreateIndex(
                name: "IX_user_RoleId",
                table: "user",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_answer_AccountId",
                table: "user_answer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_user_answer_AnswerId",
                table: "user_answer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_user_answer_QuestionId",
                table: "user_answer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvicePageAdvice");

            migrationBuilder.DropTable(
                name: "checklist");

            migrationBuilder.DropTable(
                name: "CheckListHabitsHabit");

            migrationBuilder.DropTable(
                name: "ColorPlanetColors");

            migrationBuilder.DropTable(
                name: "DayPhrasePagePhrase");

            migrationBuilder.DropTable(
                name: "ElementPlanetElement");

            migrationBuilder.DropTable(
                name: "HabitPhrasePhrase");

            migrationBuilder.DropTable(
                name: "memo");

            migrationBuilder.DropTable(
                name: "planet");

            migrationBuilder.DropTable(
                name: "user_answer");

            migrationBuilder.DropTable(
                name: "advice");

            migrationBuilder.DropTable(
                name: "checklist_mark");

            migrationBuilder.DropTable(
                name: "checklist_habit");

            migrationBuilder.DropTable(
                name: "habit");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "day_phrase");

            migrationBuilder.DropTable(
                name: "planet_elem");

            migrationBuilder.DropTable(
                name: "phrase");

            migrationBuilder.DropTable(
                name: "planet_color");

            migrationBuilder.DropTable(
                name: "planet_element");

            migrationBuilder.DropTable(
                name: "start_page");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "answer");

            migrationBuilder.DropTable(
                name: "habit_performance");

            migrationBuilder.DropTable(
                name: "habit_type");

            migrationBuilder.DropTable(
                name: "habit_phrase");

            migrationBuilder.DropTable(
                name: "page_advice");

            migrationBuilder.DropTable(
                name: "page_phrase");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
