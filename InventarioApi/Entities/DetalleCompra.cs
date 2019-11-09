namespace InventarioApi.Entities
{
    public class DetalleCompra
    {
        public int IdDetalle { get; set; }
        public int IdCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Producto Producto { get; set; }
        public Compra Compra { get; set; }
    }
}