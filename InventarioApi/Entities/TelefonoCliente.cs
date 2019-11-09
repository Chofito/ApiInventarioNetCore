namespace InventarioApi.Entities
{
    public class TelefonoCliente
    {
        public int CodigoTelefono { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Nit { get; set; }
        public Cliente Cliente { get; set; }
    }
}