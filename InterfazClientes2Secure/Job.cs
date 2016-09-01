using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    public class Job
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------
        private const string URGENTE = "Urgente";
        private const string ATENCION = "Atención";
        private const string NORMAL = "Normal";
        private const string FINALIZADA = "Finalizada";

        // -----------------------------------------
        // Propiedades
        // -----------------------------------------
        public int Id { get; set; }

        // Foreign Key
        public int ClientId { get; set; }

        // Navigation properties
        public Client Client { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string State { get; set; }

        public DateTime Date { get; set; }

        // "Foreign Key"
        public int ContactId { get; set; }


        // -----------------------------------------
        // Constructores
        // -----------------------------------------

        public Job(int clientId)
        {
            Date = DateTime.Now;
            Name = "Nueva tarea";
            Description = "";
            State = NORMAL;
            ContactId = 0;
            ClientId = clientId;
        }
    }
}