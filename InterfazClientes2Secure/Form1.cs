﻿using System;
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
        public const string RUTA_TOKEN = "Token";

        private const string CARGANDO = "Obteniendo datos desde el servidor...";

        // ------------------------------------------------
        // Atributos
        // ------------------------------------------------

        private bool vacio;

        /// <summary>
        /// Se utiliza para evitar que se hagan actualizaciones en la 
        /// base de datos mientrás se están cargando los datos
        /// </summary>
        public static bool cargando = false;

        /// <summary>
        /// Una lista de todos los controles cliente que hay en la aplicación.
        /// Se utiliza para actualizaciones y otras funcionalidades de la interfaz gráfica.
        /// </summary>
        private static List<ClienteControl> controlesCliente { get; set; }

        /// <summary>
        /// Una lista de todos los controles tareas que hay en la aplicación.
        /// Se utiliza para actualizaciones y otras funcionalidades de la interfaz gráfica.
        /// </summary>
        public static List<TareaControl> controlesTareas { get; set; }

        /// <summary>
        /// Una lista de todos los controles contacto que hay en la aplicación.
        /// Se utiliza para actualizaciones y otras funcionalidades de la interfaz gráfica.
        /// </summary>
        public static List<ContactoControl> controlesContactos { get; set; }

        /// <summary>
        /// Objeto que almacena la información de sesión.
        /// </summary>
        public static Sesion Sesion { get; set; }

        // ------------------------------------------------
        // Constructor
        // ------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            vacio = true;
            cargando = false;
            controlesCliente = new List<ClienteControl>();
            controlesContactos = new List<ContactoControl>();
            controlesTareas = new List<TareaControl>();
            Sesion = null;
        }


        // ------------------------------------------------
        // Métodos
        // ------------------------------------------------

        /// <summary>
        /// Actualiza todos los controles que deben actualizarse al modificar los datos de un cliente.
        /// </summary>
        /// <param name="contacto"></param>
        public static void ActualizarContacto(Contact contacto)
        {

            foreach (ContactoControl control in controlesContactos)
            {
                if (control.Contacto.Id == contacto.Id)
                    control.ImprimirDatosContacto(contacto);
            }

            foreach (TareaControl control in controlesTareas)
            {
                if (control.Tarea.ContactId == contacto.Id)
                    control.ImprimirDatosContacto(contacto);
            }

            foreach (ClienteControl control in controlesCliente)
            {
                if (control.Cliente.MainContactId == contacto.Id)
                    control.ImprimirDatosContactoPrincipal(contacto);
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
            controlesCliente.Add(control);

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
            controlesCliente.Add(control);
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// Se ejecuta cuando se hace click sobre el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarClientes(object sender, EventArgs e)
        {
            CargarClientes();
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// </summary>
        private async void CargarClientes()
        {

            tableLayoutClientes.Controls.Clear();
            tableLayoutClientes.RowCount = 1;
            vacio = true;            
            cargando = true;
            toolStripLabelMensaje.Text = CARGANDO;
            // Obtener los clientes con un query GET.
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));
                if (Sesion != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Sesion.access_token);

                HttpResponseMessage response = await httpClient.GetAsync(RUTA_CLIENTES);
                if (response.IsSuccessStatusCode)
                {
                    Client[] clientes = await response.Content.ReadAsAsync<Client[]>();

                    foreach (Client cliente in clientes)
                    {

                        var controlCliente = new ClienteControl(cliente);
                        controlCliente.ObtenerDatosContactoPrincipal(cliente.MainContactId);
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
                else
                {
                    toolStripLabelMensaje.Text = "Respuesta negativa del servidor";
                }
            }
            MinimizarClientes();
            cargando = false;
            toolStripLabelMensaje.Text = "";
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
                // TODO Agregar el id del usuario al cliente.

                ClienteControl clienteControl = null;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));
                    if (Sesion != null)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Sesion.access_token);

                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(RUTA_CLIENTES, cliente);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        cliente = await response.Content.ReadAsAsync<Client>(); // Esto se hace para obtener el Id asignado por el servidor.
                        //AgregarClienteControl(cliente);
                        clienteControl = new ClienteControl(cliente);
                        AgregarClienteControl(clienteControl);
                    }
                    else
                    {
                        MessageBox.Show("No fue posible guardar el nuevo cliente en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                        return;
                    }
                        
                }
                
                // Registra el contacto principal si se rellenaron los campos correspondientes.                     
                if (dialogo.CrearNuevoContacto)
                {
                    // Si se va a crear un nuevo contacto, es necesario que al menos el campo del nombre no esté vacío.
                    if(dialogo.darNombreContactoPrincipal() != "")
                    {
                        Contact contacto = new Contact(dialogo.darNombreContactoPrincipal());
                        contacto.JobTitle = dialogo.darCargoContactoPrincipal();
                        contacto.Mail = dialogo.darCorreoContactoPrincipal();
                        contacto.Telephone = dialogo.darTelefonoContactoPrincipal();
                        contacto.ClientId = cliente.Id;

                        // Envía el query POST
                        using (var httpClient = new HttpClient())
                        {
                            httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                            httpClient.DefaultRequestHeaders.Accept.Clear();
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));
                            if (Sesion != null)
                                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Sesion.access_token);

                            HttpResponseMessage response = await httpClient.PostAsJsonAsync(RUTA_CONTACTOS, contacto);

                            if (response.IsSuccessStatusCode)
                            {
                                contacto = await response.Content.ReadAsAsync<Contact>(); // Esto se hace para obtener el Id asignado por el servidor.
                                clienteControl.Cliente.MainContactId = contacto.Id;
                                clienteControl.GuardarCambiosCliente();
                                clienteControl.ImprimirDatosContactoPrincipal(contacto);
                                clienteControl.AgregarControlContacto(contacto);
                            }
                            else
                                MessageBox.Show("No fue posible guardar el nuevo contacto en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                        }
                    }
                }
                else   // Esto sucede cuando se selecciona un contacto de la lista de contactos existentes.
                {
                    Contact contacto = dialogo.darContactoSeleccionado();
                    clienteControl.Cliente.MainContactId = contacto.Id;
                    clienteControl.GuardarCambiosCliente();
                    clienteControl.ImprimirDatosContactoPrincipal(contacto);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IniciarSesion(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        /// <summary>
        /// Abre un dialogo donde el usuario puede escribir sus credenciales.
        /// Envía una petición POST con las credenciales proporcionadas. La respuesta 
        /// contiene un token que se utiliza para comunicarse con el servidor.
        /// </summary>
        private async void IniciarSesion()
        {
            FormIniciarSesion dialogo = new FormIniciarSesion();

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                toolStripLabelMensaje.Text = "Iniciando sesión...";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", dialogo.darLogin()),
                        new KeyValuePair<string, string>("password", dialogo.darcontraseña())
                    });
                    HttpResponseMessage response = await client.PostAsync(RUTA_TOKEN, formContent);

                    if (response.IsSuccessStatusCode)
                    {
                        Sesion = await response.Content.ReadAsAsync<Sesion>();                       
                        toolStripLabelMensaje.Text = "Inicio de sesión exitoso: " + Sesion.userName;
                        ToolStripButtonCargar.Enabled = true;
                        ToolStripButtonNuevo.Enabled = true;
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible iniciar sesión.", "Inicio de sesión");
                        toolStripLabelMensaje.Text = "Se debe iniciar sesión para obtener acceso a los datos.";
                    }



                }
            }
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// </summary>
        private void MinimizarClientes(object sender, EventArgs e)
        {
            MinimizarClientes();
            
        }

        /// <summary>
        /// Minimiza todos los controles cliente.
        /// </summary>
        private void MinimizarClientes()
        {
            foreach (ClienteControl control in controlesCliente)
                control.Minimizar();
        }


        /// <summary>
        /// Minimiza todos los controles Tarea visibles
        /// </summary>
        public static void MinimizarTareas()
        {
            foreach (TareaControl control in controlesTareas)
                control.Minimizar();
        }

        /// <summary>
        /// Minimiza todos los controles contactos.
        /// </summary>
        public static void MinimizarContactos()
        {
            foreach (ContactoControl control in controlesContactos)
                control.Minimizar();
        }

    }
}
