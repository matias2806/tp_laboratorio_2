using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        #region dos test unitario que validen Excepciones ( hice 3 )
        /// <summary>
        /// Prueba que comprueba que se lanze correctamente la excepcion NacionalidadInvalidaException
        /// La nacionalidad escojida sera comparada contra el DNI 
        /// de 1 a 89999999 tiene que ser argentino y de 90000000 a 99999999 debe ser extanjero
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethod1NacionalidadInvalidaException()
        {
            Alumno alumno;
            alumno = new Alumno(1, "Matias", "Palmieri", "41079975", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Prueba que se lanze la excepcion DniInvalidoException
        /// valida que el numero ingresado en el DNI sea un numero y no una cadena de caracteres 
        /// o una mezcla de numeros y letras
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethod2DniInvalidoException()
        {
            Alumno alumno;
            alumno = new Alumno(2, "Leonel", "Messi", "410fgh75", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
        }


        /// <summary>
        /// prueba que se lanze la excepcion SinProfesorException cuando no hay un profesor
        /// dentro de una universidad que pueda dar una materia seleccionada
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestMethod3SinProfesorException()
        {
            Universidad universidad = new Universidad();
            Profesor profesor = universidad == Universidad.EClases.SPD;
        }
        #endregion

        #region Valide valor numerico

        /// <summary>
        /// Prueba que comprueba que el Dni ingresado sea ese y no sufra alteraciones
        /// </summary>
        [TestMethod]
        public void TestMethod4ValoresNumericos()
        {
            Alumno alumno = new Alumno(3, "Juan Roman", "Riquelme", "10101010", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Assert.AreEqual(10101010, alumno.DNI);

        }
        #endregion

        #region Validacion de valores no nulos

        /// <summary>
        /// Prueba que compueba que las listas de la universidad no sean null
        /// </summary>
        [TestMethod]
        public void TestMethod5NoNulos()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Jornadas);
        }
        #endregion


        #region Test Mios para controlar los cambio que hice en el codigo (Docente por favor no tener en cuenta)

        //TIENE QUE DAR FALSE
        [TestMethod]
        public void CompruebaLaSobrecargaIgualIgualAlumno()
        {
            Alumno a = new Alumno(1, "mati", "palmi", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            bool retorno = a == Universidad.EClases.Laboratorio;

            Assert.AreEqual(retorno, false);
        }

        //TIENE QUE DAR TRUE
        [TestMethod]
        public void CompruebaLaSobrecargaIgualIgualAlumno2()
        {
            Alumno a = new Alumno(1, "mati", "palmi", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(1, "mati", "palmi", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            bool retorno = a == Universidad.EClases.Laboratorio;
            bool retorno2 = a2 == Universidad.EClases.Laboratorio;

            Assert.AreEqual(retorno, true);
            Assert.AreEqual(retorno2, true);
        }

        [TestMethod]
        public void CompruebaLaSobrecargaDistintoAlumno()
        {
            Alumno a = new Alumno(1, "mati", "palmi", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
           
            bool retorno = a != Universidad.EClases.Legislacion;
            bool retorno2 = a != Universidad.EClases.Programacion;
            bool retorno3 = a != Universidad.EClases.SPD;

            Assert.AreEqual(retorno, true);
            Assert.AreEqual(retorno2, true);
            Assert.AreEqual(retorno3, true);
        }

        [TestMethod]
        public void CompruebaLaSobrecargaDistintoAlumno2()
        {
            Alumno a = new Alumno(1, "mati", "palmi", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);

            bool retorno = a != Universidad.EClases.Laboratorio;

            Assert.AreEqual(retorno, false);
        }

        [TestMethod]
        public void CompruebaLaSobrecargaDistintoAlumno3()
        {
            Alumno a = new Alumno(1, "mati", "palmi", "1234567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            Assert.AreEqual(a != Universidad.EClases.Laboratorio, false);
        }
#endregion

    }
}
