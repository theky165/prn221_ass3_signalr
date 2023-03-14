using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SignalRAssignment.Models;

public partial class Prn221Ass3Context : DbContext
{
    public Prn221Ass3Context()
    {
    }

    public Prn221Ass3Context(DbContextOptions<Prn221Ass3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostCategory> PostCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("prn221db"));
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fullname).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PostCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
