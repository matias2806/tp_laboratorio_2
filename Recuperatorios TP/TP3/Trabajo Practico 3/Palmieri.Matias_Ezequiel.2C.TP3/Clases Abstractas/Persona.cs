using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region construtores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor con algunos parametros
        /// </summary>
        /// <param name="nombre"> va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="apellido">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="nacionalidad">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parametros llama a otro constructor
        /// </summary>
        /// <param name="nombre">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="apellido">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="dni">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="nacionalidad">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor con parametros llama a otro constructor
        /// </summary>
        /// <param name="nombre">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="apellido">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="dni">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        /// <param name="nacionalidad">va a pasar por una propiedad y si es correcto se cargara en el atributo</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;   
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que valida la entrada de un apellido, debe ser solo letras pueden ser mayus o min y permite espacios
        /// para aquellas persona con doble apellido como ejem 'Palmieri Alvarez' 
        /// tambien no permite ingresar apellidos mayores a 100 caracteres
        /// </summary>
        public string Apellido{
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }


        /// <summary>
        /// Propiedad que valida la entrada de un nombre, debe ser solo letras pueden ser mayus o min y permite espacios
        /// para aquellos nombre compuesto o personas con 2 nombres
        /// como ejem 'Juan Carlos Alberto' tambien no permite ingresar Nombres mayores a 100 caracteres
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedades que permite obtener o colocar un DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.StringToDNI = value.ToString();
            }
        }
        /// <summary>
        /// Propiedad solo setter de un DNI utiliza un metodo que valida el DNI
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad getter y setter que te permite obtener o settear la nacionalidad de una Persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// ToString retornará los datos de la Persona.
        /// </summary>
        /// <returns> string con los datos de la persona</returns>
        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nombre: {0}", this.Nombre);
            sb.AppendFormat("\nApellido: {0}", this.apellido);
            sb.AppendFormat("\nNacionalidad: {0}", this.Nacionalidad);
            sb.AppendFormat("\nDNI: {0}",this.DNI);
            return sb.ToString();
        }

        /// <summary>
        /// Valida que el dato pasado sea correcto en el caso de que sea argentino debe ser mayor q 1 y menor que 89999999
        /// y en el caso de que sea extranjero debe ser mayor que 90000000 y menor que 99999999
        /// Este metodo puede lanzar un error del tipo "NacionalidadInvalidaException"
        /// </summary>
        /// <param name="nacionalidad">Campo a ser llamado para otra funcion</param>
        /// <param name="dato">Dato a validar que sea numerico y su cant de caracteres</param>
        /// <returns> el DNI ya validado o no</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            
            bool nacionalidadExcep = false; //True caso de que la nacionalidad este valida false tira excepcion
            if (this.Nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999 ||
                this.Nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                nacionalidadExcep = true;
            }

            
            if (nacionalidadExcep == false)
            {
                throw new NacionalidadInvalidaException("La Nacionalidad no se coicide con el numero de DNI");
            }

            return dato; 
        }


        /// <summary>
        /// Valida que el dato pasado sea un numero tambien valida la cantidad de caracteres permitidos un dni puede tener 7 o 8 caracteres
        /// Este metodo puede lanzar un error del tipo "DniInvalidoException"
        /// </summary>
        /// <param name="nacionalidad">Campo a ser llamado para otra funcion</param>
        /// <param name="dato">Dato a validar que sea numerico y su cant de caracteres</param>
        /// <returns> el DNI ya validado o no</returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int numero;
      
            bool funciono = int.TryParse(dato, out numero);
            //8 por si el dni es 40.000.000 y 7 por si es 4 millones ....
            //permite desde el DNI 1000000 hasta el 99999999
            if (funciono == true && dato.Count() <= 8 && dato.Count() >= 7)
            {
                try { 
                    numero = this.ValidarDni(nacionalidad, numero);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
            return numero;
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato">dato a ser validado</param>
        /// <returns> el nombre ya validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            string nombreValidado="";
            Regex regex = new Regex("^[a-z-A-Z- :\\S]+$");
            Match match = regex.Match(dato);
            if (match.Success && dato.Count() <= 100)
            {
                nombreValidado = dato;
            }
            return nombreValidado;
        }
        #endregion

        #region enumerado

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion
    }
}
