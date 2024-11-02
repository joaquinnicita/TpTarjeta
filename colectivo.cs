
using System;
using TarjetaNamespace;
using BoletoNamespace;

namespace ColectivoNamespace
{
    public class Colectivo
    {
        public string linea = "102 144";
        Boleto boleto = new Boleto();
        public virtual void PagarCon(Tarjeta tarjeta, int precio)
        {
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
