using System;
using TarjetaNamespace;
using BoletoNamespace;

namespace ColectivoNamespace
{
    public class Colectivo
    {
        Boleto boleto = new Boleto();
        public void PagarCon(Tarjeta tarjeta)
        {
            if (tarjeta.saldo >= boleto.precio)
            {
                tarjeta.saldo -= boleto.precio;
                Console.WriteLine("Pago realizado con éxito.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");

            }
        }
    }
}