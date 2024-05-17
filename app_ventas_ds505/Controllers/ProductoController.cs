using pry_ventas_ds505.Models;
using Microsoft.AspNetCore.Mvc;
using pry_ventas_ds505.Data;

namespace pry_ventas_ds505.Controllers
{
    public class ProductoController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            IEnumerable<Producto> ListarProducto = _context.Producto;

            return View(ListarProducto);
        }
    }
}
