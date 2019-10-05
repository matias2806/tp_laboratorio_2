using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        private ETipo tipo;

        #region Constructores
        /// <summary>
        /// constructor publico de la clase Snacks
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">utiliza el constructor del base (Producto)</param>
        /// <param name="patente">utiliza el constructor del base (Producto)</param>
        /// <param name="color">utiliza el constructor del base (Producto)</param>
        public Leche(EMarca marca, string patente, ConsoleColor color): base(patente, marca, color)
        {
            this.tipo = ETipo.Entera;
        }


        /// <summary>
        /// constructor publico de la clase Snacks
        /// </summary>
        /// <param name="marca">utiliza el constructor del base (Producto)</param>
        /// <param name="patente">utiliza el constructor del base (Producto)</param>
        /// <param name="color">utiliza el constructor del base (Producto)</param>
        /// <param name="tipo">va a ser guardado en el atributo tipo de la clase leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : this(marca, patente, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Setters y Getters
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muesta los datos de un leche y los datos de ese producto (ya que se llama a base)
        /// </summary>
        /// <returns>devuelve un string con los datos</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}\n", this.tipo.ToString());
            sb.AppendLine("\n---------------------\n");

            return sb.ToString();
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Es un enumerado de tipos de leches 
        /// </summary>
        public enum ETipo
        {
            Entera, Descremada
        }
        #endregion

    }
}
