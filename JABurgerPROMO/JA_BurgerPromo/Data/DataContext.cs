using Microsoft.EntityFrameworkCore;

namespace JA_BurgerPromo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<JA_BurgerPromo.Models.JA_Burger> JA_Burger { get; set; } = default!;
        public DbSet<JA_BurgerPromo.Models.JA_Promo> JA_Promo { get; set; } = default!;
    }
}
