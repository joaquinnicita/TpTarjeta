using NUnit.Framework;
using TarjetaNamespace;

namespace Tests
{
    public class TarjetaSaldosTests
    {
        [TestFixture]
        public class TarjetaTests
        {
            [Test]
            [TestCase(2000)]
            [TestCase(3000)]
            [TestCase(4000)]
            [TestCase(5000)]
            [TestCase(6000)]
            [TestCase(7000)]
            [TestCase(8000)]
            [TestCase(9000)]
            public void CargarSaldo_valido(int monto)
            {
                var tarjeta = new Tarjeta();

                tarjeta.cargarSaldo(monto);

                Assert.AreEqual(monto, tarjeta.saldo);
            }

            [Test]
            [TestCase(1000)]
            [TestCase(1500)]
            [TestCase(2500)]
            [TestCase(50000)]
            public void CargarSaldo_invalido(int monto)
            {
                var tarjeta = new Tarjeta();

                tarjeta.cargarSaldo(monto);

                Assert.AreEqual(0, tarjeta.saldo);
            }
        }
    }
}
