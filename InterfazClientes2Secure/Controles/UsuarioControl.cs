using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazClientes2Secure.Modelos;

namespace InterfazClientes2Secure.Controles
{
    public partial class UsuarioControl : UserControl
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------
        public Usuario Usuario { get; set; }


        // ------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------
        public UsuarioControl()
        {
            InitializeComponent();
        }


        public UsuarioControl(Usuario usuario)
        {
            InitializeComponent();

            Usuario = usuario;
            labelUsuario.Text = Usuario.Email;
            var roles = Usuario.Roles.Split(',');

            if (roles.Contains(Sesion.ROL_ADMIN))
                checkBoxAdmin.Checked = true;

            if (roles.Contains(Sesion.ROL_EMPLOYEE))
                checkBoxEmpleado.Checked = true;
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------


    }

}
