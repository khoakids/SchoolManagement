using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagement.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<InfomationSubjects> InfomationSubjects { get; set; }
        public virtual DbSet<Majors> Majors { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=khoa\\SQLExpress;Database=School;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__Classes__CB1927C03F14F819");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__CourseI__2B3F6F97");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__MajorId__2A4B4B5E");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__Courses__C92D71A798C7CD5F");

                entity.Property(e => e.FinishDay).HasColumnType("date");

                entity.Property(e => e.StartDay).HasColumnType("date");
            });

            modelBuilder.Entity<InfomationSubjects>(entity =>
            {
                entity.HasKey(e => new { e.ProgramId, e.MajorId, e.SubjectId, e.StudyYear })
                    .HasName("PK__Infomati__D9F90FD2679F151F");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.InfomationSubjects)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Infomatio__Major__38996AB5");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.InfomationSubjects)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Infomatio__Progr__37A5467C");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.InfomationSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Infomatio__Subje__398D8EEE");
            });

            modelBuilder.Entity<Majors>(entity =>
            {
                entity.HasKey(e => e.MajorId)
                    .HasName("PK__Majors__D5B8BF91E864AD82");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.MajorName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Programs>(entity =>
            {
                entity.HasKey(e => e.ProgramId)
                    .HasName("PK__Programs__7525605804CB3EE2");

                entity.Property(e => e.ProgramName).HasMaxLength(100);
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.SubjectId, e.ExamTime })
                    .HasName("PK__Results__0800C6081B50451D");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Results__Student__33D4B598");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Results__Subject__34C8D9D1");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52B999360B586");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.StudentName).HasMaxLength(100);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__ClassI__2E1BDC42");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId)
                    .HasName("PK__Subjects__AC1BA3A8DAB31507");

                entity.Property(e => e.SubjectName).HasMaxLength(100);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subjects__Subjec__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
