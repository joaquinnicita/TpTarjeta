using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class PagarConSaldoTests
    {
        [Test]
        public void Test_NoSaldoNegativo()
        {

            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(500);

            colectivo.PagarCon(tarjeta);
            Assert.GreaterOrEqual(tarjeta.saldo, 0, "La tarjeta no debería quedar con saldo negativo.");
        }


        [Test]
        public void Test_DescuentoDelSaldo()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);

            int saldoEsperado = 2000 - 940;
            Assert.AreEqual(saldoEsperado, tarjeta.saldo, "El saldo no se descontó correctamente.");
        }

    }
}
