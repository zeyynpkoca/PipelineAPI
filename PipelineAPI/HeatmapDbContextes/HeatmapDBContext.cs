using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PipelineAPI.HeatmapDbContextes
{
    public partial class HeatmapDBContext : DbContext
    {
        public HeatmapDBContext()
        {
        }

        public HeatmapDBContext(DbContextOptions<HeatmapDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblMapsection> TblMapsections { get; set; } = null!;
        public virtual DbSet<TblPipeline> TblPipelines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=HeatmapDB;Encrypt=True;TrustServerCertificate=True;User ID=sa;Password=Admin123456*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblMapsection>(entity =>
            {
                entity.HasKey(e => e.MapSectionId);

                entity.ToTable("TBL_MAPSECTION");

                entity.Property(e => e.MapSectionId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblPipeline>(entity =>
            {
                entity.HasKey(e => e.PipelineId)
                    .HasName("PK__TBL_PIPE__DD42434FB8C92125");

                entity.ToTable("TBL_PIPELINE");

                entity.Property(e => e.PipelineId).ValueGeneratedNever();

                entity.Property(e => e.Akt).HasMaxLength(255);

                entity.Property(e => e.ChangeUser).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notification2).HasMaxLength(255);

                entity.Property(e => e.NotificationBot).HasMaxLength(255);

                entity.Property(e => e.PipelineDate).HasColumnType("date");

                entity.Property(e => e.TechnicalOd)
                    .HasMaxLength(255)
                    .HasColumnName("TechnicalOD");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.MapSection)
                    .WithMany(p => p.TblPipelines)
                    .HasForeignKey(d => d.MapSectionId)
                    .HasConstraintName("FK_TBL_PIPELINE_MapSectionId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
