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
    /// Formulario que despliega un dialogo de entrada de información cuando 
    /// se va a crear un nuevo cliente. Selecciona por defecto el campo del nombre.
    /// </summary>
    public partial class FormNuevoCliente : Form
    {
        public FormNuevoCliente()
        {
            InitializeComponent();
            textBoxNombreCliente.Select();
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Activa el botón de aceptar cuando el campo del nombre no está vacío.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNombreCliente_TextChanged(object sender, EventArgs e)
        {
            buttonAceptar.Enabled = (textBoxNombreCliente.Text == "")? false:true; 
        }
        /// <summary>
        /// Retorna el nombre del cliente.
        /// </summary>
        /// <returns></returns>
        public string darNombreCliente()
        {
            return textBoxNombreCliente.Text;
        }

        /// <summary>
        /// Retorna el tipo de asociación con el cliente.
        /// </summary>
        /// <returns></returns>
        public string darTipoAsociacion()
        {
            string respuesta = "Directo";

            if (radioButtonIntermediario.Checked)
                respuesta = radioButtonIntermediario.Text;

            return respuesta;
        }

        /// <summary>
        /// Retorna el nombre del contacto principal.
        /// </summary>
        /// <returns></returns>
        public string darNombreContactoPrincipal()
        {
            return textBoxNombreContacto.Text;
        }

        /// <summary>
        /// Retorna el cargo del contacto principal.
        /// </summary>
        /// <returns></returns>
        public string darCargoContactoPrincipal()
        {
            return textBoxCargo.Text;
        }

        /// <summary>
        /// Retorna el teléfono del contacto principal.
        /// </summary>
        /// <returns></returns>
        public string darTelefonoContactoPrincipal()
        {
            return textBoxTelefono.Text;
        }

        /// <summary>
        /// Retorna el correo del principal.
        /// </summary>
        /// <returns></returns>
        public string darCorreoContactoPrincipal()
        {
            return textBoxCorreo.Text;
        }

    }
}
