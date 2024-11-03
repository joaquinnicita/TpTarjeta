using System;
using TarjetaNamespace;
using BoletoNamespace;

namespace ColectivoNamespace
{
    public class colectivo
    {
        public string linea = "102 144";
        public bool esInterurbano = true;

        public virtual void PagarCon(tarjeta tarjeta, int precio)
        {
            // Ajustar el precio según el tipo de tarjeta
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

            // Verificar el saldo y realizar el pago
            if (tarjeta.saldo >= precio)
            {
                tarjeta.saldo -= precio; // Ajustar el saldo según el precio calculado
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
