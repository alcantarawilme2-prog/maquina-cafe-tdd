



using NUnit.Framework;

[TestFixture]
public class MaquinaCafeTests
{
    private MaquinaCafe _maquina;

    [SetUp]
    public void Inicializar() => _maquina = new MaquinaCafe();

    // TC-01: Insertar monedas
    [Test]
    public void InsertarMoneda_DebeAcumularSaldo()
    {
        _maquina.InsertarMoneda(25);
        Assert.That(_maquina.Saldo, Is.EqualTo(25));
    }

    // TC-02: Seleccionar bebida con saldo suficiente
    [Test]
    public void SeleccionarBebida_SaldoSuficiente_RetornaTrue()
    {
        _maquina.InsertarMoneda(100);
        var resultado = _maquina.SeleccionarBebida("Cafe");
        Assert.That(resultado, Is.True);
    }

    // TC-03: Saldo insuficiente
    [Test]
    public void SeleccionarBebida_SaldoInsuficiente_RetornaFalse()
    {
        _maquina.InsertarMoneda(50);
        var resultado = _maquina.SeleccionarBebida("Cafe");
        Assert.That(resultado, Is.False);
    }

    // TC-04: Devolver cambio correcto
    [Test]
    public void SeleccionarBebida_DevuelveCambioCorreto()
    {
        _maquina.InsertarMoneda(150);
        _maquina.SeleccionarBebida("Cafe");
        var cambio = _maquina.ObtenerCambio();
        Assert.That(cambio, Is.EqualTo(50));
    }

    // TC-05: Bebida no disponible lanza excepción
    [Test]
    public void SeleccionarBebida_BebidaNoExiste_LanzaArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _maquina.SeleccionarBebida("Jugo"));
    }

    // TC-06: Menú contiene 3 bebidas con precios correctos
    [Test]
    public void ObtenerMenu_RetornaTresBebidas_ConPreciosCorrectos()
    {
        var menu = _maquina.ObtenerMenu();
        Assert.That(menu.Count, Is.EqualTo(3));
        Assert.That(menu["Cafe"].Precio, Is.EqualTo(100));
        Assert.That(menu["Te"].Precio, Is.EqualTo(75));
        Assert.That(menu["Agua"].Precio, Is.EqualTo(50));
    }

    // TC-07: Devolver monedas reinicia saldo a cero
    [Test]
    public void DevolverMonedas_ReinicializaSaldo_AZero()
    {
        _maquina.InsertarMoneda(100);
        _maquina.DevolverMonedas();
        Assert.That(_maquina.Saldo, Is.EqualTo(0));
    }

    // TC-08: Stock agotado impide dispensar bebida
    [Test]
    public void SeleccionarBebida_StockAgotado_RetornaFalse()
    {
        for (int i = 0; i < 10; i++)
        {
            _maquina.InsertarMoneda(100);
            _maquina.SeleccionarBebida("Cafe");
        }
        _maquina.InsertarMoneda(100);
        var resultado = _maquina.SeleccionarBebida("Cafe");
        Assert.That(resultado, Is.False);
    }
}
