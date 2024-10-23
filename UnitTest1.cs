using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class PagarConSaldoTests
    {
        [Test]
        public void Test_TarjetaNoQuedaConSaldoNegativo()
        {
            // Arrange
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(500);  // Cargar un saldo insuficiente para pagar un boleto

            // Act
            colectivo.PagarCon(tarjeta);  // Intento de pagar con saldo insuficiente

            // Assert
            Assert.GreaterOrEqual(tarjeta.saldo, 0, "La tarjeta no debería quedar con saldo negativo.");
        }


        [Test]
        public void Test_DescuentoCorrectoDelSaldo()
        {
            // Arrange
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);  // Cargar saldo suficiente

            // Act
            colectivo.PagarCon(tarjeta);  // Pagar un boleto

            // Assert
            int saldoEsperado = 2000 - 940;  // Saldo esperado después del pago
            Assert.AreEqual(saldoEsperado, tarjeta.saldo, "El saldo no se descontó correctamente.");
        }

    }
}
