using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JA_API_BurgerPromo.Data.Models;

namespace JA_API_BurgerPromo
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<JA_API_BurgerPromo.Data.Models.JA_Burger> JA_Burger { get; set; } = default!;
    }
}
