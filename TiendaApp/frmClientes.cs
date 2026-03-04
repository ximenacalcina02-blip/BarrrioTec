using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaApp.Controllers;
using TiendaApp.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace TiendaApp
{
    public partial class frmClientes : Form
    {
        ClienteController controller = new ClienteController();
        int clienteSeleccionadoId = 0;
        public frmClientes()
        {
            InitializeComponent();
        }
        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = controller.ObtenerClientes();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente
            {
                Nombre = txtNombre.Text,
                NIT = txtNIT.Text
            };

            controller.Insertar(c);
            CargarClientes();
            Limpiar();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtNIT.Clear();
            clienteSeleccionadoId = 0;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                clienteSeleccionadoId = (int)fila.Cells["Id"].Value;
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtNIT.Text = fila.Cells["NIT"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente
            {
                Id = clienteSeleccionadoId,
                Nombre = txtNombre.Text,
                NIT = txtNIT.Text
            };

            controller.Actualizar(c);
            CargarClientes();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            controller.Eliminar(clienteSeleccionadoId);
            CargarClientes();
            Limpiar();
        }
    }
}
