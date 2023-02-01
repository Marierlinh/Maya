using Microsoft.AspNetCore.Identity;

namespace Maya_Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        public string NombreCompleto { get; set; }
    }
}
