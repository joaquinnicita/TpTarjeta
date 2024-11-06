using NUnit.Framework;
using System;
using TarjetaNamespace;
using ColectivoNamespace;
using BoletoNamespace;

namespace Tests
{
    public class LimitacionMedioBoleto
    {
        [Test]
        public void Test_5Minutos()
        {
            var tarjeta = new MedioBoleto();
            tarjeta.usosDiario = 0;
            tarjeta.cargarSaldo(2000);
            tarjeta.ultimaUso = new DateTime(2022, 11, 7, 4, 0, 0); // Lunes 4 AM

            bool primerViaje = tarjeta.TarjetaUsos();
            bool segundoViaje = tarjeta.TarjetaUsos();

            Assert.IsTrue(primerViaje, "El primer viaje debería estar permitido.");
            Assert.IsFalse(segundoViaje, "No debería permitir otro viaje antes de los 5 minutos.");
        }

        [Test]
        public void Test_ViajePermitidoDespuesDe5Minutos()
        {
            var tarjeta = new MedioBoleto();
            tarjeta.cargarSaldo(2000);

            bool primerViaje = tarjeta.TarjetaUsos();
            tarjeta.ultimaUso = DateTime.Now.AddMinutes(-5);
            bool segundoViaje = tarjeta.TarjetaUsos();

            Assert.IsTrue(segundoViaje, "Debería permitir realizar otro viaje después de 5 minutos.");
        }

        [Test]
        public void Viajes4porDiaTest()
        {
            var tarjeta = new MedioBoleto();
            tarjeta.cargarSaldo(9000);

            for (int i = 0; i < 4; i++)
            {
                tarjeta.TarjetaUsos();
                tarjeta.ultimaUso = DateTime.Now.AddMinutes(-5);
            }

            bool quintoViaje = tarjeta.TarjetaUsos();
            Assert.IsFalse(quintoViaje, "No debería permitir más de 4 viajes en un día.");
        }
    }
}
