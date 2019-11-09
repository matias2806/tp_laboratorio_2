using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SinProfesorException : Exception
    {
        #region constructor
        /// <summary>
        /// constructor sin parametros con mensaje en duro segun consigna numero 10
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {

        }
        #endregion
    }
}
