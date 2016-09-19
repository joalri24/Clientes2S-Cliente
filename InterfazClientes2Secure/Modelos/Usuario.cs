using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure.Modelos
{
    /// <summary>
    /// Representación de un usuario de la aplicación. 
    /// Se utiliza normalmente para enviar querys de cambio de roles.
    /// </summary>
    public class Usuario
    {
        public string Email { get; set; }

        /// <summary>
        /// Roles separados por comas.
        /// </summary>
        public string Roles { get; set; }
    }
}
