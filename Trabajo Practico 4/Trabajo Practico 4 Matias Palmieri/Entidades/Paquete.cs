using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Delegado y Evento
        public event DelegadoEstado InformaEstado;

        public delegate void DelegadoEstado(Object sender, EventArgs e);
        #endregion

        #region propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region constructo
        public Paquete(string direccionEntrega, string trakingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trakingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region metodos
        /// <summary>
        /// hará que el paquete cambie de estado
        ///a. Colocar una demora de 4 segundos.
        ///b.Pasar al siguiente estado.
        ///c.Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        ///d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        ///e.Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            this.Estado = EEstado.EnViaje;
            this.InformaEstado.Invoke(this, EventArgs.Empty);
            Thread.Sleep(4000);
            this.Estado = EEstado.Entregado;
            this.InformaEstado.Invoke(this, EventArgs.Empty);
            PaqueteDAO.Insertar(this);
            
        }

        /// <summary>
        /// Muestra la informacion de un paquete y utiliza la interfaz generica IMostrar
        /// </summary>
        /// <param name="elemento">Elemento del cual se va a mostrar los datos</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete esta = (Paquete)elemento;
            return string.Format("{0} para {1}", esta.TrackingID, esta.DireccionEntrega);
            
        }


        /// <summary>
        /// Reutiliza el metodo MostrarDatos para hacer los dastos publicos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">Paquete 1 a ser comparado</param>
        /// <param name="p2">Paquete 2 a ser comparado</param>
        /// <returns>true si son iguales</returns>
        public static bool operator == (Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">Paquete 1 a ser comparado</param>
        /// <param name="p2">Paquete 2 a ser comparado</param>
        /// <returns>false si son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region enumerado
        public enum EEstado
        {
            Ingresado,EnViaje,Entregado
        }
        #endregion
    }
}
