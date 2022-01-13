﻿// <auto-generated />
using System;
using GreenLifeLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GreenLifeLib.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220113015032_HabitPerfRework")]
    partial class HabitPerfRework
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CheckListHabitsHabit", b =>
                {
                    b.Property<int>("CheckListHabitsId")
                        .HasColumnType("integer");

                    b.Property<int>("HabitId")
                        .HasColumnType("integer");

                    b.HasKey("CheckListHabitsId", "HabitId");

                    b.HasIndex("HabitId");

                    b.ToTable("CheckListHabitsHabit");
                });

            modelBuilder.Entity("ColorPlanetColors", b =>
                {
                    b.Property<int>("ColorId")
                        .HasColumnType("integer");

                    b.Property<int>("PlanetColorsId")
                        .HasColumnType("integer");

                    b.HasKey("ColorId", "PlanetColorsId");

                    b.HasIndex("PlanetColorsId");

                    b.ToTable("ColorPlanetColors");
                });

            modelBuilder.Entity("DayPhrasePagePhrase", b =>
                {
                    b.Property<int>("DayPhraseId")
                        .HasColumnType("integer");

                    b.Property<int>("PagePhraseId")
                        .HasColumnType("integer");

                    b.HasKey("DayPhraseId", "PagePhraseId");

                    b.HasIndex("PagePhraseId");

                    b.ToTable("DayPhrasePagePhrase");
                });

            modelBuilder.Entity("ElementPlanetElement", b =>
                {
                    b.Property<int>("ElementId")
                        .HasColumnType("integer");

                    b.Property<int>("PlanetElementId")
                        .HasColumnType("integer");

                    b.HasKey("ElementId", "PlanetElementId");

                    b.HasIndex("PlanetElementId");

                    b.ToTable("ElementPlanetElement");
                });

            modelBuilder.Entity("GreenLifeLib.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("familyname");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("password");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("timestamptz")
                        .HasColumnName("reg_date");

                    b.Property<string>("UserSex")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sex");

                    b.HasKey("Id")
                        .HasName("account_pk");

                    b.ToTable("account");
                });

            modelBuilder.Entity("GreenLifeLib.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("answ_pk");

                    b.HasIndex("QuestionId");

                    b.ToTable("answer");
                });

            modelBuilder.Entity("GreenLifeLib.CheckList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CheckListName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("checklist_name");

                    b.Property<bool>("ExecStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("exec_status");

                    b.HasKey("Id")
                        .HasName("checklist_pk");

                    b.HasIndex("AccountId");

                    b.ToTable("checklist");
                });

            modelBuilder.Entity("GreenLifeLib.CheckListHabits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CheckListId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("checklist_habit_pk");

                    b.HasIndex("CheckListId")
                        .IsUnique();

                    b.ToTable("checklist_habit");
                });

            modelBuilder.Entity("GreenLifeLib.CheckListMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CheckListId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsMarked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_marked");

                    b.HasKey("Id")
                        .HasName("checklist_mark_pk");

                    b.HasIndex("CheckListId")
                        .IsUnique();

                    b.ToTable("checklist_mark");
                });

            modelBuilder.Entity("GreenLifeLib.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color_name");

                    b.Property<int>("PlanetId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("color_pk");

                    b.ToTable("color");
                });

            modelBuilder.Entity("GreenLifeLib.DayPhrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PhraseText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phrase_text");

                    b.HasKey("Id")
                        .HasName("day_phrase_pk");

                    b.ToTable("day_phrase");
                });

            modelBuilder.Entity("GreenLifeLib.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ElemDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("elem_descript");

                    b.Property<string>("ElemRef")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("elem_ref");

                    b.Property<int>("PlanetId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("plan_elem_pk");

                    b.ToTable("planet_elem");
                });

            modelBuilder.Entity("GreenLifeLib.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CheckListId")
                        .HasColumnType("integer");

                    b.Property<string>("HabitName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("habit_name");

                    b.Property<int?>("HabitTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("habit_pk");

                    b.HasIndex("HabitTypeId");

                    b.ToTable("habit");
                });

            modelBuilder.Entity("GreenLifeLib.HabitPerformance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfExec")
                        .HasColumnType("timestamptz")
                        .HasColumnName("date_of_exec");

                    b.Property<string>("ExecProperty")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("exec_property");

                    b.Property<bool>("Executed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("executed");

                    b.Property<int>("HabitId")
                        .HasColumnType("integer");

                    b.Property<int>("NumOfExecs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("num_of_execs");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("hab_perf_pk");

                    b.HasIndex("AccountId");

                    b.HasIndex("HabitId");

                    b.HasIndex("UserId");

                    b.ToTable("habit_performance");
                });

            modelBuilder.Entity("GreenLifeLib.HabitPhrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HabitId")
                        .HasColumnType("integer");

                    b.Property<string>("PhraseText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phrase_text");

                    b.HasKey("Id")
                        .HasName("habit_phrase_pk");

                    b.HasIndex("HabitId")
                        .IsUnique();

                    b.ToTable("habit_phrase");
                });

            modelBuilder.Entity("GreenLifeLib.HabitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name_type");

                    b.HasKey("Id")
                        .HasName("hab_type_pk");

                    b.ToTable("habit_type");
                });

            modelBuilder.Entity("GreenLifeLib.Memo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MemoName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("memo_name");

                    b.Property<string>("MemoRef")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("memo_ref");

                    b.HasKey("Id")
                        .HasName("memo_pk");

                    b.ToTable("memo");
                });

            modelBuilder.Entity("GreenLifeLib.PagePhrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("StartPageId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("page_phrase_pk");

                    b.HasIndex("StartPageId")
                        .IsUnique();

                    b.ToTable("page_phrase");
                });

            modelBuilder.Entity("GreenLifeLib.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PlanetRef")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("planet_ref");

                    b.Property<int>("StartPageId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("plan_pk");

                    b.ToTable("planet");
                });

            modelBuilder.Entity("GreenLifeLib.PlanetColors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PlanetId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("planet_colors_pk");

                    b.HasIndex("PlanetId")
                        .IsUnique();

                    b.ToTable("planet_color");
                });

            modelBuilder.Entity("GreenLifeLib.PlanetElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PlanetId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("planet_elem_pk");

                    b.HasIndex("PlanetId")
                        .IsUnique();

                    b.ToTable("planet_element");
                });

            modelBuilder.Entity("GreenLifeLib.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("QuestText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("quest_text");

                    b.HasKey("Id")
                        .HasName("quest_pk");

                    b.ToTable("question");
                });

            modelBuilder.Entity("GreenLifeLib.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_role");

                    b.HasKey("Id")
                        .HasName("role_pk");

                    b.ToTable("role");
                });

            modelBuilder.Entity("GreenLifeLib.StartPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PlanetId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("start_pk");

                    b.HasIndex("PlanetId")
                        .IsUnique();

                    b.ToTable("start_page");
                });

            modelBuilder.Entity("GreenLifeLib.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("ScoreSum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("score_sum");

                    b.Property<int>("StartPageId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("usr_pk");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("StartPageId")
                        .IsUnique();

                    b.ToTable("usr");
                });

            modelBuilder.Entity("GreenLifeLib.UserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int?>("AnswerId")
                        .HasColumnType("integer");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("us_an_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("user_answer");
                });

            modelBuilder.Entity("CheckListHabitsHabit", b =>
                {
                    b.HasOne("GreenLifeLib.CheckListHabits", null)
                        .WithMany()
                        .HasForeignKey("CheckListHabitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.Habit", null)
                        .WithMany()
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ColorPlanetColors", b =>
                {
                    b.HasOne("GreenLifeLib.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.PlanetColors", null)
                        .WithMany()
                        .HasForeignKey("PlanetColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DayPhrasePagePhrase", b =>
                {
                    b.HasOne("GreenLifeLib.DayPhrase", null)
                        .WithMany()
                        .HasForeignKey("DayPhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.PagePhrase", null)
                        .WithMany()
                        .HasForeignKey("PagePhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElementPlanetElement", b =>
                {
                    b.HasOne("GreenLifeLib.Element", null)
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.PlanetElement", null)
                        .WithMany()
                        .HasForeignKey("PlanetElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenLifeLib.Answer", b =>
                {
                    b.HasOne("GreenLifeLib.Question", "Question")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("GreenLifeLib.CheckList", b =>
                {
                    b.HasOne("GreenLifeLib.Account", "Account")
                        .WithMany("CheckList")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("GreenLifeLib.CheckListHabits", b =>
                {
                    b.HasOne("GreenLifeLib.CheckList", "CheckList")
                        .WithOne("CheckListHabits")
                        .HasForeignKey("GreenLifeLib.CheckListHabits", "CheckListId")
                        .HasConstraintName("chlha_chl_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckList");
                });

            modelBuilder.Entity("GreenLifeLib.CheckListMark", b =>
                {
                    b.HasOne("GreenLifeLib.CheckList", "CheckList")
                        .WithOne("CheckListMark")
                        .HasForeignKey("GreenLifeLib.CheckListMark", "CheckListId")
                        .HasConstraintName("chm_ch_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckList");
                });

            modelBuilder.Entity("GreenLifeLib.Habit", b =>
                {
                    b.HasOne("GreenLifeLib.HabitType", "HabitType")
                        .WithMany()
                        .HasForeignKey("HabitTypeId");

                    b.Navigation("HabitType");
                });

            modelBuilder.Entity("GreenLifeLib.HabitPerformance", b =>
                {
                    b.HasOne("GreenLifeLib.Account", "Account")
                        .WithMany("HabitPerformance")
                        .HasForeignKey("AccountId");

                    b.HasOne("GreenLifeLib.Habit", "Habit")
                        .WithMany("HabitPerformance")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.User", null)
                        .WithMany("HabitPerformance")
                        .HasForeignKey("UserId");

                    b.Navigation("Account");

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("GreenLifeLib.HabitPhrase", b =>
                {
                    b.HasOne("GreenLifeLib.Habit", "Habit")
                        .WithOne("HabitPhrase")
                        .HasForeignKey("GreenLifeLib.HabitPhrase", "HabitId")
                        .HasConstraintName("haph_ha_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("GreenLifeLib.PagePhrase", b =>
                {
                    b.HasOne("GreenLifeLib.StartPage", "StartPage")
                        .WithOne("PagePhrase")
                        .HasForeignKey("GreenLifeLib.PagePhrase", "StartPageId")
                        .HasConstraintName("paph_stpa_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StartPage");
                });

            modelBuilder.Entity("GreenLifeLib.PlanetColors", b =>
                {
                    b.HasOne("GreenLifeLib.Planet", "Planet")
                        .WithOne("PlanetColors")
                        .HasForeignKey("GreenLifeLib.PlanetColors", "PlanetId")
                        .HasConstraintName("plcol_col_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("GreenLifeLib.PlanetElement", b =>
                {
                    b.HasOne("GreenLifeLib.Planet", "Planet")
                        .WithOne("PlanetElement")
                        .HasForeignKey("GreenLifeLib.PlanetElement", "PlanetId")
                        .HasConstraintName("plel_el_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("GreenLifeLib.StartPage", b =>
                {
                    b.HasOne("GreenLifeLib.Planet", "Planet")
                        .WithOne("StartPage")
                        .HasForeignKey("GreenLifeLib.StartPage", "PlanetId")
                        .HasConstraintName("start_plan_fk")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("GreenLifeLib.User", b =>
                {
                    b.HasOne("GreenLifeLib.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("GreenLifeLib.User", "AccountId")
                        .HasConstraintName("usr_acc_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId");

                    b.HasOne("GreenLifeLib.StartPage", "StartPage")
                        .WithOne("User")
                        .HasForeignKey("GreenLifeLib.User", "StartPageId")
                        .HasConstraintName("us_start_fk")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");

                    b.Navigation("StartPage");
                });

            modelBuilder.Entity("GreenLifeLib.UserAnswer", b =>
                {
                    b.HasOne("GreenLifeLib.Account", "Account")
                        .WithMany("UserAnswer")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenLifeLib.Answer", "Answer")
                        .WithMany("UserAnswer")
                        .HasForeignKey("AnswerId");

                    b.HasOne("GreenLifeLib.Question", "Question")
                        .WithMany("UserAnswer")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Account");

                    b.Navigation("Answer");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("GreenLifeLib.Account", b =>
                {
                    b.Navigation("CheckList");

                    b.Navigation("HabitPerformance");

                    b.Navigation("User");

                    b.Navigation("UserAnswer");
                });

            modelBuilder.Entity("GreenLifeLib.Answer", b =>
                {
                    b.Navigation("UserAnswer");
                });

            modelBuilder.Entity("GreenLifeLib.CheckList", b =>
                {
                    b.Navigation("CheckListHabits");

                    b.Navigation("CheckListMark");
                });

            modelBuilder.Entity("GreenLifeLib.Habit", b =>
                {
                    b.Navigation("HabitPerformance");

                    b.Navigation("HabitPhrase");
                });

            modelBuilder.Entity("GreenLifeLib.Planet", b =>
                {
                    b.Navigation("PlanetColors");

                    b.Navigation("PlanetElement");

                    b.Navigation("StartPage");
                });

            modelBuilder.Entity("GreenLifeLib.Question", b =>
                {
                    b.Navigation("Answer");

                    b.Navigation("UserAnswer");
                });

            modelBuilder.Entity("GreenLifeLib.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenLifeLib.StartPage", b =>
                {
                    b.Navigation("PagePhrase");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenLifeLib.User", b =>
                {
                    b.Navigation("HabitPerformance");
                });
#pragma warning restore 612, 618
        }
    }
}
