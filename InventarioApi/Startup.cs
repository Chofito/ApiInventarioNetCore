using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventarioApi.Contexts;
using InventarioApi.Entities;
using InventarioApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace InventarioApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.CreateMap<CategoriaCreacionDTO, Categoria>();
                options.CreateMap<TipoEmpaqueCreacionDTO, TipoEmpaque>();
                options.CreateMap<ClienteCreacionDTO, Cliente>();
                options.CreateMap<ProveedorCreacionDTO, Proveedor>();
                options.CreateMap<ProductoCreacionDTO, Producto>();
                options.CreateMap<FacturaCreacionDTO, Factura>();
                options.CreateMap<DetalleFacturaCreacionDTO, DetalleFactura>();
                options.CreateMap<CompraCreacionDTO, Compra>();
                options.CreateMap<DetalleCompraCreacionDTO, DetalleCompra>();
                options.CreateMap<EmailClienteCreacionDTO, Emailcliente>();
                options.CreateMap<EmailProveedorCreacionDTO, EmailProveedor>();
                options.CreateMap<InventarioCreacionDTO, Inventario>();
                options.CreateMap<TelefonoClienteCreacionDTO, TelefonoCliente>();
                options.CreateMap<TelefonoProveedorCreacionDTO, TelefonoProveedor>();
            });
            services.AddDbContext<InventarioDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddDbContext<InventarioIdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("authConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<InventarioIdentityContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                ClockSkew = TimeSpan.Zero
            }) ;
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder => builder.WithOrigins("*").WithMethods("*").WithHeaders("*"));

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}