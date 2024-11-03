using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class PagarConSaldoTests
    {
        [Test]
        public void Test_FranquiciaCompletaSiemprePuedePagar()
        {
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(0);

            colectivo.PagarCon(tarjeta);

            Assert.AreEqual(0, tarjeta.saldo, "El saldo no debería cambiar, ya que la tarjeta de Franquicia Completa no paga.");
        }



        [Test]
        public void Test_MedioBoletoPagaLaMitad()
        {
            var tarjeta = new MedioBoleto();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);

            int saldoEsperado = 2000 - (940 / 2); 
            Assert.AreEqual(saldoEsperado, tarjeta.saldo, "El saldo debería haberse descontado solo la mitad del boleto.");
        }


    }
}
