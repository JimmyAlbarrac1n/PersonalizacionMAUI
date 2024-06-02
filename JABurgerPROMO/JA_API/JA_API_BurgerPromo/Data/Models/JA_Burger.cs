namespace JA_API_BurgerPromo.Data.Models;

public partial class JA_Burger
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool WithCheese { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<JA_Promo> JaPromos { get; set; } = new List<JA_Promo>();
}
