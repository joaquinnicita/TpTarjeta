using System;
using BoletoNamespace;

namespace TarjetaNamespace
{
    public class tarjeta
    {
        public int saldo;
        public int limite = 9900;
        public int ID = 123;
        public DateTime ultimaUso;
        public int usosDiario = 0;

        public void cargarSaldo(int monto)
        {
            if (monto <= limite && (monto == 2000 || monto == 3000 || monto == 4000 || monto == 5000 || monto == 6000 || monto == 7000 || monto == 8000 || monto == 9000))
            {
                saldo += monto;
            }
            else
            {
                Console.WriteLine("El monto no es valido");
            }
        }

        public virtual int precioBoleto(int precio)
        {
            return precio;
        }

        public bool TarjetaUsos(tarjeta t)
        {
            TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;
            if (t is MedioBoleto)
            {
                if (tiempoDesdeUltimoUso.TotalMinutes >= 5 && t.usosDiario >= 4)
                {
                    ultimaUso = DateTime.Now;
                    return true; // Puede usar la tarjeta
                }
                else
                {
                    return false; // No puede usar la tarjeta
                }
            }
            ultimaUso = DateTime.Now;
            return true; // Puede usar la tarjeta
        }


    }

    public class MedioBoleto : tarjeta
    {
        public override int precioBoleto(int precio)
        {
            return precio / 2; // Precio reducido a la mitad
        }
    }

    public class FranquiciaCompleta : tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (usosDiario < 3)
            {
                usosDiario++;
                return 0; // Primeros dos viajes son gratuitos
            }
            else
            {
                return precio; // Precio completo después de dos viajes
            }

        }
    }
}
