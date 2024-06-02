using JA_API_BurgerPromo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JA_API_BurgerPromo.Data;

public partial class JaburgerPromoContext : DbContext
{
    public JaburgerPromoContext()
    {
    }

    public JaburgerPromoContext(DbContextOptions<JaburgerPromoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JA_Burger> JaBurgers { get; set; }

    public virtual DbSet<JA_Promo> JaPromos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JABurgerPromo;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JA_Burger>(entity =>
        {
            entity.ToTable("JA_Burger");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<JA_Promo>(entity =>
        {
            entity.HasKey(e => e.PromoId);

            entity.ToTable("JA_Promo");

            entity.HasIndex(e => e.BurgerId, "IX_JA_Promo_BurgerID");

            entity.Property(e => e.PromoId).HasColumnName("PromoID");
            entity.Property(e => e.BurgerId).HasColumnName("BurgerID");

            entity.HasOne(d => d.Burger).WithMany(p => p.JaPromos).HasForeignKey(d => d.BurgerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
