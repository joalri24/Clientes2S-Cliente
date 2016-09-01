using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazClientes2Secure
{
    public class Contacto
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        public string Nombre;
        public string Cargo;
        public string Telefono;
        public string Celular;
        public string Correo;
        public string Notas;
        public DateTime UltimoContacto;


        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------

        public Contacto()
        {
            UltimoContacto = DateTime.Now;
            Nombre = "Nuevo contacto";
            Cargo = "";
            Telefono = "";
            Celular = "";
            Correo = "";
            Notas = "";
        }

        public Contacto(string nombre)
        {
            UltimoContacto = DateTime.Now;
            Nombre = nombre;
            Cargo = "";
            Telefono = "";
            Celular = "";
            Correo = "";
            Notas = "";
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------
    }
}
