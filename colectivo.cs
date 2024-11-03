using System;
using TarjetaNamespace;
using BoletoNamespace;

namespace ColectivoNamespace
{
    public class colectivo
    {
        public string linea = "102 144";
        boleto boleto = new boleto();
        public virtual void PagarCon(tarjeta tarjeta, int precio)
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

            if (tarjeta.saldo >= precio - 480)
            {
                tarjeta.saldo -= precio;
                Console.WriteLine("Pago realizado con éxito.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }
        }

    }
}
