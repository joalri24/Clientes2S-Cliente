using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure
{
    public class Cliente
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        private const string ASOCIACION_DIRECTA = "Directo";
        private const string ASOCIACION_INTERMEDIARIO = "Por intermediario";


        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        public string Nombre;
        public string Comentarios;
        public string TipoAsociación;
        public string Pendientes;
        public bool HacerSeguimiento;

        public Contacto ContactoPrincipal;
        private IList<Tarea> tareas;
        private IList<Contacto> contactos;


        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------

        /// <summary>
        /// Crea un nuevo cliente con el nombre proporcionado.
        /// El tipo de asociación por defecto es el directo.
        /// </summary>
        /// <param name="nombreP"></param>
        public Cliente(string nombre)
        {
            Nombre = nombre;
            TipoAsociación = ASOCIACION_DIRECTA;
            Comentarios = "";
            Pendientes = "";
            HacerSeguimiento = true;
            contactos = new List<Contacto>();
            tareas = new List<Tarea>();
            ContactoPrincipal = null;
        }

        /// <summary>
        /// Crea un nuevo cliente con el nombre y el tipo de asociación proporcionados.
        /// </summary>
        /// <param name="nombreP"></param>
        /// <param name="asociacion"></param>
        public Cliente(string nombre, string asociacion)
        {
            Nombre = nombre;
            TipoAsociación = asociacion;
            Comentarios = "";
            Pendientes = "";
            HacerSeguimiento = true;
            contactos = new List<Contacto>();
            tareas = new List<Tarea>();
            ContactoPrincipal = null;
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------
    }
}
