using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    public class Contact
    {
        public int Id { get; set; }

        // Foreign Key
        public int ClientId { get; set; }

        // Navigation property
        public Client Client { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public string Telephone { get; set; }

        public string Mail { get; set; }

        public DateTime LastContact { get; set; }

        public string Notes { get; set; }


        // -----------------------------------------
        // Constructores
        // -----------------------------------------

        public Contact(string nombre)
        {
            LastContact = DateTime.Now;
            Name = nombre;
        }

    }
}