namespace InventarioApi.Models
{
    public class EmailClienteDTO
    {
        public int CodigoEmail { get; set; }
        public string email { get; set; }
        public string Nit { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}