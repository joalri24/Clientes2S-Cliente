using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    /// <summary>
    /// Representa un Cliente de 2Secure.
    /// </summary>
    public class Client
    {
        // ------------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------------

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// El tipo de asociación con el cliente. Normalmente es Directo o Por Intermediario.
        /// </summary>
        public string Association { get; set; }

        public string Comments { get; set; }

        public string Pendings { get; set; }

        public DateTime LastContact { get; set; }

        public string State { get; set; }

        // "Foreign Key"
        /// <summary>
        /// El Id del contacto principal de este cliente.
        /// </summary>
        public int MainContactId { get; set; }

        /// <summary>
        /// Indica si vale la pena o no hacer seguimiento a este cliente.
        /// </summary>
        public bool Follow { get; set; }

        public string ApplicationUserId { get; set; }

        /// <summary>
        /// El email del usuario dueño de este cliente.
        /// </summary>
        public string OwnerEmail { get; set; }


        // ------------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------------

        /// <summary>
        /// Establece los valor por defecto de un nuevo cliente. Dentro de estos
        /// estan la fecha del último contacto, el estado y el seguimniento.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="association"></param>
        public Client(string name, string association)
        {
            Name = name;
            Association = association;
            Comments = "";
            Pendings = "";
            Follow = true;
            LastContact = DateTime.Now;
            MainContactId = 0;
            State = "Normal";
        }

    }
}