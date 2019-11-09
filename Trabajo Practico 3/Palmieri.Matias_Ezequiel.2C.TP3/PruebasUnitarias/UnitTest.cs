using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using EntidadesAbstractas;
namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest
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
    }
}
