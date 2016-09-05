using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace InterfazClientes2Secure
{
    public partial class ClienteControl : UserControl
    {

        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        // Tamaños para maximizar y minimizar
        private const int ALTURA_ORIGINAL = 470;
        private const int ALTURA_MINIMIZADO = 25;

        // Texto de los botones de cambio de estado
        private const string URGENTE = "Urgente";
        private const string ATENCION = "Atención";
        private const string NORMAL = "Normal";


        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        /// <summary>
        /// Indica si hay o no tareas registradas en el cliente.
        /// </summary>
        private bool hayTareas;

        /// <summary>
        /// Indica si hay o no contactos registrados en el cliente.
        /// </summary>
        private bool hayContactos;

        //private Cliente cliente;
        public Client Cliente;


        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------

        public ClienteControl()
        {
            InitializeComponent();
            hayTareas = false;
            hayContactos = false;
            Cliente = null;
        }

        /// <summary>
        /// Construye un control Cliente a partir de los datos del 
        /// objeto Client pasado como paràmetro.
        /// </summary>
        /// <param name="clienteP"></param>
        public ClienteControl(Client cliente)
        {
            InitializeComponent();
            hayTareas = false;
            hayContactos = false;
            Cliente = cliente;

            textBoxNombreCliente.Text = Cliente.Name;
            toolStripLabelCliente.Text = Cliente.Name;
            comboBoxTipoAsociacion.Text = Cliente.Association;
            checkBoxSeguimiento.Checked = Cliente.Follow;
            textBoxComentarios.Text = Cliente.Comments;
            textBoxPendientes.Text = Cliente.Pendings;
            CambiarEstado(Cliente.State);
            dateTimePickerUltimoContacto.Value = Cliente.LastContact;
        }


        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Añade un nuevo contacto en el tablelayout de contactos.
        /// Un contacto por fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AgregarControlContacto(Contact contacto)
        {
            TableLayoutPanel tablaFondo = tableLayoutContactos;
            if (!hayContactos)
                hayContactos = true;
            else
                tablaFondo.RowCount++;
            var control = new ContactoControl(contacto);
            tablaFondo.Controls.Add(control, 0, tablaFondo.RowCount - 1);
            Form1.controlesContactos.Add(control);

        }

        /// <summary>
        /// Agrega un controlTarea al tableLayout correspondiente.
        /// Coloca el controlador en una tabla nueva.
        /// </summary>
        /// <param name="tarea"></param>
        public void AgregarControlTarea(Job tarea)
        {

            if (!hayTareas)
                hayTareas = true;
            else
                tableLayoutTareas.RowCount++;

            TareaControl control = new TareaControl(tarea);
            tableLayoutTareas.Controls.Add(control, 0, tableLayoutTareas.RowCount - 1);
            Form1.controlesTareas.Add(control);
        }

        /// <summary>
        /// Agrega un controlTarea al tableLayout correspondiente.
        /// Coloca el controlador en una tabla nueva.
        /// </summary>
        /// <param name="tarea"></param>
        public void AgregarControlTarea(TareaControl control)
        {

            if (!hayTareas)
                hayTareas = true;
            else
                tableLayoutTareas.RowCount++;

            tableLayoutTareas.Controls.Add(control, 0, tableLayoutTareas.RowCount - 1);
            Form1.controlesTareas.Add(control);
        }

        /// <summary>
        /// Cambia el estado del cliente. En la interfaz el color de la
        /// barra donde aparece el nombre cambia de color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CambiarEstado(object sender, EventArgs e)
        {
            ToolStripButton boton = sender as ToolStripButton;

            if (boton.Text == URGENTE)
            {
                // El color de la barra y de los botones no es el mismo para
                // evitar que estos últimos se confundan con el fondo.
                toolStripCliente.BackColor = Color.IndianRed;
                boton.BackColor = Color.Firebrick;
            }
            else if (boton.Text == ATENCION)
            {
                toolStripCliente.BackColor = Color.SandyBrown;
                boton.BackColor = Color.DarkOrange;
            }
            else if (boton.Text == NORMAL)
            {
                toolStripCliente.BackColor = Color.Gainsboro;
                boton.BackColor = Color.LightGray;
            }

            Cliente.State = boton.Text;
            GuardarCambiosCliente();
        }

        /// <summary>
        /// Cambia el color de la barra y de los botones según el estado pasado como
        /// parámetro. Si recibe un estado que no reconoce, asume que el estado es "Normal".
        /// Este método se utiliza normalmente cuando se están cargando los clientes desde el servidor.
        /// </summary>
        /// <param name="estado"></param>
        void CambiarEstado(string estado)
        {
            if (estado == URGENTE)
            {
                // El color de la barra y de los botones no es el mismo para
                // evitar que estos últimos se confundan con el fondo.
                toolStripCliente.BackColor = Color.IndianRed;
                toolStripButtonEstadoU.BackColor = Color.Firebrick;
            }
            else if (estado == ATENCION)
            {
                toolStripCliente.BackColor = Color.SandyBrown;
                toolStripButtonEstadoA.BackColor = Color.DarkOrange;
            }
            else
            {
                toolStripCliente.BackColor = Color.Gainsboro;
                toolStripButtonEstadoN.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// Elimina un cliente Después de que se muestra un dialogo de confirmación. Quita el control.
        /// TODO: El control se elimina pero la fila donde se encontraba 
        /// queda vacía. Se deben eliminar las filas vacías en algún momento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EliminarCliente(object sender, EventArgs e)
        {
            Form dialogoConfirmacion = new FormEliminar("¿Está seguro que desea eliminar el cliente  \"" + Cliente.Name + "\"?");
            if (dialogoConfirmacion.ShowDialog() == DialogResult.OK)
                this.Dispose();

        }

        /// <summary>
        /// Envá un query PUT para guardar en el servidor los cambios que se hayan
        /// realizado sobre el cliente. Se ejecuta cuando recibe eventos de la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GuardarCambiosCliente(object sender, EventArgs e)
        {

            if (Form1.cargando == false)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));

                    Cliente.Association = comboBoxTipoAsociacion.Text;
                    Cliente.Name = textBoxNombreCliente.Text;
                    Cliente.Comments = textBoxComentarios.Text;
                    Cliente.Pendings = textBoxPendientes.Text;
                    Cliente.LastContact = dateTimePickerUltimoContacto.Value;
                    Cliente.Follow = checkBoxSeguimiento.Checked;

                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(Form1.RUTA_CLIENTES + "/" + Cliente.Id, Cliente);

                    if (!response.IsSuccessStatusCode)
                        MessageBox.Show("No fue posible guardar los cambios en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                }
            }
        }


        /// <summary>
        /// Envá un query PUT para guardar en el servidor los cambios que 
        /// se hayan realizado sobre el cliente
        /// </summary>
        public async void GuardarCambiosCliente()
        {

            if (Form1.cargando == false)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));

                    Cliente.Association = comboBoxTipoAsociacion.Text;
                    Cliente.Name = textBoxNombreCliente.Text;
                    Cliente.Comments = textBoxComentarios.Text;
                    Cliente.Pendings = textBoxPendientes.Text;
                    Cliente.LastContact = dateTimePickerUltimoContacto.Value;
                    Cliente.Follow = checkBoxSeguimiento.Checked;

                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(Form1.RUTA_CLIENTES + "/" + Cliente.Id, Cliente);

                    if (!response.IsSuccessStatusCode)
                        MessageBox.Show("No fue posible guardar los cambios en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                }
            }
        }

        /// <summary>
        /// Envá un query PUT para guardar en el servidor los cambios que 
        /// se hayan realizado sobre el contacto principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GuardarCambiosContactoPrincipal(object sender, EventArgs e)
        {

            if (Form1.cargando == false)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));

                    HttpResponseMessage response = await httpClient.GetAsync(Form1.RUTA_CONTACTOS + "/" + Cliente.MainContactId);

                    if (response.IsSuccessStatusCode)
                    {
                        Contact contacto = await response.Content.ReadAsAsync<Contact>();
                        contacto.Name = textBoxNombreCP.Text;
                        contacto.JobTitle = textBoxCargoCP.Text;
                        contacto.Mail = textBoxCorreoCP.Text;
                        contacto.Telephone = textBoxTelCP.Text;

                        response = await httpClient.PutAsJsonAsync(Form1.RUTA_CONTACTOS + "/" + contacto.Id, contacto);
                        Form1.ActualizarContacto(contacto);

                        if (!response.IsSuccessStatusCode)
                            MessageBox.Show("No fue posible guardar los cambios en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza la interfaz para que los campos correspondientes muestren los datos 
        /// del contacto pasado como parámetro.
        /// </summary>
        /// <param name="contacto"></param>
        public void ImprimirDatosContactoPrincipal(Contact contacto)
        {
            textBoxNombreCP.Text = contacto.Name;
            textBoxCargoCP.Text = contacto.JobTitle;
            textBoxTelCP.Text = contacto.Telephone;
            textBoxCorreoCP.Text = contacto.Mail;
        }

        /// <summary>
        /// Minimiza el control cuando se hace click en el boton correspondiente.
        /// Lo maximiza si ya se encuentra minimizado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimizar(object sender, EventArgs e)
        {
            if (tabControlCliente.Visible)
            {
                tabControlCliente.Visible = false;
                Height = ALTURA_MINIMIZADO;
                toolStripButtonMinimizar.Text = "[+]";
                toolStripButtonMinimizar.ToolTipText = "Maximizar";
            }
            else
            {
                tabControlCliente.Visible = true;
                Height = ALTURA_ORIGINAL;
                toolStripButtonMinimizar.Text = "[-]";
                toolStripButtonMinimizar.ToolTipText = "Minimizar";
            }
        }

        /// <summary>
        /// Crear una nueva tarea. Envía un query POST para crear la tarea en el backend.
        /// Si la respuesta es favorable, agrega la tarea a la interfaz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NuevaTarea(object sender, EventArgs e)
        {
            Job tarea = new Job(Cliente.Id);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(Form1.RUTA_TAREAS, tarea);

                if (response.IsSuccessStatusCode)
                {
                    tarea = await response.Content.ReadAsAsync<Job>(); // Esto se hace para obtener el Id asignado por el servidor.
                    TareaControl control = new TareaControl(tarea);
                    AgregarControlTarea(control);
                    control.EnfocarEnNombre();
                }
                else
                    MessageBox.Show("No fue posible guardar la nueva tarea en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
            }
        }

        /// <summary>
        /// Añade un nuevo contacto en el tablelayout de contactos.
        /// Un contacto por fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NuevoContacto_Click(object sender, EventArgs e)
        {

            FormNuevoContacto dialogo = new FormNuevoContacto();

            // Abre una ventana de dialogo para obtener la información del nuevo contacto.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Contact contacto = new Contact(dialogo.darNombre());
                contacto.JobTitle = dialogo.darCargo();
                contacto.Mail = dialogo.darCorreo();
                contacto.Telephone = dialogo.darTelefono();
                contacto.ClientId = Cliente.Id;

                // Envía el query POST
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(Form1.RUTA_CONTACTOS, contacto);

                    if (response.IsSuccessStatusCode)
                    {
                        contacto = await response.Content.ReadAsAsync<Contact>(); // Esto se hace para obtener el Id asignado por el servidor.
                        AgregarControlContacto(contacto);
                    }
                    else
                        MessageBox.Show("No fue posible guardar el nuevo contacto en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                }
            }
        }

        /// <summary>
        /// Busca en el servidor el contacto con el Id pasado como parámetro.
        /// Si no encuentra un contacto simplemente no hace nada.
        /// </summary>
        /// <param name="IdContactoPrincipal"></param>
        public async void ObtenerDatosContactoPrincipal(int IdContactoPrincipal)
        {
            // Envía el query GET
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                HttpResponseMessage response = await httpClient.GetAsync(Form1.RUTA_CONTACTOS + "/" + IdContactoPrincipal);

                if (response.IsSuccessStatusCode)
                {
                    Contact contacto = await response.Content.ReadAsAsync<Contact>();
                    textBoxNombreCP.Text = contacto.Name;
                    textBoxCargoCP.Text = contacto.JobTitle;
                    textBoxCorreoCP.Text = contacto.Mail;
                    textBoxTelCP.Text = contacto.Telephone;
                }
            }
        }

        /// <summary>
        /// Muestra un formulario donde se puede seleccionar un contacto para asociarlo 
        /// como contacto principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeleccionarContacto(object sender, EventArgs e)
        {
            var dialogo = new FormSeleccionarContacto(Cliente.Id);

            // Abre una ventana de dialogo para obtener la información del nuevo contacto.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Contact contacto = dialogo.DarContactoSeleccionado();
                Cliente.MainContactId = contacto.Id;
                ImprimirDatosContactoPrincipal(contacto);
                GuardarCambiosCliente();
            }
        }

        /// <summary>
        /// Cambia el estilo del borde cuando se le quita el foco al textbox.
        /// Queda sin ningún borde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Actualiza el nombre de la empresa en la barra superior cuando
        /// se modifica el campo correspondiente dentro de la pestaña de 
        /// resumen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNombreCliente_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            toolStripLabelCliente.Text = textbox.Text;
        }

    }
}
