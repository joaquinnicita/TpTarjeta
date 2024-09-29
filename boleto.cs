using System;
using TarjetaNamespace;
namespace BoletoNamespace {
  
public class boleto {
  public int precio = 2400;
  public DateTime Fecha = DateTime.Now;

  public void imprimirDatos(tarjeta tarjeta ) {
    Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}, Hora: {Fecha.ToShortTimeString()}, ID de la tarjeta: {tarjeta.ID}");
  }
  }}


