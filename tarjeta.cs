using System;
using BoletoNamespace;
using ColectivoNamespace;

namespace TarjetaNamespace
{
    public class Tarjeta
    {
        public int saldo;
        public int limite = 36000;
        public int ID = 123;
        public DateTime ultimaUso;
        public int usosDiario = 1;
        public int saldoPendiente = 0;
        public int viajesMensuales = 0;

        private readonly int[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

        public void cargarSaldo(int monto)
        {
            if (Array.Exists(cargasAceptadas, carga => carga == monto))
            {
                if (saldo < limite && saldoPendiente > 0)
                {
                    int espacioDisponible = limite - saldo;
                    if (saldoPendiente >= espacioDisponible)
                    {
                        saldo += espacioDisponible;
                        saldoPendiente -= espacioDisponible;
                    }
                    else
                    {
                        saldo += saldoPendiente;
                        saldoPendiente = 0;
                    }
                }

                int espacioRestante = limite - saldo;
                if (monto > espacioRestante)
                {
                    saldo = limite;
                    saldoPendiente += monto - espacioRestante;
                }
                else
                {
                    saldo += monto;
                }
            }
            else
            {
                Console.WriteLine("Carga no aceptada. Debe ser una de las siguientes cantidades: 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000.");
            }
        }

        public virtual int precioBoleto(int precio)
        {
            int precioFinal = precio;

            if (viajesMensuales >= 30 && viajesMensuales < 79)
            {
                precioFinal = (int)(precio * 0.8);
            }
            else if (viajesMensuales == 79 || viajesMensuales == 80)
            {
                precioFinal = (int)(precio * 0.75);
            }
            else
            {
                precioFinal = precio;
            }

            viajesMensuales++;
            return precioFinal;
        }

        public virtual DateTime ObtenerFechaActual()
        {
            return DateTime.Now;
        }

        protected bool EsHorarioValido()
        {
            DateTime ahora = ObtenerFechaActual();
            return (ahora.DayOfWeek != DayOfWeek.Saturday && ahora.DayOfWeek != DayOfWeek.Sunday) &&
                   (ahora.TimeOfDay >= new TimeSpan(6, 0, 0) && ahora.TimeOfDay <= new TimeSpan(22, 0, 0));
        }

        
    }
}
