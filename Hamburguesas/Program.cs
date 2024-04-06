public class Hamburguesa
{
    public string TipoPan { get; }
    public string TipoCarne { get; }
    public decimal PrecioBase { get; }
    protected List<string> IngredientesAdicionales { get; set; }
    protected decimal PrecioExtra { get; set; }

    public Hamburguesa(string tipoPan, string tipoCarne, decimal precioBase)
    {
        TipoPan = tipoPan;
        TipoCarne = tipoCarne;
        PrecioBase = precioBase;
        IngredientesAdicionales = new List<string>();
        PrecioExtra = 0;
    }

    public virtual void AgregarIngrediente(string ingrediente, decimal precioAdicional)
    {
        if (IngredientesAdicionales.Count < 4)
        {
            IngredientesAdicionales.Add(ingrediente);
            PrecioExtra += precioAdicional;
        }
    }

    public virtual void MostrarDetalles()
    {
        Console.WriteLine($"Hamburguesa {GetType().Name}:\n");
        Console.WriteLine($"Tipo de Pan: {TipoPan}\n");
        Console.WriteLine($"Tipo de Carne: {TipoCarne}\n");
        Console.WriteLine("Ingredientes Adicionales:");
        foreach (var ingrediente in IngredientesAdicionales)
        {
            Console.WriteLine($"    {ingrediente}");
        }
        Console.WriteLine($"Precio Base: {PrecioBase:c}\n");
        Console.WriteLine($"Precio Adicionales: {PrecioExtra:c}\n");
        Console.WriteLine($"Total: {PrecioBase + PrecioExtra:c}\n________________________________|\n\n\n\n\n");
    }
}

public class HamburguesaSaludable : Hamburguesa
{
    public HamburguesaSaludable(string tipoCarne, decimal precioBase)
        : base("Integral", tipoCarne, precioBase)
    {
    }

    public override void AgregarIngrediente(string ingrediente, decimal precioAdicional)
    {
        if (IngredientesAdicionales.Count < 6)
        {
            IngredientesAdicionales.Add(ingrediente);
            PrecioExtra += precioAdicional;
        }
    }
}

public class HamburguesaPremium : Hamburguesa
{
    public HamburguesaPremium(string tipoCarne, decimal precioBase)
        : base("Tradicional", tipoCarne, precioBase)
    {
        IngredientesAdicionales.Add("Papitas");
        IngredientesAdicionales.Add("Bebida");
        PrecioExtra += 3.65m;
    }

    public override void AgregarIngrediente(string ingrediente, decimal precioAdicional)
    {
        Console.WriteLine("No se permiten ingredientes adicionales en una hamburguesa premium.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("***---Chimi MiBarriga del Sr. Billy Navaja---***\n\n");
        Hamburguesa hamburguesaClasica = new Hamburguesa("Tradicional", "Res", 5.59m);
        hamburguesaClasica.AgregarIngrediente("Lechuga", 0.44m);
        hamburguesaClasica.AgregarIngrediente("Tomate", 0.77m);
        hamburguesaClasica.MostrarDetalles();

        Hamburguesa hamburguesaSaludable = new HamburguesaSaludable("Pollo", 6.52m);
        hamburguesaSaludable.AgregarIngrediente("Pepinillos", 0.50m);
        hamburguesaSaludable.MostrarDetalles();

        Hamburguesa hamburguesaPremium = new HamburguesaPremium("Res", 8.59m);
        hamburguesaPremium.MostrarDetalles();
    }
}
