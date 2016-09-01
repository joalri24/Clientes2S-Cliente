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
    public partial class FormEliminar : Form
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------
        private string MENSAJE_BASE = "¿Está seguro que desea eliminar el elemento \"";
        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------



        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------

        public FormEliminar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construye el formulario de confirmación de eliminar un elemento.
        /// Muestra el mensaje que se pasa como parámetro.
        /// </summary>
        /// <param name="mensaje"></param>
        public FormEliminar(string mensaje)
        {
            InitializeComponent();
            labelMensaje.Text = mensaje;

        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

    }
}
