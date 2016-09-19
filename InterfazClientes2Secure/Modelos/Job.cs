using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    /// <summary>
    /// Representa una Tarea asociada con un cliente de 2Secure. 
    /// Se llama "Job" debido a que la palabra "Task" genera problemas en C#.
    /// </summary>
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
        /// <summary>
        /// El id del cliente que esta asociado con este contacto.
        /// </summary>
        public int ClientId { get; set; }

        // Navigation properties
        public Client Client { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string State { get; set; }

        public DateTime Date { get; set; }

        // "Foreign Key"
        public int ContactId { get; set; }

        /// <summary>
        /// El id del usuario de la aplicación dueño de este contacto.
        /// </summary>
        public string ApplicationUserId { get; set; }


        // -----------------------------------------
        // Constructores
        // -----------------------------------------

        /// <summary>
        /// Crea una nueva tarea asociandola con el cliente pasado como parámetro.
        /// El nombre de la tarea es "Nueva Tarea", el estado por defecto es "Normal" 
        /// y la fecha es el momento de la creación.
        /// </summary>
        /// <param name="clientId"></param>
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