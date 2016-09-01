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

        private Tarea tarea;
        // ------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------
        public TareaControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public TareaControl(Tarea tareaP)
        {
            InitializeComponent();
            tarea = tareaP;

            toolStripLabelTarea.Text = tarea.Nombre;
            textBoxTareaNombre.Text = tarea.Nombre;
            toolStripLabelEstadoTarea.Text = tarea.Estado;
            textBoxTareaEstado.Text = tarea.Estado;
            textBoxDescripcion.Text = tarea.Descripcion;
            dateTimePickerTareaFecha.Text = tarea.Fecha.ToString();
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
            textBoxTareaEstado.Text = boton.Text;

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
            Form dialogoConfirmacion = new FormEliminar("¿Está seguro que desea eleminar la tarea \"" + tarea.Nombre + "\"?");
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
            Console.WriteLine(textBoxTareaNombre.Text);
        }

    }
}
