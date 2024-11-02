  using System;
  using TarjetaNamespace;
  using BoletoNamespace;

  namespace ColectivoNamespace
  {
      public class colectivo {
        public string linea = "102 144";
        public bool esInterurbano = true;
        boleto boleto = new boleto();
          public virtual void PagarCon (tarjeta tarjeta, int precio)
          {
              if (tarjeta.saldo >= precio - 480)
              {
                if (!esInterurbano)
                {
                    tarjeta.saldo -= precio;
                }
                else
                {
                    precio = 2400;
                    tarjeta.saldo -= precio;
                }
                  Console.WriteLine("Pago realizado con éxito.");
                  Console.WriteLine("Total abonado " + precio);
            }
              else
              {
                  Console.WriteLine("Saldo insuficiente!");
              }
          }              
          
      }
  }
