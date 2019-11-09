using InventarioApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventarioApi.Contexts
{
    public class InventarioIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public InventarioIdentityContext(DbContextOptions<InventarioIdentityContext> options) : base(options)
        {
        }
    }
}