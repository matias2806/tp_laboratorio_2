using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructores
        /// <summary>
        /// constructor publico de la clase Snacks
        /// </summary>
        /// <param name="marca">utiliza el constructor del base (Producto)</param>
        /// <param name="patente">utiliza el constructor del base (Producto)</param>
        /// <param name="color">utiliza el constructor del base (Producto)</param>
        public Snacks(Producto.EMarca marca, string patente, ConsoleColor color): base(patente, marca, color)
        {
        }
        #endregion

        #region Setters y Getters
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muesta los datos de un Snacks y los datos de ese producto (ya que se llama a base)
        /// </summary>
        /// <returns>devuelve un string con los datos</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("\n---------------------\n");

            return sb.ToString();
        }
        #endregion
    }
}
