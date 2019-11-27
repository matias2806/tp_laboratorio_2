using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {

        /// <summary>
        /// Metodo de extension de string que guardará en un archivo de texto en el escritorio de la máquina.
        /// Si el archivo existe, agregará información en él.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo">nombre del archivo</param>
        /// <returns>booleano false si no funciono</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            StreamWriter sw = null;

            ///Directory.GetCurrentDirectory();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            StringBuilder sb = new StringBuilder();
            sb.Append(ruta);
            sb.AppendFormat("\\{0}", archivo);
            
            try
            {
                if (File.Exists(archivo)) { 
                    using (sw = new StreamWriter(sb.ToString(),true))
                    {
                        sw.WriteLine(texto);
                        retorno = true;
                    }
                }
                else
                {
                    using (sw = new StreamWriter(sb.ToString(),false))
                    {
                        sw.WriteLine(texto);
                        retorno = true;
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("Fallo en la carga del archivo ",e);
            }
            
            return retorno;
        }
    }
}
