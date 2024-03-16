using System;
using System.Collections.Generic;

// Clase base para representar una llamada telefónica
abstract class Llamada
{
    public string NumeroOrigen { get; }
    public string NumeroDestino { get; }
    public int DuracionSegundos { get; }

    public Llamada(string origen, string destino, int duracion)
    {
        NumeroOrigen = origen;
        NumeroDestino = destino;
        DuracionSegundos = duracion;
    }

    // Método abstracto para calcular el coste de la llamada
    public abstract double CalcularCosto();
    
    // Método para mostrar información de la llamada
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Origen: {NumeroOrigen}, Destino: {NumeroDestino}, Duración: {DuracionSegundos} segundos");
    }
}

// Clase para representar llamadas locales
class LlamadaLocal : Llamada
{
    private const double CostoPorSegundo = 0.15;

    public LlamadaLocal(string origen, string destino, int duracion) : base(origen, destino, duracion)
    {
    }

    public override double CalcularCosto()
    {
        return DuracionSegundos * CostoPorSegundo;
    }

    public override void MostrarInformacion()
    {
        Console.Write("Llamada local - ");
        base.MostrarInformacion();
    }
}

// Clase para representar llamadas provinciales
class LlamadaProvincial : Llamada
{
    private double costoPorSegundo;

    public LlamadaProvincial(string origen, string destino, int duracion, double costo) : base(origen, destino, duracion)
    {
        costoPorSegundo = costo;
    }

    public override double CalcularCosto()
    {
        return DuracionSegundos * costoPorSegundo;
    }

    public override void MostrarInformacion()
    {
        Console.Write("Llamada provincial - ");
        base.MostrarInformacion();
    }
}

// Clase para la centralita telefónica
class Centralita
{
    private List<Llamada> llamadas;

    public Centralita()
    {
        llamadas = new List<Llamada>();
    }

    // Método para registrar una llamada en la centralita
    public void RegistrarLlamada(Llamada llamada)
    {
        llamadas.Add(llamada);
        llamada.MostrarInformacion();
    }

    // Método para obtener el número total de llamadas registradas
    public int ObtenerNumeroTotalLlamadas()
    {
        return llamadas.Count;
    }

    // Método para calcular la facturación total de todas las llamadas
    public double CalcularFacturacionTotal()
    {
        double total = 0;
        foreach (var llamada in llamadas)
        {
            total += llamada.CalcularCosto();
        }
        return total;
    }
}

class Practica2
{
    static void Main(string[] args)
    {
        Centralita centralita = new Centralita();

        // Registrando algunas llamadas
        centralita.RegistrarLlamada(new LlamadaLocal("123456789", "987654321", 120));
        centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 180, 0.20));
        centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 240, 0.25));
        centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 300, 0.30));

        // Mostrando informe
        Console.WriteLine($"Número total de llamadas registradas: {centralita.ObtenerNumeroTotalLlamadas()}");
        Console.WriteLine($"Facturación total: {centralita.CalcularFacturacionTotal()} euros");
    }
}
