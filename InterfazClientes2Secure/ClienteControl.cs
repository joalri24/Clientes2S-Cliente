using System;
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

        private Cliente cliente;


        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------


        public ClienteControl()
        {
            InitializeComponent();
            hayTareas = false;
            hayContactos = false;
            cliente = null;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="clienteP"></param>
        public ClienteControl(Cliente clienteP)
        {
            InitializeComponent();
            hayTareas = false;
            hayContactos = false;
            cliente = clienteP;

            textBoxNombreCliente.Text = cliente.Nombre;
            toolStripLabelCliente.Text = cliente.Nombre;

            comboBoxTipoAsociacion.Text = cliente.TipoAsociación;
            checkBoxSeguimiento.Checked = cliente.HacerSeguimiento;

            if (clienteP.ContactoPrincipal != null)
            {
                textBoxNombreCP.Text = cliente.ContactoPrincipal.Nombre;
                textBoxCorreoCP.Text = cliente.ContactoPrincipal.Correo;
                textBoxTelCP.Text = cliente.ContactoPrincipal.Telefono;
                textBoxCargoCP.Text = cliente.ContactoPrincipal.Cargo;

                AgregarContacto(cliente.ContactoPrincipal);
            }

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
            if (tabControlCliente.Visible)
            {
                tabControlCliente.Visible = false;
                this.Height = ALTURA_MINIMIZADO;
                toolStripButtonMinimizar.Text = "[+]";
                toolStripButtonMinimizar.ToolTipText = "Maximizar";               
            }
            else
            {
                tabControlCliente.Visible = true;
                this.Height = ALTURA_ORIGINAL;
                toolStripButtonMinimizar.Text = "[-]";
                toolStripButtonMinimizar.ToolTipText = "Minimizar";
            }
        }

        /// <summary>
        /// Cambia el estilo del borde cuando se hace click en el textbox.
        /// Activa un borde 3d.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Enter(object sender, EventArgs e)
        {

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
            Form dialogoConfirmacion = new FormEliminar("¿Está seguro que desea eliminar el cliente  \"" + cliente.Nombre + "\"?");
            if (dialogoConfirmacion.ShowDialog() == DialogResult.OK)
                this.Dispose();

        }

        /// <summary>
        /// Añade una nueva tarea en el tablelayout de tareas.
        /// Una tarea por fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaTarea(object sender, EventArgs e)
        {           
            TableLayoutPanel tablaFondo = tableLayoutTareas;

            Tarea tarea = new Tarea();

            if (!hayTareas)
                hayTareas = true;
            else
                tablaFondo.RowCount++;

            TareaControl control = new TareaControl(tarea);
            tablaFondo.Controls.Add(control, 0, tablaFondo.RowCount - 1);
            control.EnfocarEnNombre();
        }

        /// <summary>
        /// Añade un nuevo contacto en el tablelayout de contactos.
        /// Un contacto por fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoContacto_Click(object sender, EventArgs e)
        {

            FormNuevoContacto dialogo = new FormNuevoContacto();

            // Abre una ventana de dialogo para obtener la información del nuevo contacto.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                TableLayoutPanel tablaFondo = tableLayoutContactos;

                Contacto contacto = new Contacto(dialogo.darNombre());
                contacto.Cargo = dialogo.darCargo();
                contacto.Correo = dialogo.darCorreo();
                contacto.Telefono = dialogo.darTelefono();

                AgregarContacto(contacto);
            }
        }

        /// <summary>
        /// Añade un nuevo contacto en el tablelayout de contactos.
        /// Un contacto por fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AgregarContacto(Contacto contacto)
        {
            TableLayoutPanel tablaFondo = tableLayoutContactos;
            if (!hayContactos)
                hayContactos = true;
            else
                tablaFondo.RowCount++;

            tablaFondo.Controls.Add(new ContactoControl(contacto), 0, tablaFondo.RowCount - 1);
        }


    }
}
