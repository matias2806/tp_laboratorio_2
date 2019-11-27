using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        //1. Realizar test que verifique que la lista de Paquetes del Correo esté instanciada.
        [TestMethod]
        public void ListaDePaquetesInstanciada()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c);
            Assert.IsNotNull(c.Paquete);

        }

        //2. Realizar test que verifique que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void ControlDeIDTrakingRepetido()
        {
            Correo correo = new Correo();
            Paquete paq1 = new Paquete("Calle Falsa","111-222-3333");
            Paquete paq2 = new Paquete("Calle Falsa", "111-222-3333");
            correo = correo + paq1;
            correo = correo + paq1;
        }

    }
}
