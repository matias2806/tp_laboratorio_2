using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public interface IArchivo<T>
    {
        #region metodos
        /// <summary>
        /// METODO A SER IMPLEMENTADO POR AQUELLAS CLASES QUE HEREDEN ESTA INTERFAZ
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">datas a ser guardados</param>
        /// <returns>true funciono </returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// METODO A SER IMPLEMENTADO POR AQUELLAS CLASES QUE HEREDEN ESTA INTERFAZ
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">datas a ser retornados</param>
        /// <returns>true funciono </returns>
        bool Leer(string archivo,out T datos);
        #endregion
    }
}
