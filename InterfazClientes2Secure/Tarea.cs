using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure
{
    public class Tarea
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------
        private const string URGENTE = "Urgente";
        private const string ATENCION = "Atención";
        private const string NORMAL = "Normal";
        private const string FINALIZADA = "Finalizada";

        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        public string Nombre;
        public string Descripcion;
        public DateTime Fecha;
        public string Estado;

        //TODO Contacto encargado


        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------

        public Tarea ()
        {
            Nombre = "Nueva tarea";
            Descripcion = "";
            Estado = NORMAL;
            Fecha = DateTime.Now;
        }

        public Tarea(string nombre)
        {
            Nombre = nombre;
            Estado = NORMAL;
            Descripcion = "";
            Fecha = DateTime.Now;
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

    }
}
