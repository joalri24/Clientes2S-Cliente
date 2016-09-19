using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure.Modelos
{
    /// <summary>
    /// Representación de los datos que se van a enviar al servidor 
    /// para crear un nuevo usuario de la aplicación.
    /// </summary>
    public class NuevoUsuario
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
