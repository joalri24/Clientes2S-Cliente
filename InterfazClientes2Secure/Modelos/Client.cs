using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Association { get; set; }

        public string Comments { get; set; }

        public string Pendings { get; set; }

        public DateTime LastContact { get; set; }

        public string State { get; set; }

        // "Foreign Key"
        public int MainContactId { get; set; }

        public bool Follow { get; set; }

        public string ApplicationUserId { get; set; }


        // ------------------------------------
        // Constructor
        // ------------------------------------

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