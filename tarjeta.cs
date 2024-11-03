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

        public bool TarjetaUsos(Tarjeta t)
        {
            TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;

            // Verificación para MedioBoleto
            if (t is MedioBoleto)
            {
                if (tiempoDesdeUltimoUso.TotalMinutes >= 5 && usosDiario < 4)
                {
                    ultimaUso = DateTime.Now;
<<<<<<< HEAD
=======
                    usosDiario++;
>>>>>>> origin/ResolucionConflictos
                    return true;
                }
                return false;
            }

            // Para otros tipos de tarjetas
            ultimaUso = DateTime.Now;
            return true;
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

        public bool LimitacionFranquicia(Tarjeta t)
        {
            if (t is FranquiciaCompleta && usosDiario >= 2)
            {
                return false;
            }
            else
            {
                usosDiario++;
                return true;
            }
        }
    }

    public class MedioBoleto : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (EsHorarioValido())
            {
                return (precio / 2);
            }
            return precio;
        }
    }

    public class FranquiciaCompleta : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (usosDiario < 3 && EsHorarioValido())
            {
<<<<<<< HEAD
                usosDiario++;
                return 0;
=======
                return 0; // Viaje gratis
>>>>>>> origin/ResolucionConflictos
            }
            return precio;
        }
    }



}

