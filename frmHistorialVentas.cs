using System;
using System.Windows.Forms;
using TiendaApp.Controllers;
using TiendaApp.Models;

namespace TiendaApp.Views
{
    public partial class frmHistorialVentas : Form
    {
        public frmHistorialVentas()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(CerrarConEscape);
        }

        [cite_start]
        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ventaId = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells["Id"].Value);
                
                frmDetalleVenta frmDetalle = new frmDetalleVenta(ventaId);
                frmDetalle.ShowDialog();
            }
        }

        [cite_start]
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CerrarConEscape(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close(); 
        }
    }
}