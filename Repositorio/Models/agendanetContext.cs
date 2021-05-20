using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repositorio.Models
{
    public partial class agendanetContext : DbContext
    {
        public agendanetContext()
        {
        }

        public agendanetContext(DbContextOptions<agendanetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= den1.mssql8.gear.host ; Database= agendanet; User Id=agendanet;Password=Gm35y?-r9tbC;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CodCidade);

                entity.ToTable("cidade");

                entity.Property(e => e.CodCidade).HasColumnName("cod_cidade");

                entity.Property(e => e.CodEstado).HasColumnName("cod_estado");

                entity.Property(e => e.NomeCidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_cidade");

                entity.HasOne(d => d.CodEstadoNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.CodEstado)
                    .HasConstraintName("FK_cidade_estado");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.CodEmpresa);

                entity.ToTable("empresa");

                entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");

                entity.Property(e => e.CnpjEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnpj_empresa");

                entity.Property(e => e.LoginEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login_empresa");

                entity.Property(e => e.NomeEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_empresa");

                entity.Property(e => e.SenhaEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha_empresa");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.CodEndereco);

                entity.ToTable("endereco");

                entity.Property(e => e.CodEndereco).HasColumnName("cod_endereco");

                entity.Property(e => e.CodCidade).HasColumnName("cod_cidade");

                entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");

                entity.Property(e => e.DataEndereco)
                    .HasColumnType("date")
                    .HasColumnName("data_endereco");

                entity.HasOne(d => d.CodCidadeNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CodCidade)
                    .HasConstraintName("FK_endereco_cidade");

                entity.HasOne(d => d.CodEmpresaNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CodEmpresa)
                    .HasConstraintName("FK_endereco_empresa");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.CodEstado)
                    .HasName("PK_tarefa");

                entity.ToTable("estado");

                entity.Property(e => e.CodEstado).HasColumnName("cod_estado");

                entity.Property(e => e.NomeEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_estado");

                entity.Property(e => e.SiglaEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sigla_estado")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.CodTelefone);

                entity.ToTable("telefone");

                entity.Property(e => e.CodTelefone).HasColumnName("cod_telefone");

                entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");

                entity.Property(e => e.DataTelefone)
                    .HasColumnType("date")
                    .HasColumnName("data_telefone");

                entity.Property(e => e.DddTelefone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ddd_telefone");

                entity.Property(e => e.NumeroTelefone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_telefone");

                entity.HasOne(d => d.CodEmpresaNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.CodEmpresa)
                    .HasConstraintName("FK_telefone_empresa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
