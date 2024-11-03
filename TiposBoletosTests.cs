using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class TarjetaTest : Tarjeta
    {
        protected override DateTime ObtenerFechaActual()
        {
            return new DateTime(2024, 11, 4, 16, 0, 0);
        }
    }

    public class TipoBoletos
    {
        [Test]
        public void Test_Normal()
        {
            var tarjeta = new TarjetaTest();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.That(tarjeta.saldo, Is.EqualTo(2000 - 1200), "Es una tarjeta normal, el precio deberia ser completo (1200)");
        }

        [Test]
        public void Test_MedioBoleto()
        {
            var tarjeta = new MedioBoletoTest();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.That(tarjeta.saldo, Is.EqualTo(2000 - 600), "Es un medio boleto, el precio deberia ser la mitad (600)");
        }

        [Test]
        public void Test_FranquiciaCompleta()
        {
            var tarjeta = new FranquiciaCompletaTest();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.That(tarjeta.saldo, Is.EqualTo(2000), "Es franquicia completa, el precio deberia ser 0");
        }
    }

    public class MedioBoletoTest : MedioBoleto
    {
        protected override DateTime ObtenerFechaActual()
        {
            return new DateTime(2024, 11, 4, 16, 0, 0);
        }
    }

    public class FranquiciaCompletaTest : FranquiciaCompleta
    {
        protected override DateTime ObtenerFechaActual()
        {
            return new DateTime(2024, 11, 4, 16, 0, 0);
        }
    }
}
