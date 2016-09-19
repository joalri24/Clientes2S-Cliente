using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    /// <summary>
    /// Representa un contacto Ciente de 2Secure.
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }

        // Foreign Key
        /// <summary>
        /// El id del cliente que esta asociado con este contacto
        /// </summary>
        public int ClientId { get; set; }

        // Navigation property
        public Client Client { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public string Telephone { get; set; }

        public string Mail { get; set; }

        public DateTime LastContact { get; set; }

        public string Notes { get; set; }

        /// <summary>
        /// El id del usuario de la aplicación dueño de este contacto.
        /// </summary>
        public string ApplicationUserId { get; set; }


        // -----------------------------------------
        // Constructores
        // -----------------------------------------

        /// <summary>
        /// Construye un nuevo contacto utilizando el nombre pasado como parámetro. 
        /// </summary>
        /// <param name="nombre"></param>
        public Contact(string nombre)
        {
            LastContact = DateTime.Now;
            Name = nombre;
        }

        /// <summary>
        /// Devuelve el nombre del contacto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

    }
}