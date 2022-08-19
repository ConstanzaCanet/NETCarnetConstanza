using Coneccion.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace Coneccion.NET.Handlers
{
    public class LogInHandler : DbHandler
    {
        public User Login(string userName, string password)
        {
            User user = new User();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    // string querySerch = "SELECT FROM Usuario WHERE NombreUsuario=@userName and Contraseña=@password;";

                    SqlParameter sqlParameterUserName = new SqlParameter("userName", SqlDbType.VarChar);
                    sqlParameterUserName.Value = userName;

                    SqlParameter sqlParameterPassword = new SqlParameter("password", SqlDbType.VarChar);
                    sqlParameterPassword.Value = password;

                    using (SqlCommand sqlCommand = new SqlCommand(
                       "SELECT FROM Usuario WHERE NombreUsuario=@userName and Contraseña=@password;", sqlConnection))
                    {


                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    user.Id = Convert.ToInt32(dataReader["Id"]);
                                    user.UserName = dataReader["NombreUsuario"].ToString();
                                    user.Name = dataReader["Nombre"].ToString();
                                    user.Lastname = dataReader["Apellido"].ToString();
                                    user.Email = dataReader["Mail"].ToString();

                                }
                            }
                          
                        }

                        sqlConnection.Close();
                    }

                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
                                
            
            return user;


        }
    }
}
