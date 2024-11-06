using System;

namespace TarjetaNamespace
{
    public class MedioBoleto : Tarjeta
    {
        public override int precioBoleto(int precio)
        {
            if (EsHorarioValido())
            {
                return precio / 2;
            }
            return precio;
        }

        public bool TarjetaUsos()
        {
            TimeSpan tiempoDesdeUltimoUso = DateTime.Now - ultimaUso;

            if (tiempoDesdeUltimoUso.TotalMinutes >= 5 && usosDiario < 4)
            {
                ultimaUso = DateTime.Now;
                usosDiario++;
                return true;
            }
            return false;
        }
    }
}
