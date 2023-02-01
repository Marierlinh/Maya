using System.ComponentModel.DataAnnotations;

namespace Maya_Modelos
{
    public class TipoAplicacion
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage =" El nombre es obligatorio")]
        public String Nombre { get; set; } 
    }
}
