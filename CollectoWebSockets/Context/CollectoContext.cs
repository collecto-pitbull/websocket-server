using System;
using System.Collections.Generic;
using CollectoWebSockets.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectoWebSockets.Context;

public partial class CollectoContext : DbContext
{
    public CollectoContext()
    {
    }

    public CollectoContext(DbContextOptions<CollectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contribution> Contributions { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contribution>(entity =>
        {
            entity.HasIndex(e => e.WalletId, "IX_Contributions_WalletId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Wallet).WithMany(p => p.Contributions).HasForeignKey(d => d.WalletId);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
