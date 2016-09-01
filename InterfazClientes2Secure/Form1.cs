using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazClientes2Secure
{
    public partial class Form1 : Form
    {

        // ------------------------------------------------
        // Constantes
        // ------------------------------------------------
        public const string DIRECCION_SERVIDOR = "http://localhost:2424/";
        public const string APP_JSON = "application/json";

        public const string RUTA_CLIENTES = "api/clients";
        public const string RUTA_TAREAS = "api/jobs";
        public const string RUTA_TAREAS_CLIENTE = "/jobs";
        public const string RUTA_CONTACTOS_CLIENTE = "/contacts";

        // ------------------------------------------------
        // Atributos
        // ------------------------------------------------

        private bool vacio;

        // ------------------------------------------------
        // Constructor
        // ------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            vacio = true;
        }


        // ------------------------------------------------
        // Métodos
        // ------------------------------------------------

        /// <summary>
        /// TODO Borrar. Atajo para crear nuevos clientes.
        /// </summary>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {           
            TableLayoutPanel tablaFondo = tableLayoutClientes;
            if (vacio)
                vacio = false;
            else
                tablaFondo.RowCount++;

            tablaFondo.Controls.Add(new ClienteControl(), 0, tablaFondo.RowCount - 1);
            //Console.WriteLine("Rows: " + tablaFondo.RowCount);
        }

        /// <summary>
        /// Crear nuevo cliente cuando se hace click en el botón correspondiente.
        /// </summary>
        private void CrearCliente(object sender, EventArgs e)
        {
            /**FormNuevoCliente dialogo = new FormNuevoCliente();

            // Abre una ventana de dialogo para obtener la información del nuevo cliente.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {

                Cliente cliente = new Cliente(dialogo.darNombreCliente(), dialogo.darTipoAsociacion());

                // Registra el contacto principal si se rellenaron los campos correspondientes.
                if (dialogo.darNombreContactoPrincipal() != "")
                {
                    Contacto contacto = new Contacto(dialogo.darNombreContactoPrincipal());
                    contacto.Cargo = dialogo.darCargoContactoPrincipal();
                    contacto.Correo = dialogo.darCorreoContactoPrincipal();
                    contacto.Telefono = dialogo.darTelefonoContactoPrincipal();

                    cliente.ContactoPrincipal = contacto;                   
                }

                ClienteControl controlCliente = new ClienteControl(cliente);
                AgregarClienteControl(controlCliente);              
            } */                      
        }

        /// <summary>
        /// Agrega el control pasado como parámetro al layout del fondo.
        /// Lo introduce en una nueva fila.
        /// </summary>
        /// <param name="control"></param>
        void AgregarClienteControl(ClienteControl control)
        {
            // La sentencia if es para que no se cree una nueva fila si exiten filas vacías
            // disponibles donde se puede poner el nuevo cliente.
            if (vacio)
                vacio = false;
            else
                tableLayoutClientes.RowCount++;

            tableLayoutClientes.Controls.Add(control, 0, tableLayoutClientes.RowCount - 1);
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// </summary>
        private async void CargarClientes(object sender, EventArgs e)
        {
            // Obtener los clientes con un query GET.
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));

                HttpResponseMessage response = await httpClient.GetAsync(RUTA_CLIENTES);
                if (response.IsSuccessStatusCode)
                {
                    Client[] clientes = await response.Content.ReadAsAsync<Client[]>();

                    foreach (Client cliente in clientes)
                    {
                        var controlCliente = new ClienteControl(cliente);
                        AgregarClienteControl(controlCliente);

                        // Obtener las tarea del cliente y agregarlas en los controles correspondientes.
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        response = await httpClient.GetAsync(RUTA_CLIENTES + "/" + cliente.Id + RUTA_TAREAS_CLIENTE);

                        if (response.IsSuccessStatusCode)
                        {                          
                            Job[] tareas = await response.Content.ReadAsAsync<Job[]>();
                            foreach (var tarea in tareas)
                                controlCliente.AgregarControlTarea(tarea);
                        }

                        // Obtener los contactos del cliente y agregarlas en los controles correspondientes.
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        response = await httpClient.GetAsync(RUTA_CLIENTES + "/" + cliente.Id + RUTA_CONTACTOS_CLIENTE);

                        if (response.IsSuccessStatusCode)
                        {
                            Contact[] contactos = await response.Content.ReadAsAsync<Contact[]>();
                            foreach (var contacto in contactos)
                                controlCliente.AgregarControlContacto(contacto);
                        }
                    }
                }
            }
        }


    }
}
