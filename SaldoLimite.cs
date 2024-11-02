using ColectivoNamespace;
using NUnit.Framework;
using TarjetaNamespace;
using BoletoNamespace;

namespace Tests
{
    public class TarjetaTests
    {
        [Test]
        public void SaldoExcedenteTests()
        {
            var tarjeta = new Tarjeta();

            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(2000);

            Assert.AreEqual(36000, tarjeta.saldo, "El saldo deber�a alcanzar el l�mite m�ximo permitido de 36000.");
            Assert.AreEqual(2000, tarjeta.saldoPendiente, "El excedente pendiente deber�a ser 2000.");
        }
        [Test]
        public void Test_ProcesarExcedenteDespuesDeViaje()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            var boleto = new Boleto();

            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(9000);
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta);
            tarjeta.cargarSaldo(2000);

            Assert.AreEqual(36000, tarjeta.saldo, "El saldo deber�a estar en el l�mite m�ximo de 36000.");
            Assert.AreEqual(3060, tarjeta.saldoPendiente, "Deber�a quedar 3060 pendiente despu�s de recargar el saldo al m�ximo.");
        }

    }
}
