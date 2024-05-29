using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("servicios_adicionales")]
    public class ServiciosAdicionales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_servicio { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal precio { get; set; }

        [Required]
        public int id_reservacion { get; set; }

        [ForeignKey("id_reservacion")]
        public virtual Reservaciones Reservacion { get; set; }
    }
}