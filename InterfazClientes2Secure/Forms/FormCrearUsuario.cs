using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazClientes2Secure.Forms
{
    public partial class FormCrearUsuario : Form
    {
        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        public string darLogin()
        {
            return textBoxLogin.Text;
        }

        public string darcontraseña()
        {
            return textBoxPassword.Text;
        }

        public string darConfirmacion()
        {
            return textBoxConfirmar.Text;
        }
    }
}
