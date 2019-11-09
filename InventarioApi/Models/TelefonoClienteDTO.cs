namespace InventarioApi.Models
{
    public class TelefonoClienteDTO
    {
        public int CodigoTelefono { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Nit { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}