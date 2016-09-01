﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazClientes2Secure
{
    public partial class ContactoControl : UserControl
    {

        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        // Tamaños para maximizar y minimizar
        private const int ALTURA_ORIGINAL = 210;
        private const int ALTURA_MINIMIZADO = 25;


        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        private Contact Contacto;


        // ------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------

        public ContactoControl()
        {
            InitializeComponent();
            Contacto = null;
        }

        public ContactoControl(Contact contacto)
        {
            InitializeComponent();
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
                this.Height = ALTURA_MINIMIZADO;
                toolStripButtonMinimizarContacto.Text = "[+]";
                toolStripButtonMinimizarContacto.ToolTipText = "Maximizar";
            }
            else
            {
                splitContainerContacto.Visible = true;
                this.Height = ALTURA_ORIGINAL;
                toolStripButtonMinimizarContacto.Text = "[-]";
                toolStripButtonMinimizarContacto.ToolTipText = "Minimizar";
            }
        }

        /// <summary>
        /// Elimina al contacto. Quita el control.
        /// TODO: El control se elimina pero la fila donde se encontraba 
        /// queda vacía. Se deben eliminar las filas vacías en algún momento.
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
