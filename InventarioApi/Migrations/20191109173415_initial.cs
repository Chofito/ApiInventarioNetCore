using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventarioApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodigoCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodigoCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Nit = table.Column<string>(nullable: false),
                    Dpi = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    CodigoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Pagina_Web = table.Column<string>(nullable: true),
                    ContactoPrincipal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.CodigoProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpaques",
                columns: table => new
                {
                    CodigoEmpaque = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpaques", x => x.CodigoEmpaque);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Emailclientes",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    Nit = table.Column<string>(nullable: true),
                    ClienteNit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emailclientes", x => x.CodigoEmail);
                    table.ForeignKey(
                        name: "FK_Emailclientes_Clientes_ClienteNit",
                        column: x => x.ClienteNit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Numerofactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ClienteNit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Numerofactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClienteNit",
                        column: x => x.ClienteNit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoClientes",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Nit = table.Column<string>(nullable: true),
                    ClienteNit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoClientes", x => x.CodigoTelefono);
                    table.ForeignKey(
                        name: "FK_TelefonoClientes_Clientes_ClienteNit",
                        column: x => x.ClienteNit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<int>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ProveedorCodigoProveedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_ProveedorCodigoProveedor",
                        column: x => x.ProveedorCodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailProveedor",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    CodigoProveedor = table.Column<int>(nullable: false),
                    ProveedorCodigoProveedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailProveedor", x => x.CodigoEmail);
                    table.ForeignKey(
                        name: "FK_EmailProveedor_Proveedores_ProveedorCodigoProveedor",
                        column: x => x.ProveedorCodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoProveedores",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CodigoProveedor = table.Column<int>(nullable: false),
                    ProveedoresCodigoProveedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoProveedores", x => x.CodigoTelefono);
                    table.ForeignKey(
                        name: "FK_TelefonoProveedores_Proveedores_ProveedoresCodigoProveedor",
                        column: x => x.ProveedoresCodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCategoria = table.Column<int>(nullable: false),
                    CodigoEmpaque = table.Column<int>(nullable: false),
                    CategoriaCodigoCategoria = table.Column<int>(nullable: true),
                    TipoEmpaqueCodigoEmpaque = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    PrecioPorDocena = table.Column<decimal>(nullable: false),
                    PrecioPorMayor = table.Column<decimal>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaCodigoCategoria",
                        column: x => x.CategoriaCodigoCategoria,
                        principalTable: "Categorias",
                        principalColumn: "CodigoCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_TipoEmpaques_TipoEmpaqueCodigoEmpaque",
                        column: x => x.TipoEmpaqueCodigoEmpaque,
                        principalTable: "TipoEmpaques",
                        principalColumn: "CodigoEmpaque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    RoleID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID1",
                        column: x => x.RoleID1,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompras",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    ProductoCodigoProducto = table.Column<int>(nullable: true),
                    CompraIdCompra = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompras", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Compras_CompraIdCompra",
                        column: x => x.CompraIdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Productos_ProductoCodigoProducto",
                        column: x => x.ProductoCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    CodigoDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Descuento = table.Column<decimal>(nullable: false),
                    ProductoCodigoProducto = table.Column<int>(nullable: true),
                    FacturaNumerofactura = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.CodigoDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_FacturaNumerofactura",
                        column: x => x.FacturaNumerofactura,
                        principalTable: "Facturas",
                        principalColumn: "Numerofactura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Productos_ProductoCodigoProducto",
                        column: x => x.ProductoCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    CodigoInventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoRegistro = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Entradas = table.Column<int>(nullable: false),
                    Salidas = table.Column<int>(nullable: false),
                    ProductoCodigoProducto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.CodigoInventario);
                    table.ForeignKey(
                        name: "FK_Inventarios_Productos_ProductoCodigoProducto",
                        column: x => x.ProductoCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorCodigoProveedor",
                table: "Compras",
                column: "ProveedorCodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CompraIdCompra",
                table: "DetalleCompras",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_ProductoCodigoProducto",
                table: "DetalleCompras",
                column: "ProductoCodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_FacturaNumerofactura",
                table: "DetalleFacturas",
                column: "FacturaNumerofactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_ProductoCodigoProducto",
                table: "DetalleFacturas",
                column: "ProductoCodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Emailclientes_ClienteNit",
                table: "Emailclientes",
                column: "ClienteNit");

            migrationBuilder.CreateIndex(
                name: "IX_EmailProveedor_ProveedorCodigoProveedor",
                table: "EmailProveedor",
                column: "ProveedorCodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteNit",
                table: "Facturas",
                column: "ClienteNit");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ProductoCodigoProducto",
                table: "Inventarios",
                column: "ProductoCodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaCodigoCategoria",
                table: "Productos",
                column: "CategoriaCodigoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoEmpaqueCodigoEmpaque",
                table: "Productos",
                column: "TipoEmpaqueCodigoEmpaque");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoClientes_ClienteNit",
                table: "TelefonoClientes",
                column: "ClienteNit");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoProveedores_ProveedoresCodigoProveedor",
                table: "TelefonoProveedores",
                column: "ProveedoresCodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID1",
                table: "UserRoles",
                column: "RoleID1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompras");

            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Emailclientes");

            migrationBuilder.DropTable(
                name: "EmailProveedor");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "TelefonoClientes");

            migrationBuilder.DropTable(
                name: "TelefonoProveedores");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "TipoEmpaques");
        }
    }
}
