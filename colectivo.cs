  using System;
  using TarjetaNamespace;
  using BoletoNamespace;

  namespace ColectivoNamespace
  {
      public class colectivo {
          boleto boleto = new boleto();
          public virtual void PagarCon (tarjeta tarjeta)
          {
              if (tarjeta.saldo >= tarjeta.precioBoleto(boleto.precio) - 480)
              {
                  tarjeta.saldo -= tarjeta.precioBoleto(boleto.precio);
                  Console.WriteLine("Pago realizado con éxito.");
              }
              else
              {
                  Console.WriteLine("Saldo insuficiente!");
              }
          }              
          
      }
  }
