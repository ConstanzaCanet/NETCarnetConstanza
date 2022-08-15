using Coneccion.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace Coneccion.NET.Handlers
{
    public class UsuarioHandler : DbHandler
    {


        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Usuario", sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {

                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    User user = new User();
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
                Console.WriteLine(ex.Message);
            }
          
            return users;

        }



        
        
        public void Delete(User user)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryDelete = "DELETE FROM Usuario WHERE Id = @idUsuario";

                    SqlParameter sqlParameter = new SqlParameter("idUsuario", SqlDbType.BigInt);
                    sqlParameter.Value = user.Id;


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteNonQuery();//ejecucion de delete
                    }

                    sqlConnection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        public void UpdatePassword(User user)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryUpdate = "UPDATE [SistemaGestion.[dbo].[Ususario] SET Contraseña = @nuevaContraseña WHERE Id = @idUsuario";



                    SqlParameter newPassword = new SqlParameter();
                    newPassword.ParameterName = "nuevaContraseña";
                    newPassword.SqlDbType = System.Data.SqlDbType.VarChar;
                    newPassword.Value = user.Password;

                    SqlParameter UserId = new SqlParameter();
                    UserId.ParameterName = "idUsuario";
                    UserId.SqlDbType = System.Data.SqlDbType.BigInt;
                    UserId.Value = user.Id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(newPassword);
                        sqlCommand.Parameters.Add(UserId);
                        sqlCommand.ExecuteNonQuery();//ejecucion de update
                    }

                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }





        public void Add(User user)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Usuarios] (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail);";


                    SqlParameter NombreParameter = new SqlParameter("Nombre", SqlDbType.BigInt) { Value = user.Name };
                    SqlParameter ApellidoParameter = new SqlParameter("Apellido", SqlDbType.Int) { Value = user.Lastname };
                    SqlParameter NombreUsuarioParameter = new SqlParameter("NombreUsuario", SqlDbType.BigInt) { Value = user.UserName };
                    SqlParameter PasswordParameter = new SqlParameter("Contraseña", SqlDbType.BigInt) { Value = user.Password };
                    SqlParameter MailParameter = new SqlParameter("Mail", SqlDbType.BigInt) { Value = user.Email };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(NombreParameter);
                        sqlCommand.Parameters.Add(ApellidoParameter);
                        sqlCommand.Parameters.Add(NombreUsuarioParameter);
                        sqlCommand.Parameters.Add(PasswordParameter);
                        sqlCommand.Parameters.Add(MailParameter);

                        sqlCommand.ExecuteScalar();
                    }

                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



    }
}
