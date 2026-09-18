using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using Alquileres.Clientes1.Servicios;
using Alquileres.Clientes1.Models;

namespace Alquileres.Presentacion
{
    public partial class FrmPropiedades : Form
    {
        // Servicio utilizado para comunicarse con la API.
        private ApiService apiService;

        public FrmPropiedades()
        {
            InitializeComponent();

            // Crea el servicio para comunicarse con la API.
            apiService = new ApiService();

            // Agrega las opciones de estado al ComboBox
            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Alquilada");

            // Selecciona "Disponible" por defecto.
            cmbEstado.SelectedIndex = 0;
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            var propiedades = await apiService.ObtenerPropiedades();

            if (propiedades != null)
            {
                // Muestra las propiedades en el DataGridView.
                dvgPropiedades.DataSource = propiedades;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crea una nueva propiedad con los datos del formulario.
            Propiedad propiedad = new Propiedad
            {
                Direccion = txtDireccion.Text,
                Tipo = txtTipo.Text,
                Habitaciones = int.Parse(txtHabitaciones.Text),
                Banios = int.Parse(txtBanios.Text),
                Precio = decimal.Parse(txtPrecio.Text),
                Estado = cmbEstado.Text
            };

            await apiService.CrearPropiedad(propiedad);

            MessageBox.Show("Propiedad registrada correctamente.");

            LimpiarCampos();

            var propiedades = await apiService.ObtenerPropiedades();

            // Actualiza el DataGridView.
            dvgPropiedades.DataSource = propiedades;
        }

        // Limpia los campos del formulario.
        private void LimpiarCampos()
        {
            txtDireccion.Clear();
            txtTipo.Clear();
            txtHabitaciones.Clear();
            txtBanios.Clear();
            txtPrecio.Clear();

            cmbEstado.SelectedIndex = 0;
        }
    }
}


