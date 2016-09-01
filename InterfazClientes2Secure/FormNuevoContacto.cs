using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazClientes2Secure
{
    /// <summary>
    /// El formulati que aparece cuando se va a crear un nuevo contacto.
    /// </summary>
    public partial class FormNuevoContacto : Form
    {
        /// <summary>
        /// Inicializa la clase. Selecciona por defecto el campo del nombre
        /// del contacto.
        /// </summary>
        public FormNuevoContacto()
        {
            InitializeComponent();
            textBoxNombreContacto.Select();
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Activa el botón de aceptar cuando el campo del nombre no está vacío.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            buttonAceptar.Enabled = (textBoxNombreContacto.Text == "") ? false : true;
        }
        /// <summary>
        /// Retorna el nombre del cliente.
        /// </summary>
        /// <returns></returns>
        public string darNombre()
        {
            return textBoxNombreContacto.Text;
        }

        /// <summary>
        /// Retorna el cargo del contacto principal.
        /// </summary>
        /// <returns></returns>
        public string darCargo()
        {
            return textBoxCargo.Text;
        }

        /// <summary>
        /// Retorna el teléfono del contacto principal.
        /// </summary>
        /// <returns></returns>
        public string darTelefono()
        {
            return textBoxTelefono.Text;
        }

        /// <summary>
        /// Retorna el correo del principal.
        /// </summary>
        /// <returns></returns>
        public string darCorreo()
        {
            return textBoxCorreo.Text;
        }
    }
}
