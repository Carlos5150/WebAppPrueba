using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using WebAppPrueba.Models;

namespace WebAppPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public UserController (IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public Response GetAllUser()
        {
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UsersConnection"));
            //SqlConnection connection = new SqlConnection(@"Server=LAPTOP-LRVPV01G;Database=Prueba;Trusted_Connection=True;TrustServerCertificate=true");
            Response response = new Response();
            DLCA dlca = new DLCA();
            response = dlca.GetAllUsers(connection);
            return response;
        }

        [HttpPost]
        [Route("AddUser")]
        public Response AddUser(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UsersConnection"));
            Response response = new Response();
            DLCA dlca = new DLCA();
            response = dlca.AddUsers(connection,usuario);
            return response;
        }

        [HttpPut]
        [Route("UpdateUser")]
        public Response UpdateUser(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UsersConnection"));
            Response response = new Response();
            DLCA dlca = new DLCA();
            response = dlca.UpdateUsers(connection, usuario);
            return response;
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public Response DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UsersConnection"));
            Response response = new Response();
            DLCA dlca = new DLCA();
            response = dlca.DeleteUsers(connection,id);
            return response;
        }
    }
}
