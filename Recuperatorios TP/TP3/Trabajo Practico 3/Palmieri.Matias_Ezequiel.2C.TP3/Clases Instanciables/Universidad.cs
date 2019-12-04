using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region propiedades
        /// <summary>
        /// propiedad tanto get como set para la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// propiedad tanto get como set para la lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// propiedad tanto get como set para la lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        #endregion

        #region indexador
        /// <summary>
        /// indexador para la lista de jornadas
        /// </summary>
        /// <param name="i">indice de la jornada que buscas</param>
        /// <returns>jornada en especifica</returns>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        // Defino el indexador
        // public string this[int i]{ get{ returnpalabras[i]; }set{ palabras[i] = value; }}
        #endregion

        #region Constructor
        /// <summary>
        /// constructor sin parametros
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region metodos

        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni">universidad a ser guardada</param>
        /// <returns>true si funciono</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool retorno = false;
            try
            {
                string[] aux = Regex.Split(Directory.GetCurrentDirectory(), @"\\Palmieri.Matias_Ezequiel.2C.TP3");
                aux[0] += "\\Universidad.xml";
                //string fileName = AppDomain.CurrentDomain.BaseDirectory + "PruebaDeGuardarUniversidad.xml";

                retorno = xml.Guardar(aux[0], uni);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema posiblemente en texto.guardar fijate la inner", e);
            }
            return true;
        }

        /// <summary>
        /// Leer de clase retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns>una universidad con los datos ya cargados</returns>
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool retorno = false;
            Universidad uni = new Universidad();
            try
            {
                //string fileName = AppDomain.CurrentDomain.BaseDirectory + "PruebaDeGuardarUniversidad.xml";

                string[] aux = Regex.Split(Directory.GetCurrentDirectory(), @"\\Palmieri.Matias_Ezequiel.2C.TP3");
                aux[0] += "\\Universidad.xml";

                retorno = xml.Leer(aux[0],out uni);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema posiblemente en texto.guardar fijate la inner", e);
            }
            return uni;
        }


        /// <summary>
        /// MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <param name="uni">universidad a mostrar los datos</param>
        /// <returns>string con la informacion</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");

            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendFormat(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns>string con los datos REUTILIZO CODIGO</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g">campo en el cual vas a recorrer la lista de alumnos</param>
        /// <param name="a">alumno a buscar, si no figura se carga</param>
        /// <returns>true si se cargo al alumno false si no</returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach(Alumno aux in g.Alumnos)
            {
                if(aux == a)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">universidad a ver la listra</param>
        /// <param name="i">profesor a buscar si no figura se carga</param>
        /// <returns>true si se cargo false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor aux in g.Instructores)
            {
                if (aux == i)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// Sino, lanzará la Excepción SinProfesorException. 
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g">universidad a ver si algun profesor puede dar la clase</param>
        /// <param name="clases">la clase a buscar</param>
        /// <returns>el profesor capacitado para dar la clase</returns>
        public static Profesor operator ==(Universidad g, EClases clases)
        {
            Profesor profDeRetorno= null;
            bool flag = false;
            foreach (Profesor item in g.Instructores)
            {
                if(item == clases)
                {
                    profDeRetorno = item;
                    flag = true;
                    break;
                }
            }
            if(flag == false)
            {
                throw new SinProfesorException();
            }
            return profDeRetorno;
        }

        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no está inscripto en la universidad
        /// </summary>
        /// <param name="g">campo en el cual vas a recorrer la lista de alumnos</param>
        /// <param name="a">alumno a buscar, si no figura se carga</param>
        /// <returns>true si se cargo al alumno false si no</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">universidad a ver la listra</param>
        /// <param name="i">profesor a buscar si no figura se carga</param>
        /// <returns>true si se cargo false si no</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// Sino, lanzará la Excepción SinProfesorException. 
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g">universidad a ver si algun profesor puede dar la clase</param>
        /// <param name="clases">la clase a buscar</param>
        /// <returns>el primer profesor que no pueda dar la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clases)
        {
            Profesor profDeRetorno = null;
            
            foreach (Profesor item in g.Instructores)
            {
                if (!(item == clases))
                {
                    profDeRetorno = item;
                    break;
                }
            }
            
            return profDeRetorno;
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g">aca se agrega al alumno si no esta repetido</param>
        /// <param name="a">y este seria el alumno</param>
        /// <returns>la universidad o con un alumno mas o igual que como estaba</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                g.Alumnos.Add(a);
            }
           
            return g;
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g">aca se agrega al profesor si no esta repetido</param>
        /// <param name="i">y este seria el profesor</param>
        /// <returns>la universidad o con un profesor mas o igual que como estaba</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }


        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase,
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) 
        /// y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clases)
        {
            Profesor profesorAsignado = (g == clases);

            Jornada nuevaJornada = new Jornada(clases, profesorAsignado);
            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == clases)
                {
                    nuevaJornada = nuevaJornada + aux;
                }
            }
            g.Jornadas.Add(nuevaJornada);
           
            return g;
        }
        #endregion

        #region enumerado
        /// <summary>
        /// enumerado de clases
        /// </summary>
        public enum EClases
        {
            Programacion,Laboratorio,Legislacion,SPD
        }
        #endregion
    }
}
