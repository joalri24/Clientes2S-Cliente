using InterfazClientes2Secure.Controles;
using InterfazClientes2Secure.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazClientes2Secure.Forms
{
    public partial class FormGestionUsuarios : Form
    {


        // ------------------------------------------------------------------
        // Contructor
        // ------------------------------------------------------------------
        public FormGestionUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Obtiene los usuarios desde el servidor con un query GET.
        /// </summary>
        private async void CargarUsuarios()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                if (Form1.Sesion != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.Sesion.access_token);
                HttpResponseMessage response = await httpClient.GetAsync(Form1.RUTA_ROLES);

                if (response.IsSuccessStatusCode)
                {
                    Usuario[] usuarios = await response.Content.ReadAsAsync<Usuario[]>();

                    foreach (var usuario in usuarios)
                    {
                        var control = new UsuarioControl(usuario);
                        flowLayoutPanelFondo.Controls.Add(control);
                    }

                }
                else
                    MessageBox.Show("No fue posible comunicarse con el servidor.", "Error al comunicarse con el servidor");
            }
        }

    }
}
