namespace InventarioApi.Models
{
    public class ProductoDTO
    {
        public int CodigoProducto { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioPorDocena { get; set; }
        public decimal PrecioPorMayor { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public TipoEmpaqueDTO TipoEmpaque { get; set; }
    }
}