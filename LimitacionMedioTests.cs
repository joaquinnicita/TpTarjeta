using NUnit.Framework;
using System;
using System.Threading;
using TarjetaNamespace;
using ColectivoNamespace;

namespace Tests
{
    public class LimitacionMedioBoleto
    {
        [Test]
        public void Test_5Minutos()
        {
            var tarjeta = new MedioBoleto();
            tarjeta.cargarSaldo(2000); 

            bool primerViaje = tarjeta.TarjetaUsos(tarjeta);
            bool segundoViaje = tarjeta.TarjetaUsos(tarjeta);

            Assert.IsTrue(primerViaje, "El primer viaje debería estar permitido.");
            Assert.IsFalse(segundoViaje, "No debería permitir otro viaje antes de los 5 minutos.");
        }
        [Test]
        public void Test_ViajePermitidoDespuesDe5Minutos()
        {
            var tarjeta = new MedioBoleto();
            tarjeta.cargarSaldo(2000);

            bool primerViaje = tarjeta.TarjetaUsos(tarjeta);
            tarjeta.ultimoUso = DateTime.Now.AddMinutes(-5);
            bool segundoViaje = tarjeta.TarjetaUsos(tarjeta);

            Assert.IsTrue(segundoViaje, "Debería permitir realizar otro viaje despues de 5 minutos.");
        }

        [Test]
        public void Viajes4porDiaTest()
        {
            var tarjeta = new MedioBoleto();
            var colectivo = new Colectivo();
            tarjeta.cargarSaldo(9000);

            for (int i = 0; i < 4; i++)
            {
                colectivo.PagarCon(tarjeta);
                tarjeta.ultimoUso = DateTime.Now.AddMinutes(-5);
            }

            colectivo.PagarCon(tarjeta);  

            Assert.AreEqual(9000 - (470*4) - 940, tarjeta.saldo, "El test no deberia funcionar ya que la consigna no pide esta limitacion.");
        }

    }
}
