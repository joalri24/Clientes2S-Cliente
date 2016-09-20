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
    /// <summary>
    /// Control que contiene todos los datos de un contacto.
    /// </summary>
    public partial class ContactoControl : UserControl
    {

        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        // Tamaños para maximizar y minimizar
        private const int ALTURA_ORIGINAL = 230;
        private const int ALTURA_MINIMIZADO = 25;


        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        /// <summary>
        /// Objeto Contact del control. Contiene los datos del contacto.
        /// </summary>
        public Contact Contacto;


        // ------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------

        public ContactoControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Contacto = null;
        }

        /// <summary>
        /// Crea un nuevo control utilizando los datos del contacto pasado como parámetro
        /// </summary>
        /// <param name="contacto"></param>
        public ContactoControl(Contact contacto)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Contacto = contacto;

            toolStripLabelContacto.Text = Contacto.Name;
            textBoxNombreContacto.Text = Contacto.Name;
            textBoxCargo.Text = Contacto.JobTitle;
            textBoxTelefono.Text = Contacto.Telephone;
            textBoxCorreo.Text = Contacto.Mail;
            dateTimePickerContacto.Value = Contacto.LastContact;
            textBoxNotasContacto.Text = contacto.Notes;
        }


        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Elimina al contacto. Quita el control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EliminarContacto(object sender, EventArgs e)
        {
            Form dialogoConfirmacion = new FormEliminar("¿Está seguro que desea eliminar el contacto  \"" + Contacto.Name + "\"?");
            if (dialogoConfirmacion.ShowDialog() == DialogResult.OK)
                this.Dispose();
        }

        /// <summary>
        /// Envá un query PUT para guardar en el servidor los cambios que 
        /// se hayan realizado sobre el cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GuardarCambiosContacto(object sender, EventArgs e)
        {

            if (Form1.cargando == false)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                    if (Form1.Sesion != null)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.Sesion.access_token);

                    Contacto.Name = textBoxNombreContacto.Text;
                    Contacto.JobTitle = textBoxCargo.Text;
                    Contacto.Telephone = textBoxTelefono.Text;
                    Contacto.Mail = textBoxCorreo.Text;
                    Contacto.LastContact = dateTimePickerContacto.Value;
                    Contacto.Notes = textBoxNotasContacto.Text;

                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(Form1.RUTA_CONTACTOS + "/" + Contacto.Id, Contacto);
                    Form1.ActualizarContacto(Contacto);

                    if (!response.IsSuccessStatusCode)
                    {
                        if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            MessageBox.Show("Permiso denegado para modificar este cliente.", "Error al guardar los cambios");
                        else
                            MessageBox.Show("No fue posible guardar los cambios en la base de datos. Revise si el servidor está disponible.", "Error al comunicarse con el servidor");
                    }                       
                }
            }
        }

        /// <summary>
        /// Actualiza los campos del control con los datos del cliente pasado como parámetro.
        /// </summary>
        /// <param name="contacto"></param>
        public void ImprimirDatosContacto(Contact contacto)
        {
            textBoxNombreContacto.Text = contacto.Name;
            textBoxCargo.Text = contacto.JobTitle;
            textBoxTelefono.Text = contacto.Telephone;
            textBoxCorreo.Text = contacto.Mail;
        }

        /// <summary>
        /// Minimiza el control cuando se hace click en el boton correspondiente.
        /// Lo maximiza si ya se encuentra minimizado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimizar(object sender, EventArgs e)
        {
            if (splitContainerContacto.Visible)
            {
                splitContainerContacto.Visible = false;
                Height = ALTURA_MINIMIZADO;
                toolStripButtonMinimizarContacto.Text = "[+]";
                toolStripButtonMinimizarContacto.ToolTipText = "Maximizar";
            }
            else
            {
                splitContainerContacto.Visible = true;
                Height = ALTURA_ORIGINAL;
                toolStripButtonMinimizarContacto.Text = "[-]";
                toolStripButtonMinimizarContacto.ToolTipText = "Minimizar";
            }
        }

        /// <summary>
        /// Minimiza el control cuando se hace click en el boton correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Minimizar()
        {
            if (splitContainerContacto.Visible)
            {
                splitContainerContacto.Visible = false;
                Height = ALTURA_MINIMIZADO;
                toolStripButtonMinimizarContacto.Text = "[+]";
                toolStripButtonMinimizarContacto.ToolTipText = "Maximizar";
            }
        }

        /// <summary>
        /// Actualiza el nombre del contacto en la barra superior cuando
        /// se modifica el campo correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNombreContacto_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            toolStripLabelContacto.Text = textbox.Text;
        }

    }
}
