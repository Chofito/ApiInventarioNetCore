using InventarioApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventarioApi.Contexts
{
    public class InventarioDBContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Emailcliente> Emailclientes { get; set; }
        public DbSet<EmailProveedor> EmailProveedores { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TelefonoCliente> TelefonoClientes { get; set; }
        public DbSet<TelefonoProveedor> TelefonoProveedores { get; set; }
        public DbSet<TipoEmpaque> TipoEmpaques { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public InventarioDBContext(DbContextOptions<InventarioDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categorias")
                .HasKey(x => x.CodigoCategoria);
            modelBuilder.Entity<Cliente>().ToTable("Clientes")
                .HasKey(x => x.Nit);
            modelBuilder.Entity<Compra>().ToTable("Compras")
                .HasKey(x => x.IdCompra);
            modelBuilder.Entity<DetalleCompra>().ToTable("DetalleCompras")
                .HasKey(x => x.IdDetalle);
            modelBuilder.Entity<DetalleFactura>().ToTable("DetalleFacturas")
                .HasKey(x => x.CodigoDetalle);
            modelBuilder.Entity<Emailcliente>().ToTable("Emailclientes")
                .HasKey(x => x.CodigoEmail);
            modelBuilder.Entity<EmailProveedor>().ToTable("EmailProveedor")
                .HasKey(x => x.CodigoEmail);
            modelBuilder.Entity<Factura>().ToTable("Facturas")
                .HasKey(x => x.Numerofactura);
            modelBuilder.Entity<Inventario>().ToTable("Inventarios")
                .HasKey(x => x.CodigoInventario);
            modelBuilder.Entity<Producto>().ToTable("Productos")
                .HasKey(x => x.CodigoProducto);
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores")
                .HasKey(x => x.CodigoProveedor);
            modelBuilder.Entity<Role>().ToTable("Roles")
                .HasKey(x => x.ID);
            modelBuilder.Entity<TelefonoCliente>().ToTable("TelefonoClientes")
                .HasKey(x => x.CodigoTelefono);
            modelBuilder.Entity<TelefonoProveedor>().ToTable("TelefonoProveedores")
                .HasKey(x => x.CodigoTelefono);
            modelBuilder.Entity<TipoEmpaque>().ToTable("TipoEmpaques")
                .HasKey(x => x.CodigoEmpaque);
            modelBuilder.Entity<User>().ToTable("Users")
                .HasKey(x => x.ID);
            modelBuilder.Entity<UserRole>().ToTable("UserRoles")
                .HasKey(x => x.RoleID);
            base.OnModelCreating(modelBuilder);
        }
    }
}