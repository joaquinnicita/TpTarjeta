using NUnit.Framework;
using System;
using TarjetaNamespace;

namespace TarjetaTests
{
    [TestFixture]
    public class TarjetaTests
    {
        private Tarjeta tarjetaRegular;
        private MedioBoletoTestable medioBoleto;
        private FranquiciaCompletaTestable franquiciaCompleta;

        [SetUp]
        public void SetUp()
        {
            tarjetaRegular = new Tarjeta();
            medioBoleto = new MedioBoletoTestable(new DateTime(2023, 11, 2, 15, 0, 0));
            franquiciaCompleta = new FranquiciaCompletaTestable(new DateTime(2023, 11, 2, 15, 0, 0));
        }

        [Test]
        public void TestCargarSaldo_Exito()
        {
            tarjetaRegular.cargarSaldo(2000);
            Assert.AreEqual(2000, tarjetaRegular.saldo);
        }

        [Test]
        public void TestCargarSaldo_FalloMontoInvalido()
        {
            tarjetaRegular.cargarSaldo(1500);
            Assert.AreEqual(0, tarjetaRegular.saldo);
        }

        [Test]
        public void TestPrecioBoleto_MedioBoleto_DescuentoDentroHorario()
        {
            int precioFinal = medioBoleto.precioBoleto(1200);
            Assert.AreEqual(600, precioFinal);
        }

        [Test]
        public void TestPrecioBoleto_MedioBoleto_PrecioNormalFueraHorario()
        {
            medioBoleto = new MedioBoletoTestable(new DateTime(2023, 11, 2, 23, 0, 0));
            int precioFinal = medioBoleto.precioBoleto(1200);
            Assert.AreEqual(1200, precioFinal);
        }

        [Test]
        public void TestPrecioBoleto_FranquiciaCompleta_DentroHorario()
        {
            int precioFinal = franquiciaCompleta.precioBoleto(1200);
            Assert.AreEqual(0, precioFinal);
        }

        [Test]
        public void TestPrecioBoleto_FranquiciaCompleta_FueraHorario()
        {
            franquiciaCompleta = new FranquiciaCompletaTestable(new DateTime(2023, 11, 2, 23, 0, 0));
            int precioFinal = franquiciaCompleta.precioBoleto(1200);
            Assert.AreEqual(1200, precioFinal);
        }
    }

    public class MedioBoletoTestable : MedioBoleto
    {
        private DateTime fechaActual;

        public MedioBoletoTestable(DateTime fecha)
        {
            fechaActual = fecha;
        }

        public override DateTime ObtenerFechaActual()
        {
            return fechaActual;
        }
    }

    public class FranquiciaCompletaTestable : FranquiciaCompleta
    {
        private DateTime fechaActual;

        public FranquiciaCompletaTestable(DateTime fecha)
        {
            fechaActual = fecha;
        }

        public override DateTime ObtenerFechaActual()
        {
            return fechaActual;
        }
    }
}
