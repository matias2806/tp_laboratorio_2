using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Entidades;
using System.IO;

namespace Entidades
{
    public class Xml<T> :IArchivo<T>
    {
        #region METODOS IMPLEMENTADOS DE LA INTERFAZ

        /// <summary>
        /// Metodo implentado de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">ruta del archivo</param>
        /// <param name="datos">datos a ser guardado</param>
        /// <returns>true si funciono false si no</returns>
        public bool Guardar(string archivo, T datos)
        {
           
            try
            {
                using (XmlTextWriter writter = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    // Agrega algun texto al archivo.

                    ser.Serialize(writter, datos);
                }
            }
            catch (Exception e)
            {
                throw new Exception("error", e);
            }
            
                return true;
        }

        /// <summary>
        /// Metodo implentado de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">ruta del archivo</param>
        /// <param name="datos">datos a devolver es un parametro de tipo OUT</param>
        /// <returns>true si funciono false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            using (XmlTextReader reader = new XmlTextReader(archivo))
            {
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);
                    retorno = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return retorno;
        }
        #endregion
    }
}

