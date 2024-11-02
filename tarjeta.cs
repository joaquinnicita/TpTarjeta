using System;
using BoletoNamespace;
using ColectivoNamespace;

namespace TarjetaNamespace
{
    public class tarjeta
    {
        public int saldo;
        public int limite = 36000;
        public int ID = 123;
        public DateTime ultimaUso;
        public int usosDiario = 0;
        public int saldoPendiente = 0;
        public int viajesMensuales = 0;

        public void cargarSaldo(int monto)
        {
            if (monto <= limite && (monto == 2000 || monto == 3000 || monto == 4000 || monto == 5000 || monto == 6000 || monto == 7000 || monto == 8000 || monto == 9000))
            {
                if (saldo + monto > limite)
                {
                    saldo = limite;
                    saldoPendiente = saldo + monto - limite;
                }
                else
                {
                    saldo += monto;
                }
            }
            else
            {
                Console.WriteLine("El monto no es valido");
            }
        }

        public virtual int precioBoleto(int precio)
        {
            int precioFinal = precio;

            if (viajesMensuales >= 30 && viajesMensuales <= 79)
            {
                precioFinal = (int)(precio * 0.8);
            }
            else if (viajesMensuales == 80)
            {
                precioFinal = (int)(precio * 0.75);
            }

            viajesMensuales++;
            return precioFinal;
        }

        public bool TarjetaUsos(tarjeta t)
        {
            TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;

            if (t is MedioBoleto || t is FranquiciaCompleta)
            {
                if (tiempoDesdeUltimoUso.TotalMinutes >= 5 && t.usosDiario >= 4)
                {
                    ultimaUso = DateTime.Now;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            ultimaUso = DateTime.Now;
            return true;
        }

        private bool EsHorarioValido()
        {
            DateTime ahora = DateTime.Now;
            return (ahora.DayOfWeek != DayOfWeek.Saturday && ahora.DayOfWeek != DayOfWeek.Sunday) &&
                   (ahora.TimeOfDay >= new TimeSpan(6, 0, 0) && ahora.TimeOfDay <= new TimeSpan(22, 0, 0));
        }

        public bool LimitacionFranquicia(tarjeta t)
        {
            if (t is FranquiciaCompleta && t.usosDiario >= 2)
            {
                return false;
            }
            else
            {
                t.usosDiario++;
                return true;
            }
        }
    }

    public class MedioBoleto : tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (!EsHorarioValido())
            {
                return precio;
            }
            return base.precioBoleto(precio / 2);
        }

        private bool EsHorarioValido()
        {
            DateTime ahora = DateTime.Now;
            return (ahora.DayOfWeek != DayOfWeek.Saturday && ahora.DayOfWeek != DayOfWeek.Sunday) &&
                   (ahora.TimeOfDay >= new TimeSpan(6, 0, 0) && ahora.TimeOfDay <= new TimeSpan(22, 0, 0));
        }
    }

    public class FranquiciaCompleta : tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (!EsHorarioValido())
            {
                return precio;
            }
            else
            {
                return 0;
            }
                
        }

        private bool EsHorarioValido()
        {
            DateTime ahora = DateTime.Now;
            return (ahora.DayOfWeek != DayOfWeek.Saturday && ahora.DayOfWeek != DayOfWeek.Sunday) &&
                   (ahora.TimeOfDay >= new TimeSpan(6, 0, 0) && ahora.TimeOfDay <= new TimeSpan(22, 0, 0));
        }
    }
}
