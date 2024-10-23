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
            // Arrange
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(0);  // La tarjeta empieza con saldo 0

            // Act
            colectivo.PagarCon(tarjeta);  // Intentar pagar el boleto

            // Assert
            Assert.AreEqual(0, tarjeta.saldo, "El saldo no debería cambiar, ya que la tarjeta de Franquicia Completa no paga.");
        }



        [Test]
        public void Test_MedioBoletoPagaLaMitad()
        {
            // Arrange
            var tarjeta = new MedioBoleto();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(2000);  // Cargar saldo suficiente

            // Act
            colectivo.PagarCon(tarjeta);  // Pagar un boleto con Medio Boleto

            // Assert
            int saldoEsperado = 2000 - (940 / 2);  // El boleto cuesta la mitad, es decir 470
            Assert.AreEqual(saldoEsperado, tarjeta.saldo, "El saldo debería haberse descontado solo la mitad del boleto.");
        }


    }
}
