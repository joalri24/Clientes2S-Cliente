using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure
{
    /// <summary>
    /// Contiene información reevante de la sesión de usuario.
    /// Contiene datos como el token de acceso, los roloes del usuario, 
    /// el email, etc.
    /// </summary>
    public class Sesion
    {

        // -----------------------------------------
        // Propiedades
        // -----------------------------------------

        /// <summary>
        /// Id del rol de administrador.
        /// </summary>
        public const string ROL_ADMIN = "1";

        /// <summary>
        /// Id del rol de comercial.
        /// </summary>
        public const string ROL_COMERCIAL = "2";

        /// <summary>
        /// Nombre del rol de administrador.
        /// </summary>
        public const string ROL_ADMIN_NOMBRE= "Admin";

        /// <summary>
        /// Nombre del rol de comercial.
        /// </summary>
        public const string ROL_COMERCIAL_NOMBRE = "Comercial";


        // -----------------------------------------
        // Propiedades
        // -----------------------------------------
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }

        // Ids separados por comas. 
        /// <summary>
        /// Roles separados por comas. Cuando esta recibiendo los roles desde el servidor,
        /// recibe los ids, pero cuando esta enviando unquery al servidor envía los nombres.
        /// </summary>
        public string roles { get; set; }

    }
}
