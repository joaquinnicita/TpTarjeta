using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class TipoBoletos
    {
        [Test]
        public void Test_Normal()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);

            Assert.That(tarjeta.saldo, Is.EqualTo(2000-940), "Es una tarjeta normal, el precio deberia ser completo (940)");
        }

        [Test]
        public void Test_MedioBoleto()
        {
            var tarjeta = new MedioBoleto();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);

            Assert.That(tarjeta.saldo, Is.EqualTo(2000 - 470), "Es un medio boleto, el precio deberia ser la mitad (470)");
        }

        [Test]
        public void Test_FranquiciaCompleta()
        {
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);

            Assert.That(tarjeta.saldo, Is.EqualTo(2000), "Es franquicia completa, el precio deberia ser 0");
        }
    }
}

