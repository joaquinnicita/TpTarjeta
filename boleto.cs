using System;
using System.Timers;
using TarjetaNamespace;
using ColectivoNamespace;

namespace BoletoNamespace
{
    public class boleto
    {
        public int precio = 2400;
        private Timer timer; 
        public DateTime Fecha { get; private set; }

        public boleto()
        {
            Fecha = DateTime.Now;
            InicializarTimer();
        }

        private void InicializarTimer()
        {
            timer = new Timer(60000);
            timer.Elapsed += ActualizarFecha;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void ActualizarFecha(object sender, ElapsedEventArgs e)
        {
            Fecha = DateTime.Now;
            Console.WriteLine($"Fecha actualizada: {Fecha.ToShortDateString()}, Hora: {Fecha.ToShortTimeString()}");
        }

        public void FechaDatos()
        {
            Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}, Hora: {Fecha.ToShortTimeString()}");
        }

        public void TipoTarjeta(tarjeta tarjeta)
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

            Console.WriteLine("ID de la tarjeta: " + tarjeta.ID);
            Console.WriteLine("Saldo de la tarjeta: " + tarjeta.saldo);
        }

        public void MostrarLinea(colectivo colectivo)
        {
            Console.WriteLine("Linea: " + colectivo.linea);
        }
    }
}
