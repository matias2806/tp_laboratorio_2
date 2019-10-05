using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region constructor
        /// <summary>
        /// constructor publico de la clase Dulce
        /// </summary>
        /// <param name="marca">utiliza el constructor del base (Producto)</param>
        /// <param name="patente">utiliza el constructor del base (Producto)</param>
        /// <param name="color">utiliza el constructor del base (Producto)</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) :base(codigo,marca,color)
        {
        }
        #endregion

        #region setter y getters
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muesta los datos de un Dulce y los datos de ese producto (ya que se llama a base)
        /// </summary>
        /// <returns>devuelve un string con los datos</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias); 
            sb.AppendLine("\n---------------------\n");

            return sb.ToString();
        }

#endregion
    }
}
