using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaApp.Data;

namespace TiendaApp
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (SqlConnection conn = DbContext.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Clientes";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;
            }
        }

        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtNit.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbContext.Instance.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Clientes (Nombre, NIT) VALUES (@n, @nit)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@nit", txtNit.Text);
                cmd.ExecuteNonQuery();
            }

            CargarClientes();
            Limpiar();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un cliente primero.");
                return;
            }

            using (SqlConnection conn = DbContext.Instance.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Clientes SET Nombre=@n, NIT=@nit WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@nit", txtNit.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cliente actualizado correctamente.");
            CargarClientes();
            Limpiar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Primero debes seleccionar un cliente de la tabla para poder eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Aquí se detenía en silencio antes
            }

            // 2. Pedimos confirmación antes de borrar
            var confirmar = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente de la base de datos?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DbContext.Instance.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM Clientes WHERE Id=@id";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        // 3. Convertimos el ID a número entero (Int32)
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                        // 4. Ejecutamos y verificamos si se borró algo
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar. Es posible que el cliente ya no exista en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Refrescamos la tabla y limpiamos los cuadros de texto
                    CargarClientes();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    // Si hay un problema de conexión o permisos, lo atrapamos aquí
                    MessageBox.Show("Error de base de datos al intentar eliminar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvClientes.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtNit.Text = dgvClientes.Rows[e.RowIndex].Cells["NIT"].Value.ToString();
            }

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}