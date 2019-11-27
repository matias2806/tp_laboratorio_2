using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region constructor
        /// <summary>
        /// constructor sin parametros con mensaje en duro segun consigna numero 10
        /// </summary>
        public NacionalidadInvalidaException():this("Nacionalidad Invalida...")
        {

        }
        /// <summary>
        /// constructor con un mensaje como parametro
        /// </summary>
        /// <param name="mensaje">opcion de cargar lo que quieras en el mensaje</param>
        public NacionalidadInvalidaException(string mensaje) :base(mensaje)
        {
                
        }

        #endregion
    }
}
