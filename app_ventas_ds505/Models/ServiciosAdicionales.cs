using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pry_ventas_ds505.Models
{
    [Table("servicios_adicionales")]
    public class ServiciosAdicionales
    {
        [Key]
        [Required(ErrorMessage = "Escriba número de ID")]
        [Display(Name = "Id del Servicio")]
        public int id_servicio { get; set; }

        [Required(ErrorMessage = "Escriba el Nombre")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        [Required(ErrorMessage = "Escriba el Precio")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "Escriba el ID de Reservación")]
        [Display(Name = "ID de Reservación")]
        public int id_reservacion { get; set; }

        //[ForeignKey("id_reservacion")]
        //public virtual reservacion reservacion { get; set; }
    }
}