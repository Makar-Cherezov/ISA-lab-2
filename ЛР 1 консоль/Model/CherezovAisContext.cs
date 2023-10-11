using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Server.Model;

public partial class CherezovAisContext : DbContext
{
    public CherezovAisContext()
    {
    }

    public CherezovAisContext(DbContextOptions<CherezovAisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductDatum> ProductData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddUserSecrets<CherezovAisContext>()
        .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString(nameof(CherezovAisContext)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDatum>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.DateOfUpdating).HasColumnType("date");
            entity.Property(e => e.ProductDescription)
                .IsRequired()
                .HasMaxLength(110);
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SellerName)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
