using pry_ventas_ds505.Models;
using Microsoft.EntityFrameworkCore;

namespace pry_ventas_ds505.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Producto> Producto { get; set; }
    
}
}
