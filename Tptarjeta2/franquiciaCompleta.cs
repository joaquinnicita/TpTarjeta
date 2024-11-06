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

        public bool LimitacionFranquicia()
        {
            if (usosDiario >= 2)
            {
                return false;
            }
            usosDiario++;
            return true;
        }
    }
}
