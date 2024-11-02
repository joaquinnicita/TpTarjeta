
using System;
using BoletoNamespace;

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
            }
            else
            {
                saldo += monto;
            }
        }


        public virtual int precioBoleto(int precio)
        {
            return precio;
        }


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

    }

    public class MedioBoleto : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            return precio / 2;
        }
    }

    public class FranquiciaCompleta : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            return 0;
        }
    }
}
