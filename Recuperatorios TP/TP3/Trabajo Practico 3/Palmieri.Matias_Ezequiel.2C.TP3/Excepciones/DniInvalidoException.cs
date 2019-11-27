using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region ATRIBUTOS
        private static string mensajeBase = "DNI invalido....";
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor que llama a otro constructor propio
        /// </summary>
        public DniInvalidoException() : this(mensajeBase)
        {

        }

        /// <summary>
        /// Constructor que llama a otro constructor propio
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {

        }
        /// <summary>
        /// constructor que llama al base (EXCEPTION)
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {

        }

        /// <summary>
        /// constructor que llama al base (EXCEPTION)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
        #endregion

    }
}
