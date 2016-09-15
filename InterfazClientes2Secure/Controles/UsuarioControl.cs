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
using System.Net.Http;
using System.Net.Http.Headers;

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
            {
                checkBoxAdmin.Checked = true;
                checkBoxAdmin.Enabled = !(Form1.Sesion.userName == Usuario.Email);
            }
                

            if (roles.Contains(Sesion.ROL_COMERCIAL))
                checkBoxComercial.Checked = true;
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Guarda los cambios de roles en la base de datos enviando un query PUT.
        /// Se ejecuta cuando hay un cambio en los checkbox del control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GuardarCambios(object sender, EventArgs e)
        {
            var roles = new List<string>();

            if (checkBoxAdmin.Checked)
                roles.Add(Sesion.ROL_ADMIN_NOMBRE);

            if (checkBoxComercial.Checked)
                roles.Add(Sesion.ROL_COMERCIAL_NOMBRE);

            Usuario.Roles = String.Join(",", roles);

            GuardarCambios();
        }

        /// <summary>
        /// Guarda los cambios de roles en la base de datos enviando un query PUT.
        /// </summary>
        private async void GuardarCambios()
        {

            
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                if (Form1.Sesion != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.Sesion.access_token);

                HttpResponseMessage response = await httpClient.PutAsJsonAsync(Form1.RUTA_MODIFICAR_ROLES, Usuario);

                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Cambio de roles exitoso.", "Cambio de roles");
                else
                    MessageBox.Show("No fue posible guardar los cambios en la base de datos.", "Cambio de roles");

            }
        }
    }
}
