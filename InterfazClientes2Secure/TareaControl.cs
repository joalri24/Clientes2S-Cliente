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
    public partial class TareaControl : UserControl
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        // Tamaños para minimizar y maximizar.
        private const int ALTURA_MINIMIZADO = 25;
        private const int ALTURA_ORIGINAL= 285;

        // Texto de los botones de cambio de estado
        private const string URGENTE = "Urgente";
        private const string ATENCION = "Atención";
        private const string NORMAL = "Normal";
        private const string FINALIZADA = "Finalizada";


        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        private Job Tarea;


        // ------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------

        public TareaControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construye un controlTarea a partir de la información
        /// contenida en el objeto Job pasado como parámetro.
        /// </summary>
        public TareaControl(Job tarea)
        {
            InitializeComponent();
            Tarea = tarea;

            toolStripLabelTarea.Text = Tarea.Name;
            textBoxTareaNombre.Text = Tarea.Name;
            toolStripLabelEstadoTarea.Text = Tarea.State;
            textBoxTareaEstado.Text = Tarea.State;
            textBoxDescripcion.Text = Tarea.Description;
            dateTimePickerTareaFecha.Value = Tarea.Date;
            CambiarEstado(Tarea.State);
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Minimiza el control cuando se hace click en el boton correspondiente.
        /// Lo maximiza si ya se encuentra minimizado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimizar(object sender, EventArgs e)
        {
            if (splitContainerTarea.Visible)
            {
                splitContainerTarea.Visible = false;
                this.Height = ALTURA_MINIMIZADO;
                toolStripButtonMinimizarTarea.Text = "[+]";
                toolStripButtonMinimizarTarea.ToolTipText = "Maximizar";
            }
            else
            {
                splitContainerTarea.Visible = true;
                this.Height = ALTURA_ORIGINAL;
                toolStripButtonMinimizarTarea.Text = "[-]";
                toolStripButtonMinimizarTarea.ToolTipText = "Minimizar";
            }
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
                toolStripTarea.BackColor = Color.IndianRed;
                boton.BackColor = Color.Firebrick;
            }
            else if (boton.Text == ATENCION)
            {
                toolStripTarea.BackColor = Color.SandyBrown;
                boton.BackColor = Color.DarkOrange;
            }
            else if (boton.Text == NORMAL)
            {
                toolStripTarea.BackColor = Color.Gainsboro;
                boton.BackColor = Color.LightGray;
            }
            else if (boton.Text == FINALIZADA)
            {
                toolStripTarea.BackColor = Color.OliveDrab;
                boton.BackColor = Color.DarkGreen;
            }
            
            // Actualiza los labels de la interfaz
            toolStripLabelEstadoTarea.Text = "(" + boton.Text + ")";
            Tarea.State = boton.Text;
            GuardarCambiosTarea();
            textBoxTareaEstado.Text = boton.Text;
            

        }

        /// <summary>
        /// Cambia el estado del cliente según la cadena pasada como parámetro. 
        /// Si no reconoce el estado dado, asume que es Normal.
        /// La  barra donde aparece el nombre cambia de color.
        /// </summary>
        /// <param name="estado"></param>
        private void CambiarEstado(string estado)
        {

            if (estado == URGENTE)
            {
                // El color de la barra y de los botones no es el mismo para
                // evitar que estos últimos se confundan con el fondo.
                toolStripTarea.BackColor = Color.IndianRed;
                toolStripButtonTareaEstadoU.BackColor = Color.Firebrick;
            }
            else if (estado == ATENCION)
            {
                toolStripTarea.BackColor = Color.SandyBrown;
                toolStripButtonTareaEstadoA.BackColor = Color.DarkOrange;
            }
            else if (estado == FINALIZADA)
            {
                toolStripTarea.BackColor = Color.OliveDrab;
                toolStripButtonTareaEstadoF.BackColor = Color.DarkGreen;
            }
            else
            {
                toolStripTarea.BackColor = Color.Gainsboro;
                toolStripButtonTareaEstadoN.BackColor = Color.LightGray;
            }

            // Actualiza los labels de la interfaz
            toolStripLabelEstadoTarea.Text = "(" + estado + ")";
            textBoxTareaEstado.Text = estado;

        }

        /// <summary>
        /// Elimina una tarea. Quita el control.
        /// TODO: El control se elimina pero la fila donde se encontraba 
        /// queda vacía. Se deben eliminar las filas vacías en algún momento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EliminarTarea(object sender, EventArgs e)
        {
            // TODO Reemplazar por el nombre de la tarea.
            Form dialogoConfirmacion = new FormEliminar("¿Está seguro que desea eleminar la tarea \"" + Tarea.Name + "\"?");
            if (dialogoConfirmacion.ShowDialog() == DialogResult.OK)
                this.Dispose();
        }

        /// <summary>
        /// Actualiza el nombre de la empresa en la barra superior cuando
        /// se modifica el campo correspondiente dentro de la pestaña de 
        /// resumen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTareaNombre_TextChanged(object sender, EventArgs e)
        {    
            TextBox textbox = sender as TextBox;
            toolStripLabelTarea.Text = textbox.Text;
        }

        /// <summary>
        /// Hace que se enfoque el campo de texto del nombre de la tarea.
        /// </summary>
        public void EnfocarEnNombre()
        {
            textBoxTareaNombre.Select();
        }

        /// <summary>
        /// Envá un query PUT para guardar en el servidor los cambios que 
        /// se hayan realizado sobre el cliente. Se ejecuta al recibir ciertos
        /// eventos de la interfaz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GuardarCambiosTarea(object sender, EventArgs e)
        {

            if (Form1.cargando == false)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));

                    Tarea.Name = textBoxTareaNombre.Text;
                    Tarea.Description = textBoxDescripcion.Text;
                    Tarea.Date = dateTimePickerTareaFecha.Value;

                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(Form1.RUTA_TAREAS + "/" + Tarea.Id, Tarea);

                    if (!response.IsSuccessStatusCode)
                        MessageBox.Show("No fue posible guardar los cambios en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                }
            }
        }

        /// <summary>
        /// Envá un query PUT para guardar en el servidor los cambios que 
        /// se hayan realizado sobre el cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GuardarCambiosTarea()
        {

            if (Form1.cargando == false)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));

                    Tarea.Name = textBoxTareaNombre.Text;
                    Tarea.Description = textBoxDescripcion.Text;
                    Tarea.Date = dateTimePickerTareaFecha.Value;

                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(Form1.RUTA_TAREAS + "/" + Tarea.Id, Tarea);

                    if (!response.IsSuccessStatusCode)
                        MessageBox.Show("No fue posible guardar los cambios en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                }
            }
        }

        /// <summary>
        /// Muestra un formulario donde se puede seleccionar un contacto para asociarlo 
        /// con la tarea.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeleccionarContacto(object sender, EventArgs e)
        {
            var dialogo = new FormSeleccionarContacto(Tarea.ClientId);

            // Abre una ventana de dialogo para obtener la información del nuevo contacto.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Contact contacto = dialogo.DarContactoSeleccionado();
                Tarea.ContactId = contacto.Id;
                textBoxTareaNombreContacto.Text = contacto.Name;
                textBoxTareaCargoContacto.Text = contacto.JobTitle;
                textBoxTareaTelContacto.Text = contacto.Telephone;
                textBoxTareaCorreoContacto.Text = contacto.Mail;
            }
        }

    }
}
