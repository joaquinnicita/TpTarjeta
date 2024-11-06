using System;
using BoletoNamespace;
using ColectivoNamespace;

namespace TarjetaNamespace
{
    public class MedioBoleto : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (EsHorarioValido())
            {
                return (precio / 2);
            }
            return precio;
        }
    }
    public bool TarjetaUsos(Tarjeta t)
    {
        TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;

        // Verificación para MedioBoleto
        if (t is MedioBoleto)
        {
            if (tiempoDesdeUltimoUso.TotalMinutes >= 5 && usosDiario < 4)
            {
                ultimaUso = DateTime.Now;
                return true;
            }
            return false; // No puede usar la tarjeta
        }

        // Para otros tipos de tarjetas
        ultimaUso = DateTime.Now;
        return true;
    }
}
