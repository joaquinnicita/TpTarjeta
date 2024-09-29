using System;
using TarjetaNamespace;
using ColectivoNamespace;
namespace BoletoNamespace {
  
public class boleto {
  public int precio = 2400;
  public DateTime Fecha = DateTime.Now;

  public void FechaDatos() {
    Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}, Hora: {Fecha.ToShortTimeString()}");
  }
  
  public void TipoTarjeta (tarjeta tarjeta)
  {
      if (tarjeta is MedioBoleto)
      {
          Console.WriteLine("La tarjeta es un Medio Boleto.");
          Console.WriteLine("El total abonado es: " + precio/2);
      }
      else if (tarjeta is FranquiciaCompleta)
      {
          Console.WriteLine("La tarjeta es una Franquicia Completa.");
        Console.WriteLine("El total abonado es: 0");
      }
      else
      {
          Console.WriteLine("La tarjeta es una Tarjeta Normal.");
          Console.WriteLine("El total abonado es: " + precio);
      }

    Console.WriteLine("ID de la tarjeta: " + tarjeta.ID);
    Console.WriteLine("Saldo de la tarjeta: " + tarjeta.saldo);
  }

  public void MostrarLinea(colectivo colectivo){
    Console.WriteLine("Linea: " + colectivo.linea);
  }
  
            
  }}


