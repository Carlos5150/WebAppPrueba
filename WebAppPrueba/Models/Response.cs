namespace WebAppPrueba.Models
{
    public class Response
    {     
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Usuario Usuario { get; set; }
        public List<Usuario> listUsuario { get; set; }

    }
}
