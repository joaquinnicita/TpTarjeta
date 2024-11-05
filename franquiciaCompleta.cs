using System;
using BoletoNamespace;
using ColectivoNamespace;

namespace TarjetaNamespace
{
    public class FranquiciaCompleta : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (usosDiario < 3 && EsHorarioValido())
            {
                usosDiario++;
                return 0;
            }
            return precio;
        }
    }
    public bool LimitacionFranquicia(Tarjeta t)
    {
        if (t is FranquiciaCompleta && usosDiario >= 2)
        {
            return false;
        }
        else
        {
            usosDiario++;
            return true;
        }
    }
}
