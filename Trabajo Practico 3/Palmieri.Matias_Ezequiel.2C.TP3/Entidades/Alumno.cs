#region USINGS UTILIZADOS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using EntidadesAbstractas;
#endregion

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor con varios parametros llama a su clase base(universitario)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor con varios parametros llama a otro constructor propio(el de arriba)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, 
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)  :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns>Un string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine (base.MostrarDatos());
            sb.AppendFormat("Clase que toma: {0}", this.claseQueToma);
            sb.AppendFormat("\nEstado de Cuenta: {0}", this.estadoCuenta);

            return sb.ToString();
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns>Un string con las especificaciones solicitadas</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// ToString hará públicos los datos del Alumno.
        /// </summary>
        /// <returns>Un string con los datos REUTILIZA CODIGO LLAMANDO A MOSTRAR DATOS</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Un boleano true si se cumple la condicion</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = true;
            if(a.claseQueToma != clase)
            {
                retorno = false;
            }
            return retorno;
        }
        #endregion

        #region ENUMERADO
        public enum EEstadoCuenta
        {
            AlDia,Deudor,Becado
        }
        #endregion
    }
}
