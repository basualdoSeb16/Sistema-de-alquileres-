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
            // Validar dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.");
                txtDireccion.Focus();
                return;
            }

            // Validar tipo
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("El tipo de propiedad es obligatorio.");
                txtTipo.Focus();
                return;
            }

            // Validar habitaciones
            if (!int.TryParse(txtHabitaciones.Text, out int habitaciones))
            {
                MessageBox.Show("Ingrese una cantidad válida de habitaciones.");
                txtHabitaciones.Focus();
                return;
            }

            if (habitaciones <= 0)
            {
                MessageBox.Show("La cantidad de habitaciones debe ser mayor que cero.");
                txtHabitaciones.Focus();
                return;
            }

            // Validar baños
            if (!int.TryParse(txtBanios.Text, out int banios))
            {
                MessageBox.Show("Ingrese una cantidad válida de baños.");
                txtBanios.Focus();
                return;
            }

            if (banios <= 0)
            {
                MessageBox.Show("La cantidad de baños debe ser mayor que cero.");
                txtBanios.Focus();
                return;
            }

            // Validar precio
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                txtPrecio.Focus();
                return;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero.");
                txtPrecio.Focus();
                return;
            }

            // Crear la propiedad
            Propiedad propiedad = new Propiedad
            {
                Direccion = txtDireccion.Text,
                Tipo = txtTipo.Text,
                Habitaciones = habitaciones,
                Banios = banios,
                Precio = precio,
                Estado = cmbEstado.Text
            };

            try
            {
                // Enviar la propiedad a la API
                await apiService.CrearPropiedad(propiedad);

                MessageBox.Show("Propiedad registrada correctamente.");

                LimpiarCampos();

                // Actualizar el DataGridView
                var propiedades = await apiService.ObtenerPropiedades();

                if (propiedades != null)
                {
                    dvgPropiedades.DataSource = propiedades;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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


