using InterfazClientes2Secure.Forms;
using InterfazClientes2Secure.Modelos;
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
        public const string RUTA_TODOS_CLIENTES = "api/clients/all";
        public const string RUTA_TODOS_CONTACTOS = "api/contacts/all";
        public const string RUTA_TAREAS = "api/jobs";
        public const string RUTA_CONTACTOS = "api/contacts";
        public const string RUTA_TAREAS_CLIENTE = "/jobs";
        public const string RUTA_CONTACTOS_CLIENTE = "/contacts";
        public const string RUTA_TOKEN = "Token";
        public const string RUTA_ROLES = "api/Account/RolesInfo";
        public const string RUTA_MODIFICAR_ROLES = "api/Account/Roles";
        public const string RUTA_REGISTRAR = "api/Account/Register";

        private const string CARGANDO = "Obteniendo datos desde el servidor...";
        private const string LOGIN = "Login";
        private const string LOGOUT = "Logout";
        public const string RUTA_LOGOUT = "api/Account/Logout";

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
        /// <param name="cliente"></param>
        void AgregarClienteControl(Client cliente)
        {
            // La sentencia if es para que no se cree una nueva fila si exiten 
            // filas vacías disponibles donde se puede poner el nuevo cliente.
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
        /// Agrega el Control Contacto pasado como parámetro al layout del fondo.
        /// Lo introduce en una nueva fila.
        /// </summary>
        /// <param name="control"></param>
        void AgregarContactoControl(ContactoControl control)
        {
            // La sentencia if es para que no se cree una nueva fila si exiten filas vacías
            // disponibles donde se puede poner el nuevo cliente.
            if (vacio)
                vacio = false;
            else
                tableLayoutClientes.RowCount++;

            tableLayoutClientes.Controls.Add(control, 0, tableLayoutClientes.RowCount - 1);
            controlesContactos.Add(control); 
        }

        /// <summary>
        /// Obtiene los clientes pertenecientes al usuario desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// Se ejecuta cuando se hace click sobre el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarClientes(object sender, EventArgs e)
        {
            CargarClientes(RUTA_CLIENTES);
        }

        /// <summary>
        /// Obtiene todos los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// Se ejecuta cuando se hace click sobre el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarTodosClientes(object sender, EventArgs e)
        {
            CargarClientes(RUTA_TODOS_CLIENTES);
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// </summary>
        private async void CargarClientes(string ruta)
        {

            LimpiarListas();          
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

                HttpResponseMessage response = await httpClient.GetAsync(ruta);
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
                    toolStripLabelMensaje.Text = "Respuesta negativa del servidor";
                
            }
            MinimizarControles();
            cargando = false;
            toolStripLabelMensaje.Text = "Conectado como: "+ Sesion.userName;
        }

        /// <summary>
        /// Obtiene los contactos pertenecientes al usuario desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// Se ejecuta cuando se hace click sobre el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarContactos(object sender, EventArgs e)
        {
            CargarContactos(RUTA_CONTACTOS);
        }

        /// <summary>
        /// Obtiene todos los contactos desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// Se ejecuta cuando se hace click sobre el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarTodosContactos(object sender, EventArgs e)
        {
            CargarContactos(RUTA_TODOS_CONTACTOS);
        }

        /// <summary>
        /// Obtiene todos los contactos asociados con el usuario. Utiliza un query GET.
        /// </summary>
        private async void CargarContactos(string ruta)
        {
            LimpiarListas();
            cargando = true;
            toolStripLabelMensaje.Text = CARGANDO;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));
                if (Sesion != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Sesion.access_token);

                HttpResponseMessage response = await httpClient.GetAsync(ruta);
                if (response.IsSuccessStatusCode)
                {
                    Contact[] contactos = await response.Content.ReadAsAsync<Contact[]>();

                    foreach (var contacto in contactos)
                    {
                        var control = new ContactoControl(contacto);
                        AgregarContactoControl(control);
                    }
                }
                else
                    toolStripLabelMensaje.Text = "Respuesta negativa del servidor";               

                cargando = false;
                MinimizarControles();
                toolStripLabelMensaje.Text = "Conectado como: "+ Sesion.userName;
            }
        }

        /// <summary>
        /// Borra la información de sesión. También borra los clientes de la pantalla
        /// y bloquea ciertos botones. Envía una petición al servidor para informarle
        /// que la sesión acabó.
        /// </summary>
        private async void CerrarSesion()
        {

            if (Sesion != null)
            {
                cargando = true;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    if (Sesion != null)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Sesion.access_token);

                    HttpResponseMessage response = await httpClient.PostAsync(RUTA_LOGOUT, null);

                    if (response.IsSuccessStatusCode)
                    {
                        Sesion = null;
                        tableLayoutClientes.Controls.Clear();
                        tableLayoutClientes.RowCount = 1;
                        vacio = true;
                        ToolStripButtonCargarClientes.Enabled = false;
                        ToolStripButtonNuevo.Enabled = false;
                        ToolStripMenuNuevoCliente.Enabled = false;
                        ToolStripMenuCargarClientes.Enabled = false;
                        toolStripButtonCargarContactos.Enabled = false;
                        toolStripButtonLogin.Tag = LOGIN;
                        toolStripButtonLogin.Text = "Iniciar sesión";
                        toolStripLabelMensaje.Text = "Se debe iniciar sesión para obtener acceso a los datos.";
                        toolStripSeparatorAdmin.Visible = false;
                        toolStripMenuCargarTodos.Visible = false;
                        toolStripMenuCargarTodos.Enabled = false;
                        ToolStripMenuUsuarios.Visible = false;
                        ToolStripMenuCargarContactos.Visible = false;
                        ToolStripMenuCargarContactos.Enabled = false;                   
                    }
                    else
                    {
                        toolStripLabelMensaje.Text = "No fue posible cerrar sesión.";
                    }
                    cargando = false;
                }
            }
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
            var boton = sender as ToolStripButton;

            if (boton.Tag as string == LOGIN)
                IniciarSesion();         
            else
                CerrarSesion();
            
                      
        }

        /// <summary>
        /// Hace invisible los controles que no pasen por los filtros establecidos.
        /// </summary>
        private void FiltrarClientes()
        {
            // Filtros por estado
            if (FiltroEstado.Checked)
            {
                toolStripLabelMensaje.Text = "Filtro por estado activado!";
                foreach (var control in controlesCliente)
                {

                    if (control.Cliente.State == ClienteControl.NORMAL)
                        control.Visible = FiltroEstadoNormal.Checked;

                    if (control.Cliente.State == ClienteControl.ATENCION)
                        control.Visible = FiltroEstadoAtencion.Checked;

                    if (control.Cliente.State == ClienteControl.URGENTE)
                        control.Visible = FiltroEstadoUrgente.Checked;
                }
            }
            else
            {               
                toolStripLabelMensaje.Text = "";
                foreach (var control in controlesCliente)
                    control.Visible =  true;
            }
        }

        /// <summary>
        /// Hace invisible los controles que no pasen por los filtros establecidos. 
        /// Se ejecuta cuando se hace click en los botones correspondientes.
        /// </summary>
        private void FiltrarClientes(object sender, EventArgs e)
        {
            FiltrarClientes();
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

                    HttpResponseMessage response = null;
                    try
                    {
                        response = await client.PostAsync(RUTA_TOKEN, formContent);
                    }
                        
                    catch (Exception)
                    {

                        MessageBox.Show("Se produjo un error al intentar comunicarse con el servidor","Error de conexión");
                        toolStripLabelMensaje.Text = "";
                        return;
                    }
                    

                    if (response.IsSuccessStatusCode)
                    {
                        Sesion = await response.Content.ReadAsAsync<Sesion>();  
                        
                        // Actualiza la interfaz gráfica.                     
                        toolStripLabelMensaje.Text = "Inicio de sesión exitoso: " + Sesion.userName;
                        ToolStripButtonCargarClientes.Enabled = true;
                        ToolStripMenuNuevoCliente.Enabled = true;
                        ToolStripMenuCargarClientes.Enabled = true;
                        ToolStripButtonNuevo.Enabled = true;
                        toolStripButtonCargarContactos.Enabled = true;
                        toolStripButtonLogin.Text = "Cerrar sesión";
                        toolStripButtonLogin.Tag = LOGOUT;

                        var roles = Sesion.roles.Split(',');
                        if (roles.Contains(Sesion.ROL_ADMIN)) 
                        {
                            // Muestra las opciones exclusivas de administrador.
                            toolStripSeparatorAdmin.Visible = true;
                            toolStripMenuCargarTodos.Visible = true;
                            toolStripMenuCargarTodos.Enabled = true;
                            ToolStripMenuUsuarios.Visible = true;
                            ToolStripMenuCargarContactos.Visible = true;
                            ToolStripMenuCargarContactos.Enabled = true;

                        }

                        CargarClientes(RUTA_CLIENTES);
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
        /// Limpia las listas y el contenedor de la interfaz gráfica.
        /// </summary>
        private void LimpiarListas()
        {
            tableLayoutClientes.Controls.Clear();
            controlesCliente.Clear();
            controlesContactos.Clear();
            controlesTareas.Clear();
            tableLayoutClientes.RowCount = 1;
            vacio = true;
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// </summary>
        private void MinimizarControles(object sender, EventArgs e)
        {
            MinimizarControles();
            
        }

        /// <summary>
        /// Minimiza todos los controles de la interfaz.
        /// </summary>
        private void MinimizarControles()
        {
            foreach (ClienteControl control in controlesCliente)
                control.Minimizar();

            foreach (ContactoControl control in controlesContactos)
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

        /// <summary>
        /// Abre una ventana de dialogo donde se pueden gestionar los roles de los usuario de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GestionarRoles(object sender, EventArgs e)
        {
            var dialogo = new FormGestionUsuarios();
            dialogo.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogo = new FormCrearUsuario();

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                var usuario = new NuevoUsuario() { Email = dialogo.darLogin(), Password = dialogo.darcontraseña(), ConfirmPassword = dialogo.darConfirmacion()};
                toolStripLabelMensaje.Text = "Registrando usuario...";
                using (var HttpClient = new HttpClient())
                {
                    HttpClient.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                    HttpClient.DefaultRequestHeaders.Accept.Clear();
                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));
                    HttpResponseMessage response = await HttpClient.PostAsJsonAsync(RUTA_REGISTRAR, usuario);

                    if (response.IsSuccessStatusCode)
                    {
                        toolStripLabelMensaje.Text = "Usuario registrado...";
                    }
                    else
                    {
                        toolStripLabelMensaje.Text = "Error al registrar al usuario.";
                    }
                }
            }
         }

    }
}
