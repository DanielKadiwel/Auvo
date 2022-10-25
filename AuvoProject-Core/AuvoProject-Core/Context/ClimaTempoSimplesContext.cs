using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuvoProject_Core.Context
{
    public partial class ClimaTempoSimplesContext : DbContext
    {
        public ClimaTempoSimplesContext()
        {
        }

        public ClimaTempoSimplesContext(DbContextOptions<ClimaTempoSimplesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidades { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<PrevisaoClima> PrevisaoClimas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ClimaTempoSimples;Data Source=DESKTECH-DK");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("Cidade");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome).HasMaxLength(200);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cidade_estado");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome).HasMaxLength(200);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<PrevisaoClima>(entity =>
            {
                entity.ToTable("PrevisaoClima");

                entity.Property(e => e.Clima).HasMaxLength(15);

                entity.Property(e => e.DataPrevisao).HasColumnType("date");

                entity.Property(e => e.TemperaturaMaxima).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.TemperaturaMinima).HasColumnType("numeric(3, 1)");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.PrevisaoClimas)
                    .HasForeignKey(d => d.CidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_previsao_cidade");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
