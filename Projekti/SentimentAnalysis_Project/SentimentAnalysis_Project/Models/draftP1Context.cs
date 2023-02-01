using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SentimentAnalysis_Project.Models
{
    public partial class draftP1Context : DbContext
    {
        public draftP1Context()
        {
        }

        public draftP1Context(DbContextOptions<draftP1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Fakulteti> Fakultetis { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Instituti> Institutis { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAcc> UserAccs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=draftP1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fakulteti>(entity =>
            {
                entity.ToTable("Fakulteti");

                entity.HasIndex(e => e.Email, "UQ__Fakultet__A9D105346729A686")
                    .IsUnique();

                entity.Property(e => e.FakultetiId)
                    .ValueGeneratedNever()
                    .HasColumnName("FakultetiID");

                entity.Property(e => e.Dega)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusiAkredititmit).HasDefaultValueSql("((0))");

                entity.Property(e => e.VitiAkreditimit).HasColumnType("date");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Idfeedback)
                    .HasName("PK__Feedback__8456A50AEF5586A4");

                entity.ToTable("Feedback");

                entity.Property(e => e.Idfeedback).HasColumnName("IDFeedback");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.FakultetiId).HasColumnName("FakultetiID");

                entity.Property(e => e.InstitutiId).HasColumnName("InstitutiID");

                entity.Property(e => e.Permbajtja)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Fakulteti)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.FakultetiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Fakult__440B1D61");

                entity.HasOne(d => d.Instituti)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.InstitutiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Instit__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__UserID__44FF419A");
            });

            modelBuilder.Entity<Instituti>(entity =>
            {
                entity.ToTable("Instituti");

                entity.HasIndex(e => e.Nrtelefonit, "UQ__Institut__1E44B1BFF49BFE9F")
                    .IsUnique();

                entity.Property(e => e.InstitutiId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstitutiID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lokacioni)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nrtelefonit)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__ED4DE4420CB429FA");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Dega)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Ditelindja).HasColumnType("date");

                entity.Property(e => e.Emri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FakultetiId).HasColumnName("FakultetiID");

                entity.Property(e => e.FillimiStudimeve).HasColumnType("date");

                entity.Property(e => e.Gjinia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InstitutiId).HasColumnName("InstitutiID");

                entity.Property(e => e.Mbiemri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MesatarjaNotes).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Statusi).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Instituti)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.InstitutiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__InstitutiI__398D8EEE");
            });

            modelBuilder.Entity<UserAcc>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__UserAcc__ED4DE442A999FBDC");

                entity.ToTable("UserAcc");

                entity.HasIndex(e => e.Email, "UQ__UserAcc__A9D105343FE23AEA")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CS_AS");

                entity.Property(e => e.Roli)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.UserAcc)
                    .HasForeignKey<UserAcc>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAcc__ID_User__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
