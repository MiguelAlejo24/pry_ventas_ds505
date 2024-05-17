using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("tb_producto")]
    public class Producto
    {
        [Key]
        [Required(ErrorMessage = "Escriba el código del producto")]
        [StringLength(5)]
        [Display(Name = "Código Producto")]
        public string codigo_producto { get; set; }

        [Required(ErrorMessage = "Escriba el nombre del producto")]
        [StringLength(40)]
        [Display(Name = "Producto")]
        public string producto { get; set; }

        [Required(ErrorMessage = "Ingrese el stock disponible")]
        [Display(Name = "Stock Disponible")]
        public int stock_disponible { get; set; }

        [Required(ErrorMessage = "Ingrese el costo del producto")]
        [Display(Name = "Costo")]
        public double costo { get; set; }

        [Required(ErrorMessage = "Ingrese la ganancia del producto")]
        [Display(Name = "Ganancia")]
        public double ganancia { get; set; }

        [ForeignKey("tb_marca")]
        [Display(Name = "Código Marca")]
        public string producto_codigo_marca { get; set; }

        [ForeignKey("tb_categoria")]
        [Display(Name = "Código Categoría")]
        public string producto_codigo_categoria { get; set; }
    }
}
