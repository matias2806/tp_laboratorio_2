using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesAbstractas
{
    public abstract class Universitario :Persona
    {
        #region atributos
        private int legajo;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Universitario():base()
        {

        }

        /// <summary>
        /// constructor con varios parametros llama a su herencia y le pasa varios campos
        /// </summary>
        /// <param name="legajo">campo para completar su propio atributo</param>
        /// <param name="nombre">campo para pasarselo a su padre</param>
        /// <param name="apellido">campo para pasarselo a su padre</param>
        /// <param name="dni">campo para pasarselo a su padre</param>
        /// <param name="nacionalidad">campo para pasarselo a su padre</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo overrideado
        /// </summary>
        /// <param name="obj">objeto a comparar el tipo el otro va a ser dis</param>
        /// <returns>true sin son iguales</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(ReferenceEquals(this.GetType(), obj.GetType() ))
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Método protegido y virtual MostrarDatos retornará todos los datos del Universitario
        /// </summary>
        /// <returns>un string con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("Legajo :{0}\n",this.legajo);
            sb.AppendFormat(base.ToString());
            
            return sb.ToString();
        }

        /// <summary>
        /// Método protegido y abstracto ParticiparEnClase.
        /// </summary>
        /// <returns>sin implentacion por ser un metodo abstracto</returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">universitario 1 a ser comparado</param>
        /// <param name="pg2">universitario 2 a ser comparado</param>
        /// <returns>true si son iguales</returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if(pg1.Equals(pg2) && (pg1.legajo ==pg2.legajo || pg1.DNI == pg2.DNI) )
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">universitario 1 a ser comparado</param>
        /// <param name="pg2">universitario 2 a ser comparado</param>
        /// <returns>true si son distintos</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
