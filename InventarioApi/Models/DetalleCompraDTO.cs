namespace InventarioApi.Models
{
    public class DetalleCompraDTO
    {
        public int IdDetalle { get; set; }
        public int IdCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public ProductoDTO Producto { get; set; }
        public CompraDTO Compra { get; set; }
    }
}