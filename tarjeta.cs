
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
        public int usosDiario = 0;
        public int saldoPendiente = 0;
        public int viajesMensuales = 0;


        public void cargarSaldo(int monto)
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
                saldo += monto;
            }
        }


        public virtual int precioBoleto(int precio)
        {
            int precioFinal = precio;

            if (viajesMensuales >= 30 && viajesMensuales < 79)
            {
                precioFinal = (int)(precio * 0.8);
            }
            else if (viajesMensuales == 80|| viajesMensuales == 79 )
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
    

    public bool TarjetaUsos(tarjeta t)
        {
            TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;

        public bool TarjetaUsos(Tarjeta t)
        {

            TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;
            if (t is MedioBoleto)
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

        public bool LimitacionFranquicia(Tarjeta t)
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

    public class MedioBoleto : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            return base.precioBoleto(precio / 2);
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

    public class FranquiciaCompleta : Tarjeta
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
