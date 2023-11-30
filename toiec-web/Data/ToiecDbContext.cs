using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using toiec_web.Data;

namespace toiec_web.Models
{
    public class ToiecDbContext : IdentityDbContext<IdentityUser>
    {
        public ToiecDbContext(DbContextOptions<ToiecDbContext> options) 
            : base(options) 
        { 

        }
        #region DbSet
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizs { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestQuestionUnit> TestQuestionUnits { get; set; }
        public virtual DbSet<TestRecord> TestRecords { get; set; }
        public virtual DbSet<TestType> TestTypes { get; set; }
        public virtual DbSet<UserAnswer> UserAnswers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VipPackage> VipPackages { get; set; }
        public virtual DbSet<VipStudent> VipStudents { get; set; }
        public virtual DbSet<Vocabulary> Vocabularies { get; set;}
        public virtual DbSet<VocTopic> VocabularyTopics { get; set; }
        public virtual DbSet<ResetPassword> ResetPasswords { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);

            //config table
            #region relationship
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(s => s.idAdmin);

            });
            modelBuilder.Entity<AnswerQuestion>(entity =>
            {
                entity.HasKey(s => s.idAnswer);

            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(s => s.idComment);
                entity.HasOne(s => s.Post).WithMany(s => s.Comments)
                    .HasForeignKey(s => s.idPost)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CommentsOfPost");
                entity.HasOne(s => s.Users).WithMany(s => s.Comments)
                    .HasForeignKey(s => s.idUser)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CommentsOfUser");

            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(s => s.idCourse);
                entity.HasOne(s => s.Professor).WithMany(s => s.Courses)
                    .HasForeignKey(s => s.idProfessor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CourseOfProfessor");

            });
            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(s => s.idLesson);
                entity.HasOne(s => s.Course).WithMany(s => s.Lessons)
                    .HasForeignKey(s => s.idCourse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LessonOfCourse");
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(s => s.idPayment);
                entity.HasOne(s => s.PaymentMethod).WithMany(s => s.Payments)
                    .HasForeignKey(s => s.idMethod)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PaymentOfMethod");
                entity.HasOne(s => s.Student).WithMany(s => s.Payments)
                    .HasForeignKey(s => s.idStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PaymentOfStudent");
            });
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(s => s.idMethod);
                
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(s => s.idPost);
                entity.HasOne(s => s.Users).WithMany(s => s.Posts)
                    .HasForeignKey(s => s.idUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PostOfUser");

            });
            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(s => s.idProfessor);

            });
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(s => s.idQuestion);
                entity.HasOne(s => s.Quiz).WithMany(s => s.Questions)
                    .HasForeignKey(s => s.idQuiz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionsOfQuiz");
                entity.HasOne(s => s.Test).WithMany(s => s.Questions)
                    .HasForeignKey(s => s.idTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionsOfTest");
                entity.HasOne(s => s.Professor).WithMany(s => s.Questions)
                    .HasForeignKey(s => s.idProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionsOfProfessor");

            });
            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(s => s.idQuiz);
                entity.HasOne(s => s.Lesson).WithMany(s => s.Quizzes)
                    .HasForeignKey(s => s.idLesson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuizzesOfLesson");
            });
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(s => s.idReport);
                entity.HasOne(s => s.Post).WithMany(s => s.Reports)
                    .HasForeignKey(s => s.idPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportsOfPost");
                entity.HasOne(s => s.Users).WithMany(s => s.Reports)
                    .HasForeignKey(s => s.idUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportsOfUser");
                entity.HasOne(s => s.Admin).WithMany(s => s.Reports)
                    .HasForeignKey(s => s.idAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminCheckReport");

            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.idStudent);
                entity.HasOne(s => s.VipStudent).WithOne(s => s.Student)
                    .HasForeignKey<VipStudent>(s => s.idStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_VipStudentOfStudent");
            });
            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(s => s.idTest);
                entity.HasOne(s => s.TestType).WithMany(s => s.Tests)
                    .HasForeignKey(s => s.idType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TypeTest");
                entity.HasOne(s => s.Professor).WithMany(s => s.Tests)
                    .HasForeignKey(s => s.idProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TestOfProfessor");
            });
            modelBuilder.Entity<TestQuestionUnit>(entity =>
            {
                entity.HasKey(s => s.idQuestionUnit);
                entity.HasOne(s => s.Tests).WithMany(s => s.TestQuestionUnits)
                    .HasForeignKey(s => s.idTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitOfTest");
            });
            modelBuilder.Entity<TestRecord>(entity =>
            {
                entity.HasKey(s => s.idRecord);
                entity.HasOne(s => s.Test).WithMany(s => s.TestRecords)
                    .HasForeignKey(s => s.idTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RecordOfTest");
                entity.HasOne(s => s.Student).WithMany(s => s.TestRecords)
                    .HasForeignKey(s => s.idStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("RecordOfStudent");

            });
            modelBuilder.Entity<TestType>(entity =>
            {
                entity.HasKey(s => s.idTestType);
            });
            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.HasKey(s => s.idUAnswer);
                entity.HasOne(s => s.TestRecord).WithMany(s => s.UserAnswers)
                    .HasForeignKey(s => s.idRecord)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RecordAnswer");
                entity.HasOne(s => s.Question).WithMany(s => s.UserAnswers)
                    .HasForeignKey(s => s.idQuestion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AnswerOfQuestion");
                entity.HasOne(s => s.Student).WithMany(s => s.UserAnswers)
                    .HasForeignKey(s => s.idStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AnswerOfStudent");
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasOne(s => s.Student).WithOne(s => s.Users)
                    .HasForeignKey<Student>(s => s.idUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_StudentOfUser");
                entity.HasOne(s => s.Admin).WithOne(s => s.Users)
                    .HasForeignKey<Admin>(s => s.idUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminOfUser");
                entity.HasOne(s => s.Professor).WithOne(s => s.Users)
                    .HasForeignKey<Professor>(s => s.idUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProfessorOfUser");

            });
            modelBuilder.Entity<VipPackage>(entity =>
            {
                entity.HasKey(s => s.idPackage);
                entity.HasOne(s => s.Payment).WithMany(s => s.VipPackages)
                    .HasForeignKey(s => s.idPayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayVipPackage");
                entity.HasOne(s => s.Admin).WithMany(s => s.VipPackages)
                    .HasForeignKey(s => s.idAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManageVipPackage");
            });
            modelBuilder.Entity<VipStudent>(entity =>
            {
                entity.HasKey(s => s.idVipStudent);
                
            });
            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.HasKey(s => s.idVoc);
                entity.HasOne(s => s.VocTopic).WithMany(s => s.Vocabularies)
                    .HasForeignKey(s => s.idTopic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VocOfTopic");
                entity.HasOne(s => s.Professor).WithMany(s => s.Vocabularies)
                    .HasForeignKey(s => s.idProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VocOfProfessor");
            });
            modelBuilder.Entity<VocTopic>(entity =>
            {
                entity.HasKey(s => s.idVocTopic);
                entity.HasOne(s => s.Professor).WithMany(s => s.VocTopics)
                    .HasForeignKey(s => s.idProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicOfProfessor");
            });

            #endregion

        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Student", ConcurrencyStamp = "2", NormalizedName = "Student" },
                new IdentityRole() { Name = "VipStudent", ConcurrencyStamp = "3", NormalizedName = "VipStudent" },
                new IdentityRole() { Name = "Professor", ConcurrencyStamp = "4", NormalizedName = "Professor" }
                );
        }
    }
}
