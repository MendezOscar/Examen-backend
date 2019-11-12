using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace calculadorabe.Models
{
    public partial class calculadoradbContext : DbContext
    {
        public calculadoradbContext()
        {
        }

        public calculadoradbContext(DbContextOptions<calculadoradbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calculadora> Calculadora { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVM649N\\SQLEXPRESS;Database=calculadoradb;User Id=Mendez; Password=M3nd3z; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calculadora>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PK__calculad__E7EB6988A209F857");

                entity.ToTable("calculadora");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OperandoDos).HasColumnName("operandoDos");

                entity.Property(e => e.OperandoUno).HasColumnName("operandoUno");

                entity.Property(e => e.Resultado).HasColumnName("resultado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
