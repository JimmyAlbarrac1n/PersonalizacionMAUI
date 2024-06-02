using System.ComponentModel.DataAnnotations;

namespace JA_API_BurgerPromo.Data.Models;

public partial class JA_Promo
{
    [Key]
    public int PromoId { get; set; }

    public string? Descripcion { get; set; } = null!;

    public DateTime FechaPromo { get; set; }

    public int BurgerId { get; set; }

    public virtual JA_Burger Burger { get; set; } = null!;
}
