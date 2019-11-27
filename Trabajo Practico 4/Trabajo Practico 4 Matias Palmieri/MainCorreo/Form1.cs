using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Paquete paq = new Paquete(txtDireccion.Text, mtxtTrakingID.Text);
            paq.InformaEstado += paq_InformaEstado;

            try { 
                this.correo = this.correo + paq;
            }
            catch (TrackingIdRepetidoException excep)
            {
                MessageBox.Show(excep.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ActualizarEstados();
            }

        }

        public void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { // Llamar al método 
                ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquete)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }

        

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
            
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            
            if(elemento != null)
            {
                string aux = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = aux;
                aux.Guardar("salida.txt");
            }
        }

       

        private void MostrarToolStripMenuItem(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        


        /*
        protected override void Dispose(bool disposing)
        {

        }
        
        private void InitializeComponent()
        {

        }

         */


    }
}
