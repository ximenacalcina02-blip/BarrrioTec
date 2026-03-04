using System;
using System.Windows.Forms;
using TiendaApp.Controllers;
using TiendaApp.Models;

namespace TiendaApp.Views
{
    public partial class frmBusquedaArticulo : Form
    {
        private ArticuloController _controller;
        public Articulo ArticuloSeleccionado { get; private set; }

        public frmBusquedaArticulo()
        {
            InitializeComponent();
            _controller = new ArticuloController();
            
            [cite_start]
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(CerrarConEscape);
        }

        private void frmBusquedaArticulo_Load(object sender, EventArgs e)
        {
            [cite_start]
            txtBuscar.Focus();
            CargarGrilla("");
        }

        private void CargarGrilla(string filtro)
        {
            dgvArticulos.DataSource = _controller.BuscarArticulos(filtro);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text);
        }

        [cite_start]
        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ArticuloSeleccionado = (Articulo)dgvArticulos.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CerrarConEscape(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}