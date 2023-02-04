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

        public virtual DbSet<Analiza> Analizas { get; set; } = null!;
        public virtual DbSet<Fakulteti> Fakultetis { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Infk> Infks { get; set; } = null!;
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
            modelBuilder.Entity<Analiza>(entity =>
            {
                entity.HasKey(e => e.Idanaliza)
                    .HasName("PK__Analiza__E36DC5A624BA71C5");

                entity.ToTable("Analiza");

                entity.Property(e => e.Idanaliza).HasColumnName("IDAnaliza");

                entity.Property(e => e.Idfeedback).HasColumnName("IDFeedback");

                entity.Property(e => e.Rezultati)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdfeedbackNavigation)
                    .WithMany(p => p.Analizas)
                    .HasForeignKey(d => d.Idfeedback)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Analiza__IDFeedb__3F466844");
            });

            modelBuilder.Entity<Fakulteti>(entity =>
            {
                entity.HasKey(e => e.Dega)
                    .HasName("PK__Fakultet__7E1896A4DE92C858");

                entity.ToTable("Fakulteti");

                entity.HasIndex(e => e.FakultetiId, "UQ__Fakultet__0B7D7E99AA78CDDA")
                    .IsUnique();

                entity.Property(e => e.Dega)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FakultetiId).HasColumnName("FakultetiID");

                entity.Property(e => e.TitulliDiplomimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Idfeedback)
                    .HasName("PK__Feedback__8456A50AE57DDCD9");

                entity.ToTable("Feedback");

                entity.Property(e => e.Idfeedback).HasColumnName("IDFeedback");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.DegaF)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutiF)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Permbajtja)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DegaFNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.DegaF)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__DegaF__3B75D760");

                entity.HasOne(d => d.InstitutiFNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.InstitutiF)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Instit__3A81B327");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__UserID__3C69FB99");
            });

            modelBuilder.Entity<Infk>(entity =>
            {
                entity.HasKey(e => new { e.InstitutiEmri, e.FakultetiDega, e.Idinfk })
                    .HasName("PK__INFK__2C4FDA859C7D727C");

                entity.ToTable("INFK");

                entity.Property(e => e.InstitutiEmri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FakultetiDega)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idinfk).HasColumnName("IDINFK");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusiAkredititmit).HasDefaultValueSql("((0))");

                entity.Property(e => e.VitiAkreditimit).HasColumnType("date");

                entity.HasOne(d => d.FakultetiDegaNavigation)
                    .WithMany(p => p.Infks)
                    .HasForeignKey(d => d.FakultetiDega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INFK__FakultetiD__2C3393D0");

                entity.HasOne(d => d.InstitutiEmriNavigation)
                    .WithMany(p => p.Infks)
                    .HasForeignKey(d => d.InstitutiEmri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INFK__InstitutiE__2B3F6F97");
            });

            modelBuilder.Entity<Instituti>(entity =>
            {
                entity.HasKey(e => e.Emri)
                    .HasName("PK__Institut__DCB4757E7B7B1DEF");

                entity.ToTable("Instituti");

                entity.HasIndex(e => e.Nrtelefonit, "UQ__Institut__1E44B1BF3FD4E9FA")
                    .IsUnique();

                entity.HasIndex(e => e.InstitutiId, "UQ__Institut__E7761A132786DBD0")
                    .IsUnique();

                entity.Property(e => e.Emri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutiId).HasColumnName("InstitutiID");

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
                    .HasName("PK__User__ED4DE4423B5E43E6");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Dega)
                    .HasMaxLength(50)
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

                entity.Property(e => e.InstitutiEmri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mbiemri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MesatarjaNotes).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Statusi).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.DegaNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Dega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Dega__31EC6D26");

                entity.HasOne(d => d.InstitutiEmriNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.InstitutiEmri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__InstitutiE__30F848ED");
            });

            modelBuilder.Entity<UserAcc>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__UserAcc__ED4DE442EF7566E9");

                entity.ToTable("UserAcc");

                entity.HasIndex(e => e.Email, "UQ__UserAcc__A9D10534000F963E")
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

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.UserAcc)
                    .HasForeignKey<UserAcc>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAcc__ID_User__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
