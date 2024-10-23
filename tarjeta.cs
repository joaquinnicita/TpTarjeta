using System;
using BoletoNamespace;

namespace TarjetaNamespace
{
    public class Tarjeta
    {
        public int saldo = 0;
        public int cargas;
        public int limite = 9900;

        public void cargarSaldo(int monto)
        {
            if (monto <= limite && (monto == 2000 || monto == 3000 || monto == 4000 || monto == 5000 || monto == 6000 || monto == 7000 || monto == 8000 || monto == 9000))
            {
                saldo += monto;
                Console.WriteLine($"Saldo actual: {saldo}");

            }
            else
            {
                Console.WriteLine("El monto no es valido");
            }
        }
    }
}