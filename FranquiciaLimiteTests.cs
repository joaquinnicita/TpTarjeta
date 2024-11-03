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
            var boleto = new boleto();
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new colectivo();

            tarjeta.cargarSaldo(9000);

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int primerViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int segundoViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int tercerViaje = tarjeta.saldo;  // precio completo

            Assert.AreEqual(9000, primerViaje, "El primer viaje deber�a ser gratuito.");
            Assert.AreEqual(9000, segundoViaje, "El segundo viaje deber�a ser gratuito.");
            Assert.AreEqual(9000 - 940, tercerViaje, "El tercer viaje deber�a cobrar el precio completo.");
        }

        [Test]
        public void ViajesPosterioresTests()
        {
            var boleto = new boleto();
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new colectivo();

            tarjeta.cargarSaldo(9000);
            tarjeta.usosDiario = 0;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int primerViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int segundoViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int tercerViaje = tarjeta.saldo;  // precio completo

            colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
            int cuartoViaje = tarjeta.saldo;  // precio completo

            Assert.AreEqual(9000, primerViaje, "El primer viaje debera ser gratuito.");
            Assert.AreEqual(9000, segundoViaje, "El segundo viaje debera ser gratuito.");
            Assert.AreEqual(9000 - 940, tercerViaje, "El tercer viaje debera cobrar el precio completo.");
            Assert.AreEqual(9000 - (940 * 2), cuartoViaje, "El cuarto viaje debera cobrar el precio completo.");

        }

    }
}
