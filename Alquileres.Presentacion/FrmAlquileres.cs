using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alquileres.Clientes1.Models;
using Alquileres.Clientes1.Servicios;

namespace Alquileres.Presentacion
{
    public partial class FrmAlquileres : Form
    {
        // Servicio utilizado para comunicarse con la API
        private ApiService apiService;

        // Lista de propiedades obtenidas desde el servidor.
        private List<Propiedad> propiedades = new List<Propiedad>();

        public FrmAlquileres()
        {
            InitializeComponent();
            // Crea el servicio para comunicarse con la API.
            apiService = new ApiService();
            // Ejecuta este método cuando se carga el formulario.
            this.Load += FrmAlquileres_Load;
            // Ejecuta este método cuando se presiona Registrar.
            btnRegistrar.Click += btnRegistrar_Click;
        }

        private async void FrmAlquileres_Load(object sender, EventArgs e)
        {
            await CargarPropiedades();
            await CargarAlquileres();
        }

        // Obtiene las propiedades desde la API.
        private async Task CargarPropiedades()
        {
            // Obtiene las propiedades o crea una lista vacía si no hay datos.
            propiedades = await apiService.ObtenerPropiedades()
               ?? new List<Propiedad>();

            // Limpia el ComboBox.
            cmbPropiedad.Items.Clear();

            foreach (var propiedad in propiedades)
            {
                if (propiedad.Estado == "Disponible")
                {
                    // Agrega el ID y la dirección al ComboBox.
                    cmbPropiedad.Items.Add(
                        propiedad.Id + " - " + propiedad.Direccion);
                }
            }
        }

        // Obtiene los alquileres desde la API.
        private async Task CargarAlquileres()
        {
            var alquileres = await apiService.ObtenerAlquileres();

            if (alquileres != null)
            {
                // Muestra los alquileres en el DataGridView.
                DvgAlquileres.DataSource = alquileres;
            }
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Comprueba que se haya seleccionado una propiedad.
            if (cmbPropiedad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una propiedad.");
                return;
            }

            // Comprueba que se haya ingresado un cliente.
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente.");
                return;
            }

            string seleccion = cmbPropiedad.SelectedItem.ToString();

            // Extrae el Id de la propiedad.
            int idPropiedad = int.Parse(
                seleccion.Split('-')[0].Trim());

            // Crea un nuevo objeto alquiler.
            Alquiler alquiler = new Alquiler
            {
                PropiedadId = idPropiedad,
                Cliente = txtCliente.Text,
                FechaInicio = dtpFechaInicio.Value
            };

            try
            {
                await apiService.CrearAlquiler(alquiler);

                MessageBox.Show("Alquiler registrado correctamente.");

                // Limpia el campo del cliente.
                txtCliente.Clear();

                await CargarPropiedades();
                await CargarAlquileres();
            }
            catch (Exception ex)
            {
                // Muestra el error ocurrido.
                MessageBox.Show(ex.Message, "Error");
            }

        }

       
    }
}


