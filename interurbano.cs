namespace ColectivoNamespace
{
    public class ColectivoInterurbano : Colectivo
    {
        public string lineaInterurbana = "Interurbano";

        public override void PagarCon(Tarjeta tarjeta, int precio)
        {
            base.PagarCon(tarjeta, 2500);
        }
    }
}
