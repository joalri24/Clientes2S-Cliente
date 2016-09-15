using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure
{
    public class Sesion
    {

        // -----------------------------------------
        // Propiedades
        // -----------------------------------------
        public const string ROL_ADMIN = "1";
        public const string ROL_COMERCIAL = "2";
        public const string ROL_ADMIN_NOMBRE= "Admin";
        public const string ROL_COMERCIAL_NOMBRE = "Comercial";


        // -----------------------------------------
        // Propiedades
        // -----------------------------------------
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }

        // Ids separados por comas. 
        public string roles { get; set; }

    }
}
