using ColectivoNamespace;
using NUnit.Framework;
using TarjetaNamespace;
using BoletoNamespace;

namespace Tests
{
    public class FranquiciaCompletaTest : FranquiciaCompleta
    {
        public override DateTime ObtenerFechaActual()
        {
            // Simula un lunes a las 4 PM
            return new DateTime(2023, 11, 6, 16, 0, 0);
        }
    }
    public class BoletoEducativoGratuitoTests
    {
        [Test]
        public void LimiteViajesGratisTests()
        {
            var boleto = new Boleto();
            var tarjeta = new FranquiciaCompletaTest(); // Usar la clase de prueba
            var colectivo = new Colectivo();

            tarjeta.cargarSaldo(9000);

            colectivo.PagarCon(tarjeta, boleto.precio);
            int primerViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, boleto.precio);
            int segundoViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, boleto.precio);
            int tercerViaje = tarjeta.saldo;  // precio completo

            Assert.AreEqual(9000, primerViaje, "El primer viaje debería ser gratuito.");
            Assert.AreEqual(9000, segundoViaje, "El segundo viaje debería ser gratuito.");
            Assert.AreEqual(9000 - 1200, tercerViaje, "El tercer viaje debería cobrar el precio completo.");
        }

        [Test]
        public void ViajesPosterioresTests()
        {
            var boleto = new Boleto();
            var tarjeta = new FranquiciaCompletaTest(); // Usar la clase de prueba
            var colectivo = new Colectivo();

            tarjeta.cargarSaldo(9000);

            colectivo.PagarCon(tarjeta, boleto.precio);
            int primerViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, boleto.precio);
            int segundoViaje = tarjeta.saldo;

            colectivo.PagarCon(tarjeta, boleto.precio);
            int tercerViaje = tarjeta.saldo;  // precio completo

            colectivo.PagarCon(tarjeta, boleto.precio);
            int cuartoViaje = tarjeta.saldo;  // precio completo

            Assert.AreEqual(9000, primerViaje, "El primer viaje deberá ser gratuito.");
            Assert.AreEqual(9000, segundoViaje, "El segundo viaje deberá ser gratuito.");
            Assert.AreEqual(9000 - 1200, tercerViaje, "El tercer viaje deberá cobrar el precio completo.");
            Assert.AreEqual(9000 - (1200 * 2), cuartoViaje, "El cuarto viaje deberá cobrar el precio completo.");
        }
    }
}
