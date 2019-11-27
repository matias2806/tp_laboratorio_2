using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region propiedades
        public List<Paquete> Paquete
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region constructor
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item != null )
                {
                    if (item.IsAlive) { 
                        item.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// metodo de la interfaz IMostar desarrollado de forma explicita
        /// </summary>
        /// <param name="elemento">elemento del cual se le va a leer los datos</param>
        /// <returns>la cadena de string con los datos</returns>
        string IMostrar<List<Paquete>>.MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete item in ((Correo)elemento).Paquete)
            {
                sb.AppendLine(string.Format("{0} para {1}  ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            }
            return sb.ToString();
        }

        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// a. Controlar si el paquete ya está en la lista. En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        /// b.De no estar repetido, agregar el paquete a la lista de paquetes.
        /// c.Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        /// d.Ejecutar el hilo.
        /// </summary>
        /// <param name="c">Instancia de correo para usar la lista</param>
        /// <param name="p">Paquete que quiere ingresar a la lista</param>
        /// <returns>retorna el correo o con un paquete nuevo o tal como estaba</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool repetido = false;
            foreach (Paquete item in c.Paquete)
            {
                if(item == p) { 
                    repetido = true;
                }
            }


            if(repetido == false)
            {
                c.Paquete.Add(p);
                Thread nuevoHilo = new Thread(new ThreadStart(p.MockCicloDeVida) );
                nuevoHilo.Start();
                c.mockPaquetes.Add(nuevoHilo);
            }
            else
            {
                throw new TrackingIdRepetidoException("Paquete Repetido");
            }
            return c;
        }
        #endregion

    }
}
