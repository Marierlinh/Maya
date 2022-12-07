using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maya.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Nombre del producto es requerido")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Descripcion Corta del producto es requerido")]
        public string DescripcionCorta { get; set; }

        [Required(ErrorMessage = "Descripcion Larga del producto es requerido")]
        public string DescripcionLarga { get; set; }

        [Required(ErrorMessage = "Precio del producto es requerido")]
        [Range(1,double.MaxValue, ErrorMessage ="El precio debe ser mayor a cero")]
        public double Precio { get; set; }

      
        public string? ImagenUrl { get; set; }

        //Foreign key

        public int CategoriaId { get; set; }
        
        [ForeignKey("CategoriaId")]
        public virtual Categoria? Categoria { get; set; }

        public int TipoAplicacionId { get; set; }

        [ForeignKey("TipoAplicacionId")]
        public virtual TipoAplicacion? TipoAplicacion { get; set; }
    }
}
