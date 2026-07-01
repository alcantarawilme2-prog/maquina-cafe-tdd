

public record Bebida(string Nombre, int Precio, int Stock);

public class MaquinaCafe
{
    private int _saldo;
    private readonly Dictionary<string, Bebida> _menu;

    public int Saldo => _saldo;

    public MaquinaCafe()
    {
        _menu = new()
        {
            ["Cafe"] = new("Cafe", 100, Stock: 10),
            ["Te"] = new("Te", 75, Stock: 10),
            ["Agua"] = new("Agua", 50, Stock: 10),
        };
    }

    public void InsertarMoneda(int monto) => _saldo += monto;

    public bool SeleccionarBebida(string nombre)
    {
        var b = ObtenerBebidaOLanzar(nombre);
        if (_saldo < b.Precio || b.Stock == 0) return false;
        _saldo -= b.Precio;
        _menu[nombre] = b with { Stock = b.Stock - 1 };
        return true;
    }

    private Bebida ObtenerBebidaOLanzar(string nombre)
        => _menu.TryGetValue(nombre, out var b)
            ? b
            : throw new ArgumentException($"No existe la bebida: {nombre}");

    public int ObtenerCambio()
    {
        var cambio = _saldo;
        _saldo = 0;
        return cambio;
    }

    public void DevolverMonedas() => _saldo = 0;

    public Dictionary<string, Bebida> ObtenerMenu() => _menu;
}
 

// Feature de prueba - Anthony