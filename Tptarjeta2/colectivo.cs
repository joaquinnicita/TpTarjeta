using System;
using TarjetaNamespace;

namespace ColectivoNamespace
{
    public class Colectivo
    {
        public string linea = "102 144";
        public bool esInterurbano = false;

        public virtual void PagarCon(Tarjeta tarjeta, int precio)
        {
            precio = tarjeta.precioBoleto(precio);

            if (tarjeta.saldo >= precio - 480)
            {
                tarjeta.saldo -= precio;
                Console.WriteLine("Pago realizado con éxito.");
                Console.WriteLine("Total abonado: " + precio);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }
        }
    }
}
