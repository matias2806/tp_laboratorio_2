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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1Str = txtNumero1.Text;
            string numero2Str = txtNumero2.Text;
            string operador = cmbOperador.Text;

            Numero n1 = new Numero(numero1Str);
            Numero n2 = new Numero(numero2Str);

            double resultado = Calculadora.Operar(n1, n2, operador);
            if(operador == "")
            {
                cmbOperador.Text = "+";
            }
            lblResultado.Text = resultado.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = "";
            lblResultado.Text = String.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            Numero n1 = new Numero();
            lblResultado.Text = n1.DecimalBinario(resultado);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            Numero n1 = new Numero();
            lblResultado.Text = n1.BinarioDecimal(resultado);
        }
    }
}
