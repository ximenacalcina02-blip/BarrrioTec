using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TiendaApp.Data;
using TiendaApp.Models;

namespace TiendaApp.Controllers
{
    public class ArticuloController
    {
        public List<Articulo> BuscarArticulos(string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            [cite_start]
            using (SqlConnection conn = DbContext.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Precio, Stock FROM Articulos WHERE Nombre LIKE @f";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@f", "%" + filtro + "%");
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Articulo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Stock = Convert.ToInt32(reader["Stock"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}