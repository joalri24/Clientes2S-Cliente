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
        public const string RUTA_CONTACTOS = "api/contacts";
        public const string RUTA_TAREAS_CLIENTE = "/jobs";
        public const string RUTA_CONTACTOS_CLIENTE = "/contacts";

        // ------------------------------------------------
        // Atributos
        // ------------------------------------------------

        private bool vacio;

        /// <summary>
        /// Se utiliza para evitar que se hagan actualizaciones en la 
        /// base de datos mientrás se están cargando los datos
        /// </summary>
        public static bool cargando = false;

        // ------------------------------------------------
        // Constructor
        // ------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            vacio = true;
            cargando = false;
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
        private async void CrearCliente(object sender, EventArgs e)
        {
            FormNuevoCliente dialogo = new FormNuevoCliente();

            // Abre una ventana de dialogo para obtener la información del nuevo cliente.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {

                Client cliente = new Client(dialogo.darNombreCliente(), dialogo.darTipoAsociacion());
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(RUTA_CLIENTES, cliente);

                    if (response.IsSuccessStatusCode)
                    {
                        cliente = await response.Content.ReadAsAsync<Client>(); // Esto se hace para obtener el Id asignado por el servidor.
                        AgregarClienteControl(cliente);
                    }                                                            
                    else
                        MessageBox.Show("No fue posible guardar el nuevo cliente en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                }
                /* Registra el contacto principal si se rellenaron los campos correspondientes.
                if (dialogo.darNombreContactoPrincipal() != "")
                {
                    Contacto contacto = new Contacto(dialogo.darNombreContactoPrincipal());
                    contacto.Cargo = dialogo.darCargoContactoPrincipal();
                    contacto.Correo = dialogo.darCorreoContactoPrincipal();
                    contacto.Telefono = dialogo.darTelefonoContactoPrincipal();

                    cliente.ContactoPrincipal = contacto;                   
                }*/                 
            }                       
        }

        /// <summary>
        /// Agrega el cliente pasado como parámetro al layout del fondo.
        /// Crea el control correspondiente y lo introduce en una nueva fila.
        /// </summary>
        /// <param name="control"></param>
        void AgregarClienteControl(Client cliente)
        {
            // La sentencia if es para que no se cree una nueva fila si exiten filas vacías
            // disponibles donde se puede poner el nuevo cliente.
            if (vacio)
                vacio = false;
            else
                tableLayoutClientes.RowCount++;

            ClienteControl control = new ClienteControl(cliente);
            tableLayoutClientes.Controls.Add(control, 0, tableLayoutClientes.RowCount - 1);
        }

        /// <summary>
        /// Agrega el cliente pasado como parámetro al layout del fondo.
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
            cargando = true;
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

                        // Obtener las tarea del cliente y las agrega en los controles correspondientes.
                        response = await httpClient.GetAsync(RUTA_CLIENTES + "/" + cliente.Id + RUTA_TAREAS_CLIENTE);
                        if (response.IsSuccessStatusCode)
                        {                          
                            Job[] tareas = await response.Content.ReadAsAsync<Job[]>();
                            foreach (var tarea in tareas)
                                controlCliente.AgregarControlTarea(tarea);
                        }

                        // Obtener los contactos del cliente y las agrega en los controles correspondientes.
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
            cargando = false;
        }
    }
}
