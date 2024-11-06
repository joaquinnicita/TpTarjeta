using System;
using BoletoNamespace;
using ColectivoNamespace;

namespace TarjetaNamespace
{
    public class MedioBoletoEstudiantil : MedioBoleto
    {
        public override int precioBoleto(int precio)
        {
            return base.precioBoleto(precio);
        }
    }
}
