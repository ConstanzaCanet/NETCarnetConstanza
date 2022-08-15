using Coneccion.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace Coneccion.NET.Handlers
{
    public class LogInHandler : DbHandler
    {
        public bool Login(string userName, string password)
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
                                User usuario = new User();
                                usuario.UserName = dataReader["UserName"].ToString();
                                usuario.Password = dataReader["Password"].ToString();         

                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                }






                
            }

        }
    }
}
