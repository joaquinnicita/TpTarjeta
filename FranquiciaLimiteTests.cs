using ColectivoNamespace;
using NUnit.Framework;
using TarjetaNamespace;
using BoletoNamespace;

namespace Tests
{
    public class BoletoEducativoGratuitoTests
    {
        [Test]
        public void LimiteViajesGratisTests()
        {
            var boleto = new Boleto();
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new Colectivo();

            tarjeta.cargarSaldo(9000);

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int primerViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int segundoViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int tercerViaje = tarjeta.saldo;  // precio completo

            Assert.AreEqual(9000, primerViaje, "El primer viaje debería ser gratuito.");
            Assert.AreEqual(9000, segundoViaje, "El segundo viaje debería ser gratuito.");
            Assert.AreEqual(9000-940, tercerViaje, "El tercer viaje debería cobrar el precio completo.");
        }
        
        [Test]
        public void ViajesPosterioresTests()
        {
            var boleto = new Boleto();
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new Colectivo();

            tarjeta.cargarSaldo(9000);

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int primerViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int segundoViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int tercerViaje = tarjeta.saldo;  // precio completo

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int cuartoViaje = tarjeta.saldo;  // precio completo

            Assert.AreEqual(9000, primerViaje, "El primer viaje debería ser gratuito.");
            Assert.AreEqual(9000, segundoViaje, "El segundo viaje debería ser gratuito.");
            Assert.AreEqual(9000 - 940, tercerViaje, "El tercer viaje debería cobrar el precio completo.");
            Assert.AreEqual(9000 - 940*2, tercerViaje, "El cuarto viaje debería cobrar el precio completo.");

        }

    }
}
