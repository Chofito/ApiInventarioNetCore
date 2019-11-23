namespace InventarioApi.Entities
{
    public class DetalleCompra
    {
        public int CodigoDetalle { get; set; }
        public int CodigoCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Producto Producto { get; set; }
        public Compra Compra { get; set; }
    }
}