using System;
using TarjetaNamespace;
using ColectivoNamespace;
namespace BoletoNamespace
{

    public class Boleto
    {
        public int precio = 1200;
        public DateTime Fecha = DateTime.Now;

        public void FechaDatos()
        {
            Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}, Hora: {Fecha.ToShortTimeString()}");
        }

        public void TipoTarjeta(Tarjeta tarjeta)
        {
            if (tarjeta is MedioBoleto)
            {
                Console.WriteLine("La tarjeta es un Medio Boleto.");
            }
            else if (tarjeta is FranquiciaCompleta)
            {
                Console.WriteLine("La tarjeta es una Franquicia Completa.");
            }
            else
            {
                Console.WriteLine("La tarjeta es una Tarjeta Normal.");
            }
            Console.WriteLine("Total Abonado: " + tarjeta.precioBoleto(precio));
            Console.WriteLine("ID de la tarjeta: " + tarjeta.ID);
            Console.WriteLine("Saldo de la tarjeta: " + tarjeta.saldo);
        }

        public void MostrarLinea(Colectivo colectivo)
        {
            Console.WriteLine("Linea: " + colectivo.linea);
        }


    }
}
