using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Alquileres.Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario de propiedades.
            FrmPropiedades formulario = new FrmPropiedades();

            // Abre el formulario y espera hasta que se cierre.
            formulario.ShowDialog();
        }

        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario de alquileres.
            FrmAlquileres formulario = new FrmAlquileres();

            // Abre el formulario y espera hasta que se cierre.
            formulario.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación
            Application.Exit();
        }
    }
}




