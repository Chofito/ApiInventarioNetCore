namespace InventarioApi.Models
{
    public class DetalleFacturaCreacionDTO
    {
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
    }
}