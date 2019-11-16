using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        # region atributos de la clase
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion 

        #region Constructores
        /// <summary>
        /// Es el constructor publico de la clase Producto
        /// </summary>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;///Que pasa aca
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region Setters y getters
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo (esto estaba asi no se si es por algo puntual o que lo deje asi por las dudas yo le pondia que es un metodo abstracto y que por eso no lleva implementacion)
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region  Metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>un string con los datos del producto</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------PRODUCTO---------------\n ");
            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", this.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", this.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", this.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }


        //Que deveria hacer este metodo?
        //Sinceramente no entendi que buscan que haga este metodo por que en ningun lugar del codigo lo utilizan
        //voy a hacer que los datos de un producto los haga un string y lo voy a usar en el main para que vean que funciona
        //pero si el objetivo de este metodo era otro disculpen!
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("El codigo de barra es: {0} la marca es: {1} y posee {2} calorias\n", p.codigoDeBarras, p.marca, p.CantidadCalorias);
            
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">de esta variable va a comparar el codigo de barra</param>
        /// <param name="v2">de esta otra variable va a comparar el codigo de barra</param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;
            if(v1.codigoDeBarras == v2.codigoDeBarras)
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">de esta variable va a comparar el codigo de barra</param>
        /// <param name="v2">de esta otra variable va a comparar el codigo de barra</param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
            //return !(v1.codigoDeBarras == v2.codigoDeBarras); arreglo
        }
        #endregion

        #region enumerados
        /// <summary>
        /// Es un enumerado de tipos marcas 
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        #endregion
    }
}
