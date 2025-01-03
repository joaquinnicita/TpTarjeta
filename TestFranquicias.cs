using NUnit.Framework;
using System;
using TarjetaNamespace;

namespace TarjetaTests
{
    [TestFixture]
    public class TarjetaTests
    {
        private Tarjeta tarjetaRegular2;
        private MedioBoleto MedioBoleto;
        private FranquiciaCompleta FranquiciaCompleta;

        [SetUp]
        public void SetUp()
        {
            tarjetaRegular2 = new Tarjeta();
            MedioBoleto = new MedioBoletoTestable(new DateTime(2023, 11, 2, 15, 0, 0));
            FranquiciaCompleta = new FranquiciaCompletaTestable(new DateTime(2023, 11, 2, 15, 0, 0));
        }

        [Test]
        public void TestCargarSaldo_Exito()
        {
            tarjetaRegular2.cargarSaldo(2000);
            Assert.AreEqual(2000, tarjetaRegular2.saldo);
        }

        [Test]
        public void TestCargarSaldo_FalloMontoInvalido()
        {
            tarjetaRegular2.cargarSaldo(1500);
            Assert.AreEqual(0, tarjetaRegular2.saldo);
        }

        [Test]
        public void TestPrecioBoleto_MedioBoleto_DescuentoDentroHorario()
        {
            int precioFinal = MedioBoleto.precioBoleto(1200);
            Assert.AreEqual(600, precioFinal);
        }

        [Test]
        public void TestPrecioBoleto_MedioBoleto_PrecioNormalFueraHorario()
        {
            MedioBoleto = new MedioBoletoTestable(new DateTime(2023, 11, 2, 23, 0, 0));
            int precioFinal = MedioBoleto.precioBoleto(1200);
            Assert.AreEqual(1200, precioFinal);
        }

        [Test]
        public void TestPrecioBoleto_FranquiciaCompleta_DentroHorario()
        {
            int precioFinal = FranquiciaCompleta.precioBoleto(1200);
            Assert.AreEqual(0, precioFinal);
        }

        [Test]
        public void TestPrecioBoleto_FranquiciaCompleta_FueraHorario()
        {
            FranquiciaCompleta = new FranquiciaCompletaTestable(new DateTime(2023, 11, 2, 23, 0, 0));
            int precioFinal = FranquiciaCompleta.precioBoleto(1200);
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
