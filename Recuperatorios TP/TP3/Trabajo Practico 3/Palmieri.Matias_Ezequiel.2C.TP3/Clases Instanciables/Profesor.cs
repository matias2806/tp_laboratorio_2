using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor sin parametros inicializa la cola y llama al metodo _randomclases
        /// </summary>
        public Profesor()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// constructor statico inicializa el atributo random estatitco
        /// </summary>
        static Profesor()
        {
            random = new Random();            
        }

        /// <summary>
        /// Constructor con varios parametros los mismos seran pasados a la clase de la que hereda
        /// </summary>
        /// <param name="id">campo a ser pasado por herencia</param>
        /// <param name="nombre">campo a ser pasado por herencia</param>
        /// <param name="apellido">campo a ser pasado por herencia</param>
        /// <param name="dni">campo a ser pasado por herencia</param>
        /// <param name="nacionalidad">campo a ser pasado por herencia</param>
        public Profesor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region metodos

        /// <summary>
        /// asignarán dos clases al azar al Profesor mediante el método randomClases.
        /// </summary>
        private void _randomClases()//ANDA
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(Enum.GetNames(typeof(Universidad.EClases)).Length));
        }

        /// <summary>
        /// asignarán dos clases al azar al Profesor mediante el método randomClases.
        /// </summary>
        /*private void _randomClases()//ANDA
        {
            for (int i = 0; i < 2; i++)
            {
                int opcion = random.Next(0, 3);
                switch (opcion)
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }*/

        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del profesor.
        /// </summary>
        /// <returns>cadena con los datos de profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            
            return sb.ToString();
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns>un string con los datos ACA REUTILIZO CODIGO</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region sobrecarga de operadores

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"> profesor a ver que clases puede dar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>true si esta capacitado para dar esa clase</returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"> profesor a ver que clases puede dar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>true si no esta capacitado para dar esa clase</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
