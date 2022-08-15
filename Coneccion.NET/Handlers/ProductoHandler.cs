using Coneccion.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace Coneccion.NET.Handlers
{

    public class ProductoHandler : DbHandler
    {



        public List<string> AbriryCerrarConexion()
        {
            //Creo lista de strings
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand
                    ("SELECT * FROM Producto", sqlConnection))
                {

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                descripciones.Add(dataReader.GetString(1));
                            }
                        }
                    }


                    sqlConnection.Close();

                }

                return descripciones;


            }

        }






        public List<string> GetTodaslasDescripcionesAdapter()
        {
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Productos", sqlConnection);

                sqlConnection.Open();


                DataSet result = new DataSet();
                sqlDataAdapter.Fill(result);

                sqlConnection.Close();




                return descripciones;


            }

        }


        public List<Product> GetProductos()
        {
            List<Product> productos = new List<Product>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Product producto = new Product();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUser = Convert.ToInt32(dataReader["IdUser"]);
                                producto.Cost = Convert.ToInt32(dataReader["Cost"]);
                                producto.SalesPrice = Convert.ToInt32(dataReader["SalesPrice"]);
                                producto.Description = dataReader["Description"].ToString();

                                productos.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return productos;
            }
        }



        public void Delete(int id)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @idProducto";

                    SqlParameter sqlParameter = new SqlParameter("idProducto", SqlDbType.BigInt);
                    sqlParameter.Value = id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteScalar(); // ejecutamos delete

                    }

                    sqlConnection.Close();
                }
            }catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


        public void Update(Product producto)
        {

            try
            {

                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Producto] SET (Descripciones, Costo, PrecioVenta,Stock,IdUsuario) VALUES(@Descripciones, @Costo, @PrecioVenta,@Stock,@IdUsuario);";

                    SqlParameter descripcionesParameter = new SqlParameter("Descripciones", SqlDbType.BigInt){Value = producto.Description};
                    SqlParameter costoParameter = new SqlParameter("Descripciones", SqlDbType.Int) { Value = producto.Cost };
                    SqlParameter precioParameter = new SqlParameter("Descripciones", SqlDbType.BigInt) { Value = producto.SalesPrice };
                    SqlParameter stokParameter = new SqlParameter("Descripciones", SqlDbType.BigInt) { Value = producto.Stock};
                    SqlParameter idUsuarioParameter = new SqlParameter("Descripciones", SqlDbType.BigInt) { Value = producto.IdUser};


                    sqlConnection.Open();

                    using(SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(descripcionesParameter);
                        sqlCommand.Parameters.Add(costoParameter);
                        sqlCommand.Parameters.Add(precioParameter);
                        sqlCommand.Parameters.Add(stokParameter);
                        sqlCommand.Parameters.Add(idUsuarioParameter);

                        sqlCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }



        public void Add(Product producto)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    string queryUpdate = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta,Stock,IdUsuario) VALUES(@Descripciones, @Costo, @PrecioVenta,@Stock,@IdUsuario);";

                    SqlParameter descripcionesParameter = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Description };
                    SqlParameter costoParameter = new SqlParameter("Costo", SqlDbType.Int) { Value = producto.Cost };
                    SqlParameter precioParameter = new SqlParameter("PrecioVenta", SqlDbType.Int) { Value = producto.SalesPrice };
                    SqlParameter stokParameter = new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock };
                    SqlParameter idUsuarioParameter = new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUser };


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(descripcionesParameter);
                        sqlCommand.Parameters.Add(costoParameter);
                        sqlCommand.Parameters.Add(precioParameter);
                        sqlCommand.Parameters.Add(stokParameter);
                        sqlCommand.Parameters.Add(idUsuarioParameter);

                        sqlCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }



    }

}