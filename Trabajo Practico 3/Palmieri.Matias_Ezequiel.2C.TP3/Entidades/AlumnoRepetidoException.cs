using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoRepetidoException : Exception
    {
        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de la excepcion  tiene ese mensaje duro por la consigna num 10
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno Repetido")
        {

        }
        #endregion
    }
}
