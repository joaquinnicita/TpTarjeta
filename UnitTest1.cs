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
            // Arrange
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);  // Cargar un saldo suficiente para pagar un boleto

            // Act
            colectivo.PagarCon(tarjeta);

            // Assert
            Assert.AreEqual(1060, tarjeta.saldo);  // saldo = 1000 - 940 = 60
        }

        [Test]
        public void Test_PagarConSaldoInsuficiente()
        {
            // Arrange
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);  // Cargar un saldo insuficiente para pagar un boleto

            // Act
            colectivo.PagarCon(tarjeta);
            colectivo.PagarCon(tarjeta);
            colectivo.PagarCon(tarjeta);


            // Assert
            Assert.AreEqual(120, tarjeta.saldo);  // El saldo debería permanecer igual porque no puede pagar
        }
    }
}
