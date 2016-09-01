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

namespace InterfazClientes2Secure
{
    public partial class Form1 : Form
    {

        // ------------------------------------------------
        // Constantes
        // ------------------------------------------------
        public const string DIRECCION_SERVIDOR = "http://localhost:2424/";
        public const string APP_JSON = "application/json";
        public const string RUTA_CLIENTES = "api/clients";

        // ------------------------------------------------
        // Atributos
        // ------------------------------------------------

        private bool vacio;

        // ------------------------------------------------
        // Constructor
        // ------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            vacio = true;
        }


        // ------------------------------------------------
        // Métodos
        // ------------------------------------------------

        /// <summary>
        /// TODO Borrar. Atajo para crear nuevos clientes.
        /// </summary>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {           
            TableLayoutPanel tablaFondo = tableLayoutClientes;
            if (vacio)
                vacio = false;
            else
                tablaFondo.RowCount++;

            tablaFondo.Controls.Add(new ClienteControl(), 0, tablaFondo.RowCount - 1);
            //Console.WriteLine("Rows: " + tablaFondo.RowCount);
        }

        /// <summary>
        /// Crear nuevo cliente cuando se hace click en el botón correspondiente.
        /// </summary>
        private void CrearCliente(object sender, EventArgs e)
        {
            /**FormNuevoCliente dialogo = new FormNuevoCliente();

            // Abre una ventana de dialogo para obtener la información del nuevo cliente.
            if (dialogo.ShowDialog() == DialogResult.OK)
            {

                Cliente cliente = new Cliente(dialogo.darNombreCliente(), dialogo.darTipoAsociacion());

                // Registra el contacto principal si se rellenaron los campos correspondientes.
                if (dialogo.darNombreContactoPrincipal() != "")
                {
                    Contacto contacto = new Contacto(dialogo.darNombreContactoPrincipal());
                    contacto.Cargo = dialogo.darCargoContactoPrincipal();
                    contacto.Correo = dialogo.darCorreoContactoPrincipal();
                    contacto.Telefono = dialogo.darTelefonoContactoPrincipal();

                    cliente.ContactoPrincipal = contacto;                   
                }

                ClienteControl controlCliente = new ClienteControl(cliente);
                AgregarClienteControl(controlCliente);              
            } */                      
        }

        /// <summary>
        /// Agrega el control pasado como parámetro al layout del fondo.
        /// Lo introduce en una nueva fila.
        /// </summary>
        /// <param name="control"></param>
        void AgregarClienteControl(ClienteControl control)
        {
            // La sentencia if es para que no se cree una nueva fila si exiten filas vacías
            // disponibles donde se puede poner el nuevo cliente.
            if (vacio)
                vacio = false;
            else
                tableLayoutClientes.RowCount++;

            tableLayoutClientes.Controls.Add(control, 0, tableLayoutClientes.RowCount - 1);
        }

        /// <summary>
        /// Obtiene los clientes desde el backend por medio de un servicio web.
        /// Crea los controles correspondientes y los agrega a al layout de fondo.
        /// </summary>
        private async void CargarClientes(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DIRECCION_SERVIDOR);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));

                HttpResponseMessage response = await client.GetAsync(RUTA_CLIENTES);
                if (response.IsSuccessStatusCode)
                {
                    Client[] clientes = await response.Content.ReadAsAsync<Client[]>();

                    foreach (var cliente in clientes)
                    {
                        var control = new ClienteControl(cliente);
                        AgregarClienteControl(control);
                    }
                }
            }
        }


    }
}
