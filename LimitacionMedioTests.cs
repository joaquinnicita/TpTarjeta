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

            Assert.IsTrue(primerViaje, "El primer viaje deber�a estar permitido.");
            Assert.IsFalse(segundoViaje, "No deber�a permitir otro viaje antes de los 5 minutos.");
        }
        [Test]
        public void Test_ViajePermitidoDespuesDe5Minutos()
        {
            var tarjeta = new MedioBoleto();
            tarjeta.cargarSaldo(2000);

            bool primerViaje = tarjeta.TarjetaUsos(tarjeta);
            tarjeta.ultimoUso = DateTime.Now.AddMinutes(-5);
            bool segundoViaje = tarjeta.TarjetaUsos(tarjeta);

            Assert.IsTrue(segundoViaje, "Deber�a permitir realizar otro viaje despu�s de 5 minutos.");
        }
    }
}
