﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazClientes2Secure
{
    public class Job
    {
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

    }
}