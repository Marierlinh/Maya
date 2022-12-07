using Microsoft.AspNetCore.Identity;

namespace Maya.Models
{
    public class UsuarioAplicacion : IdentityUser
    {
        public string NombreCompleto { get; set; }
    }
}
