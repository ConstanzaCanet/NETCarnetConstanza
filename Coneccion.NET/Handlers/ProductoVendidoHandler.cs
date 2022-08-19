using Coneccion.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace Coneccion.NET.Handlers
{
    public class ProductoVendidoHandler : DbHandler
    {

        public List<soldProduct> GetTodosProductosVendidos( int id )
        {
            List<soldProduct> productosV = new List<soldProduct>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {


                SqlParameter sqlParameterPassword = new SqlParameter("id", SqlDbType.BigInt);
                sqlParameterPassword.Value = id;


                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                soldProduct productoVendido = new soldProduct();
                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProduct = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdSale = Convert.ToInt32(dataReader["IdVenta"]);
                                
                                productosV.Add(productoVendido);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return productosV;
            }
        }




    }

}