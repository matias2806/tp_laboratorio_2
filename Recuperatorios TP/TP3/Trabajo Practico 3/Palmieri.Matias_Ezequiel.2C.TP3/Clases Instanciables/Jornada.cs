using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Archivos;


namespace Clases_Instanciables
{
    public class Jornada 
    {
        #region atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor profesor;
        #endregion 

        #region constructores
        /// <summary>
        /// Constructor sin parametros instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con un par de parametros
        /// </summary>
        /// <param name="clase">Le carga este parametro al atributo</param>
        /// <param name="instructor">Le carga este parametro al atributo</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region propiedades

        /// <summary>
        /// Propiedad get y set de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        
        /// <summary>
        /// prop get y set de clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// prop de get y set de profesor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.profesor; }
            set { this.profesor = value; }
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a ser guardada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            bool retorno = false;
            
            try {
                string[] aux = Regex.Split(Directory.GetCurrentDirectory(), @"\\Palmieri.Matias_Ezequiel.2C.TP3");
                aux[0] += "\\Jornada.txt";

                //esta linea me lo guarda en otra parte la dejo por las dudas
                //string fileName = AppDomain.CurrentDomain.BaseDirectory + "PruebaDeGuardarJornada.txt";

                retorno = texto.Guardar(aux[0], jornada.ToString());
            }
            catch(Exception e)
            {
                throw new Exception("Ocurrio un problema posiblemente en texto.leer fijate la inner", e);
            }
            return retorno; 
        }


        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns>Un string con los datos de una jornada</returns>
        public static string Leer()
        {
            string datosLeidos;
            Texto texto = new Texto();
            try {
                string[] aux = Regex.Split(Directory.GetCurrentDirectory(), @"\\Palmieri.Matias_Ezequiel.2C.TP3");
                aux[0] += "\\Jornada.txt";
                //string fileName = AppDomain.CurrentDomain.BaseDirectory + "PruebaDeGuardarJornada.txt";
                texto.Leer(aux[0], out datosLeidos);
            }
            catch(Exception e)
            {
                throw new Exception("Ocurrio un problema posiblemente en texto.leer fijate la inner", e);
            }

            return datosLeidos;
        }


        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns>Un string con la informacion de una jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR NOMBRE COMPLETO: {1}, {2}\n", this.Clase, this.Instructor.Nombre, this.Instructor.Apellido);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Instructor.Nacionalidad);


            sb.AppendFormat("{0}\n", this.Instructor.ToString());
            sb.AppendLine("\nAlumnos: \n");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendFormat(item.ToString()); //controlar que esto ande
                sb.AppendLine("\n\n");
            }

            return sb.ToString();
        }
        #endregion

        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true en caso que sean iguales</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            if(a == j.Clase)
            {
                retorno = true;
            }

            /*
            foreach (Alumno item in j.Alumnos)
            {
                if(a == item)
                {
                    retorno = true;
                }
            }*/
            return retorno;
        }

        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true en caso que no sean iguales</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">jornada aca se va a recorrer que en la lista de alumnos no figure el alumno y en caso positivo se lo agregara</param>
        /// <param name="a">alumno a ser agregado</param>
        /// <returns></returns>
        public static Jornada operator + (Jornada j, Alumno a)
        {
            bool flag = false;
            foreach(Alumno aux in j.Alumnos)
            {
                if(aux == a)
                {
                    flag = true;
                }
            }
            if(flag == false)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        #endregion
    }
}
