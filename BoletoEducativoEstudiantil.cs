using System;
using BoletoNamespace;
using ColectivoNamespace;

namespace TarjetaNamespace
{
    public class BoletoEducativoEstudiantil : FranquiciaCompleta
    {
        public override int precioBoleto(int precio)
        {
            return base.precioBoleto(precio);
        }
    }
}
