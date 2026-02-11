using Microsoft.Data.SqlClient;
using System.Data;
namespace WebAppPrueba.Models
{
    public class DLCA
    {
        public Response GetAllUsers(SqlConnection connection)
        {
            Response response = new Response();
            using (SqlCommand cmd = new SqlCommand("ReadUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter("Select * from dbo.Usuario",connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                List<Usuario> lisUsuarios = new List<Usuario>();
                da.Fill(dt);

                if (dt.Rows.Count>0)
                {
                    for(int i = 0; 1 < dt.Rows.Count; i++)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        usuario.User = Convert.ToString(dt.Rows[i]["User"]);
                        usuario.Password = Convert.ToString(dt.Rows[i]["Password"]);
                        usuario.Status = Convert.ToBoolean(dt.Rows[i]["Status"]);
                        lisUsuarios.Add(usuario);

                    }

                }
                if (lisUsuarios.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "OK";
                    response.listUsuario = lisUsuarios;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No hay datos";
                    response.listUsuario = null;
                }

            }
                return response;
        }

        public Response AddUsers(SqlConnection connection,Usuario usuario)
        {
            Response response = new Response();
            using (SqlCommand cmd = new SqlCommand("CreateUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = usuario.Id;
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = usuario.User;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = usuario.Password;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = usuario.Status;
                connection.Open();
                var i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "OK insertado correctamente";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "dato no insertado";
                }
            }
            return response;
        }

        public Response UpdateUsers(SqlConnection connection, Usuario usuario)
        {
            Response response = new Response();
            using (SqlCommand cmd = new SqlCommand("UpdateUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = usuario.Id;
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = usuario.User;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = usuario.Password;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = usuario.Status;
                connection.Open();
                var i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "OK Actualizado correctamente";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "dato no Actualizado";
                }
            }
            return response;
        }

        public Response DeleteUsers(SqlConnection connection,int id)
        {
            Response response = new Response();
            using (SqlCommand cmd = new SqlCommand("UpdateUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;              
                connection.Open();
                var i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "OK borrado correctamente";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "dato no borrado";
                }
            }
            return response;
        }


    }
}
