using NUnit.Framework;
using TarjetaNamespace;

namespace TarjetaTests
{
    [TestFixture]
    public class TarjetaTests
    {
        private tarjeta tarjetaRegular;

        [SetUp]
        public void SetUp()
        {
            tarjetaRegular = new tarjeta();
        }

        [Test]
        public void TestPrecioBoleto_Viajes1a29_TarifaNormal()
        {
            tarjetaRegular.viajesMensuales = 29;

            int precioFinal = tarjetaRegular.precioBoleto(1000);

            Assert.AreEqual(1000, precioFinal, "El precio debe ser tarifa normal para los viajes 1 a 29.");
        }

        [Test]
        public void TestPrecioBoleto_Viajes30a79_Descuento20Porciento()
        {
            tarjetaRegular.viajesMensuales = 30;

            int precioFinal = tarjetaRegular.precioBoleto(1000);

            Assert.AreEqual(800, precioFinal, "El precio debe tener un 20% de descuento para los viajes 30 a 79.");
        }

        [Test]
        public void TestPrecioBoleto_Viaje80_Descuento25Porciento()
        {
            tarjetaRegular.viajesMensuales = 79;

            int precioFinal = tarjetaRegular.precioBoleto(1000);

            Assert.AreEqual(750, precioFinal, "El precio debe tener un 25% de descuento en el viaje 80.");
        }

        [Test]
        public void TestPrecioBoleto_Viaje81_TarifaNormal()
        {
            tarjetaRegular.viajesMensuales = 81;

            int precioFinal = tarjetaRegular.precioBoleto(1000);

            Assert.AreEqual(1000, precioFinal, "El precio debe ser tarifa normal a partir del viaje 81.");
        }
    }
}
