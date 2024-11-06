using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;
using System;

namespace Tests
{
    public class PagarConSaldoTests
    {
        [Test]
        public void Test_FranquiciaCompletaSiemprePuedePagar()
        {
            var tarjeta = new FranquiciaCompleta();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.cargarSaldo(0);

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.AreEqual(0, tarjeta.saldo, "El saldo no debería cambiar, ya que la tarjeta de Franquicia Completa no paga.");
        }

        [Test]
        public void Test_MedioBoletoPagaLaMitad()
        {
            var tarjeta = new MedioBoletoTest();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta, boleto.precio);

            int saldoEsperado = 2000 - (1200 / 2);
            Assert.AreEqual(saldoEsperado, tarjeta.saldo, "El saldo debería haberse descontado solo la mitad del boleto.");
        }

    }

    public class MedioBoletoTest : MedioBoleto
    {
        public override DateTime ObtenerFechaActual()
        {
            // Establecer la fecha a un lunes a las 4 PM
            return new DateTime(2024, 11, 4, 16, 0, 0); 
        }
    }
}
