using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class AppContext : DbContext
    {
        public AppContext() {}

        public AppContext(DbContextOptions<AppContext> options)
            : base(options) { }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Advice> Advice { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<CheckListMark> CheckListMark { get; set; }
        public virtual DbSet<Colors> Color { get; set; }
        public virtual DbSet<DayPhrase> DayPhrase { get; set; }
        public virtual DbSet<Habit> Habit { get; set; }
        public virtual DbSet<HabitPerformance> HabitPerformance { get; set; }
        public virtual DbSet<HabitType> HabitType { get; set; }
        public virtual DbSet<Memo> Memo { get; set; }
        public virtual DbSet<Phrase> Phrase { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }
        public virtual DbSet<PlanetElem> PlanetElem { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<StartPage> StartPage { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(""); //Some ConString
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
                {
                    entity.HasKey(e => e.Id)
                    .HasName("account_pk");

                    entity.ToTable("account");

                    entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                    entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("password");

                    entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                    entity.Property(e => e.FamilyName)
                    .IsRequired()
                    .HasColumnName("familyname");
                    //TODO: Add DataType "sex" to DB
                    entity.Property(e => e.UserSex)
                    .IsRequired()
                    .HasColumnName("sex");

                    entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                    entity.Property(e => e.RegDate)
                    .IsRequired()
                    .HasColumnType("timestamp with timezone")
                    .HasColumnName("reg_date");

                    //TODO: Add PrimaryKey of two attributes
                    entity.HasOne(d => d.User)
                    .WithOne(p => p.Account)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("acc_usr_fk");
                });

            modelBuilder.Entity<Advice>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("advice_pk");

                entity.ToTable("advice");

                entity.Property(e => e.AdviceText)
                .IsRequired()
                .HasColumnName("advice_text");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("answ_pk");

                entity.ToTable("answer");

                entity.Property(e => e.AnswerText)
                .IsRequired()
                .HasColumnName("answer_text");

                entity.HasOne(d => d.Question)
                .WithMany(p => p.Answer);
            });

            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("checklist_pk");

                entity.ToTable("checklist");

                entity.Property(e => e.ExecStatus)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("exec_status");

                entity.HasOne(d => d.User)
                .WithMany(p => p.CheckList);

                entity.HasMany(d => d.Habit)
                .WithMany(p => p.CheckList)
                .UsingEntity(j => j.ToTable("checklist_contains"));
            });

            modelBuilder.Entity<CheckListMark>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("checklist_mark_pk");

                entity.ToTable("checklist_mark");

                entity.Property(e => e.IsMarked)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("is_marked");

                entity.HasOne(d => d.CheckList)
                .WithMany(p => p.CheckListMark);
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("color_pk");

                entity.ToTable("color");
            });

            modelBuilder.Entity<DayPhrase>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("day_phrase_pk");

                entity.ToTable("day_phrase");

                entity.Property(e => e.PhraseText)
                .IsRequired()
                .HasColumnName("phrase_text");
            });

            modelBuilder.Entity<Habit>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("habit_pk");

                entity.ToTable("habit");

                entity.Property(e => e.Score)
                .IsRequired()
                .HasColumnName("score");
            });

            modelBuilder.Entity<HabitPerformance>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("hab_perf_pk");

                entity.ToTable("habit_performance");

                entity.Property(e => e.ExecProperty)
                .IsRequired()
                .HasColumnName("exec_property");

                entity.Property(e => e.NumOfExecs)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnName("num_of_execs");

                entity.Property(e => e.DateOfExec)
                .IsRequired()
                .HasColumnType("timestamp with timezone")
                .HasColumnName("date_of_exec");
            });

            modelBuilder.Entity<HabitType>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("hab_type_pk");

                entity.ToTable("habit_type");

                entity.Property(e => e.NameType)
                .IsRequired()
                .HasColumnName("name_type");
            });

            modelBuilder.Entity<Memo>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("memo_pk");

                entity.ToTable("memo");

                entity.Property(e => e.MemoName)
                .IsRequired()
                .HasColumnName("memo_name");

                entity.Property(e => e.MemoRef)
                .IsRequired()
                .HasColumnName("memo_ref");
            });

            modelBuilder.Entity<Phrase>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("phrase_pk");

                entity.ToTable("phrase");

                entity.Property(e => e.PhraseText)
                .IsRequired()
                .HasColumnName("phrase_text");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("plan_pk");

                entity.ToTable("planet");

                entity.Property(e => e.PlanetRef)
                .IsRequired()
                .HasColumnName("planet_ref");
            });

            modelBuilder.Entity<PlanetElem>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("plan_elem_pk");

                entity.ToTable("planet_elem");

                entity.Property(e => e.ElemDescription)
                .IsRequired()
                .HasColumnName("elem_descript");

                entity.Property(e => e.ElemRef)
                .IsRequired()
                .HasColumnName("elem_ref");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("quest_pk");

                entity.ToTable("question");

                entity.Property(e => e.QuestText)
                .IsRequired()
                .HasColumnName("quest_text");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("role_pk");

                entity.ToTable("role");

                entity.Property(e => e.UserRole)
                .IsRequired()
                .HasColumnName("user_role");
            });

            modelBuilder.Entity<StartPage>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("start_pk");

                entity.ToTable("start_page");

                entity.HasOne(d => d.Planet)
                .WithOne(p => p.StartPage)
                .HasForeignKey<Planet>(d => d.Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("start_plan_fk");
                //Вопрос про Advice и DayPhrase, нужно ли ManyToMany или можно их хранить просто так?
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("usr_pk");

                entity.ToTable("user");

                entity.Property(e => e.ScoreSum)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("score_sum");

                entity.HasOne(d => d.StartPage)
                .WithOne(p => p.User)
                .HasForeignKey<StartPage>(d => d.Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("us_start_fk");

                entity.HasOne(d => d.Role)
                .WithMany(p => p.User);
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("us_an_pkey");

                entity.ToTable("user_answer");

                entity.HasOne(d => d.Answer)
                .WithMany(p => p.UserAnswer);

                entity.HasOne(d => d.Question)
                .WithMany(p => p.UserAnswer);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
