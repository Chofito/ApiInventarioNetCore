namespace InventarioApi.Entities
{
    public class DetalleFactura
    {
        public int CodigoDetalle { get; set; }
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public Producto Producto { get; set; }
        public Factura Factura { get; set; }
    }
}