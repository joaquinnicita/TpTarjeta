using System;
using TarjetaNamespace;
using BoletoNamespace;

namespace ColectivoNamespace
{
    public class Colectivo
    {
        public string linea = "102 144";
        public bool esInterurbano = false;

        public virtual void PagarCon(Tarjeta tarjeta, int precio)
        {
            if (tarjeta is MedioBoleto)
            {
                precio = ((MedioBoleto)tarjeta).precioBoleto(precio);
            }
            else if (tarjeta is FranquiciaCompleta)
            {
                precio = ((FranquiciaCompleta)tarjeta).precioBoleto(precio);
            }
            else
            {
                precio = tarjeta.precioBoleto(precio);
            }

            if (tarjeta.saldo + 480 >= precio)
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
