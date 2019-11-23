namespace InventarioApi.Models
{
    public class DetalleCompraDTO
    {
        public int CodigoDetalle { get; set; }
        public int CodigoCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public ProductoDTO Producto { get; set; }
        public CompraDTO Compra { get; set; }
    }
}