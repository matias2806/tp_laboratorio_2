using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region atributos
        List<Producto> productos;
        int espacioDisponible;
        #endregion

        #region enum
        /// <summary>
        /// Es un enumerado de tipos de productos 
        /// </summary>
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Es el constructor privado que inicializa la lista de productos ( siempre va a ser llamado)
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Reutiliza al constructor anterior y le setea los espacios disponibles
        /// </summary>
        /// <param name="espacioDisponible">variable que se va a guardar dentro del atributo espacioDisponible de la clase</param>
        public Changuito(int espacioDisponible) :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns>un string con los datos</returns>
        public override string ToString()   
        {

            return this.Mostrar(this, ETipo.Todos);
            /*
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", this.productos.Count, this.espacioDisponible);
            sb.AppendLine("");
            for (int i = 0; i < this.productos.Count; i++)
            {
                if (this.productos[i] is Snacks)
                {
                    Snacks paraMostrarSnacks = (Snacks)this.productos[i];
                    sb.AppendLine(paraMostrarSnacks.Mostrar());
                }
                if (this.productos[i] is Dulce)
                {
                    Dulce paraMostrarDulce = (Dulce)this.productos[i];
                    sb.AppendLine(paraMostrarDulce.Mostrar());
                }
                if (this.productos[i] is Leche)
                {
                    Leche paraMostrarLeche = (Leche)this.productos[i];
                    sb.AppendLine(paraMostrarLeche.Mostrar());
                }
            }

            return sb.ToString();*/
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Producto item in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Dulce:
                        if(item is Dulce)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if (item is Leche)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    case ETipo.Snacks:
                        if (item is Snacks)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    
                    default:
                        sb.AppendLine(item.Mostrar());
                        break;
                }
            }

            /* CODIGO VIEJO
            for (int i = 0; i < c.productos.Count; i++) { 
                if (tipo == Changuito.ETipo.Dulce)
                {
                    if (this.productos[i] is Dulce)
                    {
                        Dulce paraMostrarDulce = (Dulce)this.productos[i];
                        sb.AppendLine(paraMostrarDulce.Mostrar());
                    }
                }
                if (tipo == Changuito.ETipo.Snacks)
                {
                    if (this.productos[i] is Snacks)
                    {
                        Snacks paraMostrarSnacks = (Snacks)this.productos[i];
                        sb.AppendLine(paraMostrarSnacks.Mostrar());
                    }
                }
                if (tipo == Changuito.ETipo.Leche)
                {
                    if (this.productos[i] is Leche)
                    {
                        Leche paraMostrarLeche = (Leche)this.productos[i];
                        sb.AppendLine(paraMostrarLeche.Mostrar());
                    }
                }
                if (tipo == Changuito.ETipo.Todos)
                {
                    c.ToString();
                }
            }*/
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>el objeto Changuito que fue pasado como param con el producto ya agregado o no segun corresponda</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            bool flag = false;
            flag = c.productos.Contains(p);
            if(flag == false && c.productos.Count < c.espacioDisponible)
            {
                c.productos.Add(p);
            }
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>el objeto Changuito que fue pasado como param con el producto ya quitado o no segun corresponda</returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(v);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
