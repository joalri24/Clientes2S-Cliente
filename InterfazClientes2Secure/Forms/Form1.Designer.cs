namespace InterfazClientes2Secure
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLogin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButtonCargarClientes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCargarContactos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButtonMinimizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelMensaje = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutClientes = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuNuevoCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuCargarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClientesToolStripMenuMinimizar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorAdmin = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuCargarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuCargarContactos = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuFiltros = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltroEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltroEstadoUrgente = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltroEstadoAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltroEstadoNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLogin,
            this.toolStripSeparator4,
            this.ToolStripButtonCargarClientes,
            this.toolStripButtonCargarContactos,
            this.toolStripSeparator1,
            this.ToolStripButtonNuevo,
            this.toolStripSeparator8,
            this.ToolStripButtonMinimizar,
            this.toolStripSeparator3,
            this.toolStripLabelMensaje});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1077, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLogin
            // 
            this.toolStripButtonLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLogin.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLogin.Image")));
            this.toolStripButtonLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogin.Name = "toolStripButtonLogin";
            this.toolStripButtonLogin.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonLogin.Tag = "Login";
            this.toolStripButtonLogin.Text = "Iniciar sesión";
            this.toolStripButtonLogin.Click += new System.EventHandler(this.IniciarSesion);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButtonCargarClientes
            // 
            this.ToolStripButtonCargarClientes.Enabled = false;
            this.ToolStripButtonCargarClientes.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonCargarClientes.Image")));
            this.ToolStripButtonCargarClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonCargarClientes.Name = "ToolStripButtonCargarClientes";
            this.ToolStripButtonCargarClientes.Size = new System.Drawing.Size(89, 22);
            this.ToolStripButtonCargarClientes.Text = "Ver Clientes";
            this.ToolStripButtonCargarClientes.Click += new System.EventHandler(this.CargarClientes);
            // 
            // toolStripButtonCargarContactos
            // 
            this.toolStripButtonCargarContactos.Enabled = false;
            this.toolStripButtonCargarContactos.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCargarContactos.Image")));
            this.toolStripButtonCargarContactos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCargarContactos.Name = "toolStripButtonCargarContactos";
            this.toolStripButtonCargarContactos.Size = new System.Drawing.Size(101, 22);
            this.toolStripButtonCargarContactos.Text = "Ver Contactos";
            this.toolStripButtonCargarContactos.Click += new System.EventHandler(this.CargarContactos);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButtonNuevo
            // 
            this.ToolStripButtonNuevo.Enabled = false;
            this.ToolStripButtonNuevo.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonNuevo.Image")));
            this.ToolStripButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonNuevo.Name = "ToolStripButtonNuevo";
            this.ToolStripButtonNuevo.Size = new System.Drawing.Size(102, 22);
            this.ToolStripButtonNuevo.Text = "Nuevo Cliente";
            this.ToolStripButtonNuevo.ToolTipText = "Nuevo cliente";
            this.ToolStripButtonNuevo.Click += new System.EventHandler(this.CrearCliente);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButtonMinimizar
            // 
            this.ToolStripButtonMinimizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonMinimizar.Image")));
            this.ToolStripButtonMinimizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonMinimizar.Name = "ToolStripButtonMinimizar";
            this.ToolStripButtonMinimizar.Size = new System.Drawing.Size(113, 22);
            this.ToolStripButtonMinimizar.Text = "[-] Minimizar todos";
            this.ToolStripButtonMinimizar.ToolTipText = "Minimizar todos";
            this.ToolStripButtonMinimizar.Click += new System.EventHandler(this.MinimizarControles);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelMensaje
            // 
            this.toolStripLabelMensaje.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabelMensaje.Name = "toolStripLabelMensaje";
            this.toolStripLabelMensaje.Size = new System.Drawing.Size(0, 22);
            // 
            // tableLayoutClientes
            // 
            this.tableLayoutClientes.AutoScroll = true;
            this.tableLayoutClientes.ColumnCount = 1;
            this.tableLayoutClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutClientes.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutClientes.Name = "tableLayoutClientes";
            this.tableLayoutClientes.RowCount = 1;
            this.tableLayoutClientes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutClientes.Size = new System.Drawing.Size(1077, 591);
            this.tableLayoutClientes.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ToolStripMenuUsuarios,
            this.ToolStripMenuFiltros,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuNuevoCliente,
            this.ToolStripMenuCargarClientes,
            this.toolStripSeparator2,
            this.ClientesToolStripMenuMinimizar,
            this.toolStripSeparatorAdmin,
            this.toolStripMenuCargarTodos,
            this.ToolStripMenuCargarContactos});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fileToolStripMenuItem.Text = "&Archivo";
            // 
            // ToolStripMenuNuevoCliente
            // 
            this.ToolStripMenuNuevoCliente.Enabled = false;
            this.ToolStripMenuNuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuNuevoCliente.Image")));
            this.ToolStripMenuNuevoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuNuevoCliente.Name = "ToolStripMenuNuevoCliente";
            this.ToolStripMenuNuevoCliente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ToolStripMenuNuevoCliente.Size = new System.Drawing.Size(231, 22);
            this.ToolStripMenuNuevoCliente.Text = "Nuevo cliente";
            this.ToolStripMenuNuevoCliente.Click += new System.EventHandler(this.CrearCliente);
            // 
            // ToolStripMenuCargarClientes
            // 
            this.ToolStripMenuCargarClientes.Enabled = false;
            this.ToolStripMenuCargarClientes.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuCargarClientes.Image")));
            this.ToolStripMenuCargarClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuCargarClientes.Name = "ToolStripMenuCargarClientes";
            this.ToolStripMenuCargarClientes.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ToolStripMenuCargarClientes.Size = new System.Drawing.Size(231, 22);
            this.ToolStripMenuCargarClientes.Text = "Cargar clientes";
            this.ToolStripMenuCargarClientes.Click += new System.EventHandler(this.CargarClientes);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // ClientesToolStripMenuMinimizar
            // 
            this.ClientesToolStripMenuMinimizar.Name = "ClientesToolStripMenuMinimizar";
            this.ClientesToolStripMenuMinimizar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.ClientesToolStripMenuMinimizar.Size = new System.Drawing.Size(231, 22);
            this.ClientesToolStripMenuMinimizar.Text = "[-] Minimizar clientes";
            this.ClientesToolStripMenuMinimizar.Click += new System.EventHandler(this.MinimizarControles);
            // 
            // toolStripSeparatorAdmin
            // 
            this.toolStripSeparatorAdmin.Name = "toolStripSeparatorAdmin";
            this.toolStripSeparatorAdmin.Size = new System.Drawing.Size(228, 6);
            this.toolStripSeparatorAdmin.Visible = false;
            // 
            // toolStripMenuCargarTodos
            // 
            this.toolStripMenuCargarTodos.Enabled = false;
            this.toolStripMenuCargarTodos.Name = "toolStripMenuCargarTodos";
            this.toolStripMenuCargarTodos.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuCargarTodos.Text = "Cargar clientes (Admin)";
            this.toolStripMenuCargarTodos.Visible = false;
            this.toolStripMenuCargarTodos.Click += new System.EventHandler(this.CargarTodosClientes);
            // 
            // ToolStripMenuCargarContactos
            // 
            this.ToolStripMenuCargarContactos.Enabled = false;
            this.ToolStripMenuCargarContactos.Name = "ToolStripMenuCargarContactos";
            this.ToolStripMenuCargarContactos.Size = new System.Drawing.Size(231, 22);
            this.ToolStripMenuCargarContactos.Text = "Cargar contactos (Admin)";
            this.ToolStripMenuCargarContactos.Visible = false;
            this.ToolStripMenuCargarContactos.Click += new System.EventHandler(this.CargarTodosContactos);
            // 
            // ToolStripMenuUsuarios
            // 
            this.ToolStripMenuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolesToolStripMenuItem,
            this.nuevoUsuarioToolStripMenuItem});
            this.ToolStripMenuUsuarios.Name = "ToolStripMenuUsuarios";
            this.ToolStripMenuUsuarios.Size = new System.Drawing.Size(64, 20);
            this.ToolStripMenuUsuarios.Text = "Usuarios";
            this.ToolStripMenuUsuarios.Visible = false;
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.GestionarRoles);
            // 
            // nuevoUsuarioToolStripMenuItem
            // 
            this.nuevoUsuarioToolStripMenuItem.Name = "nuevoUsuarioToolStripMenuItem";
            this.nuevoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoUsuarioToolStripMenuItem.Text = "Nuevo Usuario";
            this.nuevoUsuarioToolStripMenuItem.Click += new System.EventHandler(this.nuevoUsuarioToolStripMenuItem_Click);
            // 
            // ToolStripMenuFiltros
            // 
            this.ToolStripMenuFiltros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FiltroEstado});
            this.ToolStripMenuFiltros.Name = "ToolStripMenuFiltros";
            this.ToolStripMenuFiltros.Size = new System.Drawing.Size(49, 20);
            this.ToolStripMenuFiltros.Text = "Filtrar";
            // 
            // FiltroEstado
            // 
            this.FiltroEstado.CheckOnClick = true;
            this.FiltroEstado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FiltroEstadoUrgente,
            this.FiltroEstadoAtencion,
            this.FiltroEstadoNormal});
            this.FiltroEstado.Name = "FiltroEstado";
            this.FiltroEstado.Size = new System.Drawing.Size(130, 22);
            this.FiltroEstado.Text = "Por Estado";
            this.FiltroEstado.CheckedChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstado.CheckStateChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstado.Click += new System.EventHandler(this.FiltrarClientes);
            // 
            // FiltroEstadoUrgente
            // 
            this.FiltroEstadoUrgente.Checked = true;
            this.FiltroEstadoUrgente.CheckOnClick = true;
            this.FiltroEstadoUrgente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FiltroEstadoUrgente.Name = "FiltroEstadoUrgente";
            this.FiltroEstadoUrgente.Size = new System.Drawing.Size(122, 22);
            this.FiltroEstadoUrgente.Text = "Urgente";
            this.FiltroEstadoUrgente.CheckedChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstadoUrgente.CheckStateChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstadoUrgente.Click += new System.EventHandler(this.FiltrarClientes);
            // 
            // FiltroEstadoAtencion
            // 
            this.FiltroEstadoAtencion.CheckOnClick = true;
            this.FiltroEstadoAtencion.Name = "FiltroEstadoAtencion";
            this.FiltroEstadoAtencion.Size = new System.Drawing.Size(122, 22);
            this.FiltroEstadoAtencion.Text = "Atención";
            this.FiltroEstadoAtencion.CheckedChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstadoAtencion.CheckStateChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstadoAtencion.Click += new System.EventHandler(this.FiltrarClientes);
            // 
            // FiltroEstadoNormal
            // 
            this.FiltroEstadoNormal.CheckOnClick = true;
            this.FiltroEstadoNormal.Name = "FiltroEstadoNormal";
            this.FiltroEstadoNormal.Size = new System.Drawing.Size(122, 22);
            this.FiltroEstadoNormal.Text = "Normal";
            this.FiltroEstadoNormal.CheckedChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstadoNormal.CheckStateChanged += new System.EventHandler(this.FiltrarClientes);
            this.FiltroEstadoNormal.Click += new System.EventHandler(this.FiltrarClientes);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.helpToolStripMenuItem.Text = "&Ayuda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 640);
            this.Controls.Add(this.tableLayoutClientes);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Clientes 2Secure";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonNuevo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutClientes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuNuevoCliente;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuCargarClientes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton ToolStripButtonMinimizar;
        private System.Windows.Forms.ToolStripButton ToolStripButtonCargarClientes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMensaje;
        private System.Windows.Forms.ToolStripMenuItem ClientesToolStripMenuMinimizar;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuUsuarios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorAdmin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCargarTodos;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCargarContactos;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuCargarContactos;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuFiltros;
        private System.Windows.Forms.ToolStripMenuItem FiltroEstado;
        private System.Windows.Forms.ToolStripMenuItem FiltroEstadoUrgente;
        private System.Windows.Forms.ToolStripMenuItem FiltroEstadoAtencion;
        private System.Windows.Forms.ToolStripMenuItem FiltroEstadoNormal;
    }
}

