using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class ApplicationContext : DbContext
    {
       // public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Advice> Advice { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<CheckListHabits> CheckListHabits { get; set; }
        public virtual DbSet<CheckListMark> CheckListMark { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<DayPhrase> DayPhrase { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<Habit> Habit { get; set; }
        public virtual DbSet<HabitPerformance> HabitPerformance { get; set; }
        public virtual DbSet<HabitPhrase> HabitPhrase { get; set; }
        public virtual DbSet<HabitType> HabitType { get; set; }
        public virtual DbSet<Memo> Memo { get; set; }
        public virtual DbSet<PageAdvice> PageAdvice { get; set;}
        public virtual DbSet<PagePhrase> PagePhrase { get; set; }
        public virtual DbSet<Phrase> Phrase { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }
        public virtual DbSet<PlanetColors> PlanetColors { get; set; }
        public virtual DbSet<Element> PlanetElement { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<StartPage> StartPage { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }

        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string conString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseNpgsql(conString);
                //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=greenlife_db;Username=postgres;Password=oleggol12");
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
                    .HasColumnType("varchar(64)")
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

                entity.Property(e => e.CheckListName)
                .IsRequired()
                .HasColumnName("checklist_name");

                entity.HasOne(d => d.User)
                .WithMany(p => p.CheckList);
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
                .WithOne(p => p.CheckListMark)
                .HasForeignKey<CheckList>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("chm_ch_fk");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("color_pk");

                entity.ToTable("color");

                entity.Property(e => e.ColorName)
                .IsRequired()
                .HasColumnName("color_name");
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

                entity.Property(e => e.HabitName)
                .IsRequired()
                .HasColumnName("habit_name");
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

                entity.HasOne(p => p.User)
                .WithMany(d => d.HabitPerformance);
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

            modelBuilder.Entity<Element>(entity =>
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

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.User)
                    .HasForeignKey<Account>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("usr_acc_fk");
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

                entity.HasOne(d => d.Account)
                .WithMany(p => p.UserAnswer);
            });

            //New tables added
            modelBuilder.Entity<PageAdvice>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("p_adv_pk");

                entity.ToTable("page_advice");

                entity.HasOne(p => p.StartPage)
                .WithOne(d => d.PageAdvice)
                .HasForeignKey<StartPage>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("padv_stpa_fk");

                entity.HasMany(p => p.Advice)
                .WithMany(d => d.PageAdvice);
            });

            modelBuilder.Entity<PagePhrase>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("page_phrase_pk");

                entity.ToTable("page_phrase");

                entity.HasOne(p => p.StartPage)
                .WithOne(d => d.PagePhrase)
                .HasForeignKey<StartPage>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("paph_stpa_fk");

                entity.HasMany(p => p.DayPhrase)
                .WithMany(d => d.PagePhrase);
            });

            modelBuilder.Entity<PlanetColors>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("planet_colors_pk");

                entity.ToTable("planet_color");

                entity.HasOne(p => p.Planet)
                .WithOne(d => d.PlanetColors)
                .HasForeignKey<Planet>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("plcol_col_fk");

                entity.HasMany(p => p.Color)
                .WithMany(d => d.PlanetColors);
            });

            modelBuilder.Entity<PlanetElement>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("planet_elem_pk");

                entity.ToTable("planet_element");

                entity.HasOne(p => p.Planet)
                .WithOne(d => d.PlanetElement)
                .HasForeignKey<StartPage>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("plel_el_fk");

                entity.HasMany(p => p.Element)
                .WithMany(d => d.PlanetElement);
            });

            modelBuilder.Entity<HabitPhrase>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("habit_phrase_pk");

                entity.ToTable("habit_phrase");

                entity.HasOne(p => p.Habit)
                .WithOne(d => d.HabitPhrase)
                .HasForeignKey<StartPage>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("haph_ha_fk");

                entity.HasMany(p => p.Phrase)
                .WithMany(d => d.HabitPhrase);
            });

            modelBuilder.Entity<CheckListHabits>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("checklist_habit_pk");

                entity.ToTable("checklist_habit");

                entity.HasOne(p => p.CheckList)
                .WithOne(d => d.CheckListHabits)
                .HasForeignKey<CheckList>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("chlha_chl_fk");

                entity.HasMany(p => p.Habit)
                .WithMany(d => d.CheckListHabits);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
