using NUnit.Framework;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests1
{
    public class PagarConSaldoTests
    {
        [Test]
        public void Test_PagarConSaldoSuficiente()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.cargarSaldo(2000);

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.AreEqual(800, tarjeta.saldo);
        }

        [Test]
        public void Test_PagarConSaldoInsuficiente()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.saldo = 800;

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.AreEqual(-400, tarjeta.saldo);
        }

        [Test]
        public void Test_NoPermitirSaldoNegativoExcedente()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.saldo = -480;
            int precioBoleto = boleto.precio;

            colectivo.PagarCon(tarjeta, boleto.precio);

            Assert.IsTrue(tarjeta.saldo >= -480, "La tarjeta no debe tener un saldo negativo menor a -480.");
        }

        [Test]
        public void Test_DescuentoAdeudadoAlRecargar()
        {
            var tarjeta = new Tarjeta();
            var colectivo = new Colectivo();
            var boleto = new Boleto();
            tarjeta.saldo = -400;
            tarjeta.cargarSaldo(2000);


            Assert.AreEqual(2000 - 400, tarjeta.saldo, "El saldo debe descontar el saldo adeudado correctamente.");
        }
    }
}
