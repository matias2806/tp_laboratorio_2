using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException :Exception
    {
        #region constructores
        /// <summary>
        /// Constructor de la excepcion el mensaje es segun regla 10
        /// </summary>
        /// <param name="innerException">Se almacenara esta inner exception para que este a disposicion de ser usada</param>
        public ArchivosException(Exception innerException):base("Ocurrio un error trabajando con el archivo",innerException)
        {

        }
        #endregion
    }
}
