using System.ComponentModel.DataAnnotations;

namespace JA_BurgerPromo.Models
{
    public class JA_Promo
    {
        [Key]
        public int PromoID { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public DateTime FechaPromo { get; set; }

        public int BurgerID { get; set; }
        public JA_Burger? Burger { get; set; }
    }
}
