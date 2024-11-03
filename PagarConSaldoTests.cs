using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class PagarConSaldoTests
    {
        [Test]
        public void Test_PagarConSaldoSuficiente()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);

            Assert.AreEqual(1060, tarjeta.saldo);
        }

        [Test]
        public void Test_PagarConSaldoInsuficiente()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);
            colectivo.PagarCon(tarjeta);
            colectivo.PagarCon(tarjeta);

            Assert.AreEqual(120, tarjeta.saldo);
        }
    }
}

