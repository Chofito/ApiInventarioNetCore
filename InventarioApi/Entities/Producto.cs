using System.Collections.Generic;

namespace InventarioApi.Entities
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }


        public Categoria Categoria { get; set; }
        public TipoEmpaque TipoEmpaque { get; set; }
        public List<Inventario> Inventarios { get; set; }
        public List<DetalleCompra> DetalleCompras { get; set; }
        public List<DetalleFactura> DetalleFacturas { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioPorDocena { get; set; }
        public decimal PrecioPorMayor { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }
    }
}