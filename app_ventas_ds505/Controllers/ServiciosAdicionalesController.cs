using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pry_ventas_ds505.Data;
using pry_ventas_ds505.Models;

namespace pry_ventas_ds505.Controllers
{
    public class ServiciosAdicionalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiciosAdicionalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Listar()
        {
            string cad_sql = "exec sp_listar_servicios_adicionales";
            List<ServiciosAdicionales> arr_servicios = _context.ServiciosAdicionales.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_servicios });
        }

        [HttpGet]
        public JsonResult Consultar(int id_servicio)
        {
            string cad_sql = "EXEC sp_consultar_servicio_adicional @id_servicio";
            ServiciosAdicionales servicio = _context.ServiciosAdicionales
                .FromSqlRaw(cad_sql, new SqlParameter("@id_servicio", id_servicio))
                .AsEnumerable()
                .FirstOrDefault();
            return Json(servicio);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] ServiciosAdicionales servicio)
        {
            bool rpta = true;
            try
            {
                ServiciosAdicionales tmp_servicio = null;
                tmp_servicio = (from ser in _context.ServiciosAdicionales
                                where ser.id_servicio == servicio.id_servicio
                                select ser).FirstOrDefault();

                if (tmp_servicio == null)
                {
                    _context.ServiciosAdicionales.Add(servicio);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_servicio.nombre = servicio.nombre;
                    tmp_servicio.descripcion = servicio.descripcion;
                    tmp_servicio.precio = servicio.precio;
                    tmp_servicio.id_reservacion = servicio.id_reservacion;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }

        public JsonResult Borrar(int id_servicio)
        {
            bool rpta = true;
            try
            {
                ServiciosAdicionales servicio = new ServiciosAdicionales();
                servicio = (from ser in _context.ServiciosAdicionales
                            where ser.id_servicio == id_servicio
                            select ser).FirstOrDefault();

                if (servicio != null)
                {
                    _context.ServiciosAdicionales.Remove(servicio);
                    _context.SaveChanges();
                }
                else
                {
                    rpta = false;
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }
    }
}