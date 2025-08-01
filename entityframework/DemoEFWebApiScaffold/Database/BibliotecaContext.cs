using System;
using System.Collections.Generic;
using DemoEFWebApiScaffold.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFWebApiScaffold.Database;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Emprestimo> Emprestimos { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-wispy-bar-a8r7u89v-pooler.eastus2.azure.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_qbOapo9Al1TW; SSL Mode=VerifyFull; Channel Binding=Require;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("autor_pk");

            entity.ToTable("autor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Primeironome)
                .HasMaxLength(50)
                .HasColumnName("primeironome");
            entity.Property(e => e.Ultimonome)
                .HasMaxLength(50)
                .HasColumnName("ultimonome");
        });

        modelBuilder.Entity<Emprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("emprestimo_pk");

            entity.ToTable("emprestimo");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Datadevolucao).HasColumnName("datadevolucao");
            entity.Property(e => e.Dataretirada).HasColumnName("dataretirada");
            entity.Property(e => e.Entregue).HasColumnName("entregue");
            entity.Property(e => e.Idlivro).HasColumnName("idlivro");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Emprestimo)
                .HasForeignKey<Emprestimo>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emprestimo_livro_fk");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("livro_pk");

            entity.ToTable("livro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasMany(d => d.Idautors).WithMany(p => p.Idlivros)
                .UsingEntity<Dictionary<string, object>>(
                    "Autorlivro",
                    r => r.HasOne<Autor>().WithMany()
                        .HasForeignKey("Idautor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("autorlivro_autor_fk"),
                    l => l.HasOne<Livro>().WithMany()
                        .HasForeignKey("Idlivro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("autorlivro_livro_fk"),
                    j =>
                    {
                        j.HasKey("Idlivro", "Idautor").HasName("autorlivro_pk");
                        j.ToTable("autorlivro");
                        j.IndexerProperty<int>("Idlivro").HasColumnName("idlivro");
                        j.IndexerProperty<int>("Idautor").HasColumnName("idautor");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
