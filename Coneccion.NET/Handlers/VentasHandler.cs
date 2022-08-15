using Coneccion.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace Coneccion.NET.Handlers
{
    public class VentasHandler : DbHandler
    {

        public List<Sale> GetTodosProductosVendidos()
        {
            List<Sale> ventas = new List<Sale>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Sale venta = new Sale();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Coments = dataReader["Comentarios"].ToString();
                               
                                ventas.Add(venta);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return ventas;
            }
        }
    }
}