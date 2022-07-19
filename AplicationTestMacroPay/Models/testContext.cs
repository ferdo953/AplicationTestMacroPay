using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AplicationTestMacroPay.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=test;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Book>(entity =>
            {

                entity.ToTable("books");

                entity.Property(e => e.Author)
                    .HasMaxLength(250)
                    .HasColumnName("author");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ratings");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Rating1).HasColumnName("rating");

                entity.Property(e => e.RatingDate)
                    .HasColumnType("date")
                    .HasColumnName("rating_date");

                entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("reviewers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
