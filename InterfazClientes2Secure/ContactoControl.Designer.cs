namespace InterfazClientes2Secure
{
    partial class ContactoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactoControl));
            this.toolStripContacto = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMinimizarContacto = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelContacto = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonEliminarContacto = new System.Windows.Forms.ToolStripButton();
            this.splitContainerContacto = new System.Windows.Forms.SplitContainer();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.labelCorreoContacto = new System.Windows.Forms.Label();
            this.textBoxCelular = new System.Windows.Forms.TextBox();
            this.labelCelularContacto = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.labelTelefonoContacto = new System.Windows.Forms.Label();
            this.textBoxCargo = new System.Windows.Forms.TextBox();
            this.labelCargoContacto = new System.Windows.Forms.Label();
            this.textBoxNombreContacto = new System.Windows.Forms.TextBox();
            this.labelNombreContacto = new System.Windows.Forms.Label();
            this.groupBoxOtros = new System.Windows.Forms.GroupBox();
            this.dateTimePickerContacto = new System.Windows.Forms.DateTimePicker();
            this.labelUltimoContacto = new System.Windows.Forms.Label();
            this.textBoxNotasContacto = new System.Windows.Forms.TextBox();
            this.labelNotasContacto = new System.Windows.Forms.Label();
            this.toolStripContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContacto)).BeginInit();
            this.splitContainerContacto.Panel1.SuspendLayout();
            this.splitContainerContacto.Panel2.SuspendLayout();
            this.splitContainerContacto.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxOtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContacto
            // 
            this.toolStripContacto.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripContacto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMinimizarContacto,
            this.toolStripLabelContacto,
            this.toolStripButtonEliminarContacto});
            this.toolStripContacto.Location = new System.Drawing.Point(0, 0);
            this.toolStripContacto.Name = "toolStripContacto";
            this.toolStripContacto.Size = new System.Drawing.Size(902, 25);
            this.toolStripContacto.TabIndex = 2;
            this.toolStripContacto.Text = "Empresa Pepito";
            // 
            // toolStripButtonMinimizarContacto
            // 
            this.toolStripButtonMinimizarContacto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMinimizarContacto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripButtonMinimizarContacto.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMinimizarContacto.Image")));
            this.toolStripButtonMinimizarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMinimizarContacto.Name = "toolStripButtonMinimizarContacto";
            this.toolStripButtonMinimizarContacto.Size = new System.Drawing.Size(24, 22);
            this.toolStripButtonMinimizarContacto.Text = "[-]";
            this.toolStripButtonMinimizarContacto.ToolTipText = "Minimizar";
            this.toolStripButtonMinimizarContacto.Click += new System.EventHandler(this.Minimizar);
            // 
            // toolStripLabelContacto
            // 
            this.toolStripLabelContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabelContacto.Name = "toolStripLabelContacto";
            this.toolStripLabelContacto.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabelContacto.Text = "Pepito Pérez";
            // 
            // toolStripButtonEliminarContacto
            // 
            this.toolStripButtonEliminarContacto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonEliminarContacto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEliminarContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonEliminarContacto.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEliminarContacto.Image")));
            this.toolStripButtonEliminarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliminarContacto.Name = "toolStripButtonEliminarContacto";
            this.toolStripButtonEliminarContacto.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEliminarContacto.Text = "X";
            this.toolStripButtonEliminarContacto.ToolTipText = "Eliminar contacto";
            this.toolStripButtonEliminarContacto.Click += new System.EventHandler(this.EliminarContacto);
            // 
            // splitContainerContacto
            // 
            this.splitContainerContacto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerContacto.Location = new System.Drawing.Point(0, 25);
            this.splitContainerContacto.Name = "splitContainerContacto";
            // 
            // splitContainerContacto.Panel1
            // 
            this.splitContainerContacto.Panel1.Controls.Add(this.groupBoxInfo);
            // 
            // splitContainerContacto.Panel2
            // 
            this.splitContainerContacto.Panel2.Controls.Add(this.groupBoxOtros);
            this.splitContainerContacto.Size = new System.Drawing.Size(902, 208);
            this.splitContainerContacto.SplitterDistance = 434;
            this.splitContainerContacto.TabIndex = 3;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.textBoxCorreo);
            this.groupBoxInfo.Controls.Add(this.labelCorreoContacto);
            this.groupBoxInfo.Controls.Add(this.textBoxCelular);
            this.groupBoxInfo.Controls.Add(this.labelCelularContacto);
            this.groupBoxInfo.Controls.Add(this.textBoxTelefono);
            this.groupBoxInfo.Controls.Add(this.labelTelefonoContacto);
            this.groupBoxInfo.Controls.Add(this.textBoxCargo);
            this.groupBoxInfo.Controls.Add(this.labelCargoContacto);
            this.groupBoxInfo.Controls.Add(this.textBoxNombreContacto);
            this.groupBoxInfo.Controls.Add(this.labelNombreContacto);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInfo.ForeColor = System.Drawing.Color.Brown;
            this.groupBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(434, 208);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Información";
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCorreo.Location = new System.Drawing.Point(89, 130);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(330, 24);
            this.textBoxCorreo.TabIndex = 9;
            this.textBoxCorreo.Text = "ra.pepito@stable.org";
            // 
            // labelCorreoContacto
            // 
            this.labelCorreoContacto.AutoSize = true;
            this.labelCorreoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorreoContacto.Location = new System.Drawing.Point(6, 133);
            this.labelCorreoContacto.Name = "labelCorreoContacto";
            this.labelCorreoContacto.Size = new System.Drawing.Size(59, 18);
            this.labelCorreoContacto.TabIndex = 8;
            this.labelCorreoContacto.Text = "Correo:";
            // 
            // textBoxCelular
            // 
            this.textBoxCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCelular.Location = new System.Drawing.Point(89, 106);
            this.textBoxCelular.Name = "textBoxCelular";
            this.textBoxCelular.Size = new System.Drawing.Size(330, 24);
            this.textBoxCelular.TabIndex = 7;
            this.textBoxCelular.Text = "99-999-99";
            // 
            // labelCelularContacto
            // 
            this.labelCelularContacto.AutoSize = true;
            this.labelCelularContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCelularContacto.Location = new System.Drawing.Point(6, 109);
            this.labelCelularContacto.Name = "labelCelularContacto";
            this.labelCelularContacto.Size = new System.Drawing.Size(58, 18);
            this.labelCelularContacto.TabIndex = 6;
            this.labelCelularContacto.Text = "Celular:";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTelefono.Location = new System.Drawing.Point(89, 82);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(330, 24);
            this.textBoxTelefono.TabIndex = 5;
            this.textBoxTelefono.Text = "9999999";
            // 
            // labelTelefonoContacto
            // 
            this.labelTelefonoContacto.AutoSize = true;
            this.labelTelefonoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefonoContacto.Location = new System.Drawing.Point(6, 85);
            this.labelTelefonoContacto.Name = "labelTelefonoContacto";
            this.labelTelefonoContacto.Size = new System.Drawing.Size(70, 18);
            this.labelTelefonoContacto.TabIndex = 4;
            this.labelTelefonoContacto.Text = "Teléfono:";
            // 
            // textBoxCargo
            // 
            this.textBoxCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCargo.Location = new System.Drawing.Point(89, 55);
            this.textBoxCargo.Name = "textBoxCargo";
            this.textBoxCargo.Size = new System.Drawing.Size(330, 24);
            this.textBoxCargo.TabIndex = 3;
            this.textBoxCargo.Text = "Lider Desarrollo";
            // 
            // labelCargoContacto
            // 
            this.labelCargoContacto.AutoSize = true;
            this.labelCargoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCargoContacto.Location = new System.Drawing.Point(6, 58);
            this.labelCargoContacto.Name = "labelCargoContacto";
            this.labelCargoContacto.Size = new System.Drawing.Size(53, 18);
            this.labelCargoContacto.TabIndex = 2;
            this.labelCargoContacto.Text = "Cargo:";
            // 
            // textBoxNombreContacto
            // 
            this.textBoxNombreContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombreContacto.Location = new System.Drawing.Point(89, 28);
            this.textBoxNombreContacto.Name = "textBoxNombreContacto";
            this.textBoxNombreContacto.Size = new System.Drawing.Size(330, 24);
            this.textBoxNombreContacto.TabIndex = 1;
            this.textBoxNombreContacto.Text = "Juan Ramírez Pérez";
            this.textBoxNombreContacto.TextChanged += new System.EventHandler(this.textBoxNombreContacto_TextChanged);
            // 
            // labelNombreContacto
            // 
            this.labelNombreContacto.AutoSize = true;
            this.labelNombreContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreContacto.Location = new System.Drawing.Point(6, 31);
            this.labelNombreContacto.Name = "labelNombreContacto";
            this.labelNombreContacto.Size = new System.Drawing.Size(66, 18);
            this.labelNombreContacto.TabIndex = 0;
            this.labelNombreContacto.Text = "Nombre:";
            // 
            // groupBoxOtros
            // 
            this.groupBoxOtros.Controls.Add(this.dateTimePickerContacto);
            this.groupBoxOtros.Controls.Add(this.labelUltimoContacto);
            this.groupBoxOtros.Controls.Add(this.textBoxNotasContacto);
            this.groupBoxOtros.Controls.Add(this.labelNotasContacto);
            this.groupBoxOtros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOtros.ForeColor = System.Drawing.Color.Brown;
            this.groupBoxOtros.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOtros.Name = "groupBoxOtros";
            this.groupBoxOtros.Size = new System.Drawing.Size(464, 208);
            this.groupBoxOtros.TabIndex = 0;
            this.groupBoxOtros.TabStop = false;
            this.groupBoxOtros.Text = "Otros";
            // 
            // dateTimePickerContacto
            // 
            this.dateTimePickerContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerContacto.Location = new System.Drawing.Point(136, 29);
            this.dateTimePickerContacto.Name = "dateTimePickerContacto";
            this.dateTimePickerContacto.Size = new System.Drawing.Size(250, 21);
            this.dateTimePickerContacto.TabIndex = 11;
            // 
            // labelUltimoContacto
            // 
            this.labelUltimoContacto.AutoSize = true;
            this.labelUltimoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUltimoContacto.Location = new System.Drawing.Point(6, 31);
            this.labelUltimoContacto.Name = "labelUltimoContacto";
            this.labelUltimoContacto.Size = new System.Drawing.Size(121, 18);
            this.labelUltimoContacto.TabIndex = 10;
            this.labelUltimoContacto.Text = "Último contacto: ";
            // 
            // textBoxNotasContacto
            // 
            this.textBoxNotasContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotasContacto.Location = new System.Drawing.Point(9, 79);
            this.textBoxNotasContacto.Multiline = true;
            this.textBoxNotasContacto.Name = "textBoxNotasContacto";
            this.textBoxNotasContacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotasContacto.Size = new System.Drawing.Size(437, 113);
            this.textBoxNotasContacto.TabIndex = 2;
            // 
            // labelNotasContacto
            // 
            this.labelNotasContacto.AutoSize = true;
            this.labelNotasContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotasContacto.Location = new System.Drawing.Point(6, 58);
            this.labelNotasContacto.Name = "labelNotasContacto";
            this.labelNotasContacto.Size = new System.Drawing.Size(52, 18);
            this.labelNotasContacto.TabIndex = 1;
            this.labelNotasContacto.Text = "Notas:";
            // 
            // ContactoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerContacto);
            this.Controls.Add(this.toolStripContacto);
            this.Name = "ContactoControl";
            this.Size = new System.Drawing.Size(902, 233);
            this.toolStripContacto.ResumeLayout(false);
            this.toolStripContacto.PerformLayout();
            this.splitContainerContacto.Panel1.ResumeLayout(false);
            this.splitContainerContacto.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContacto)).EndInit();
            this.splitContainerContacto.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxOtros.ResumeLayout(false);
            this.groupBoxOtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripContacto;
        private System.Windows.Forms.ToolStripButton toolStripButtonMinimizarContacto;
        private System.Windows.Forms.ToolStripLabel toolStripLabelContacto;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminarContacto;
        private System.Windows.Forms.SplitContainer splitContainerContacto;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxOtros;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.Label labelCorreoContacto;
        private System.Windows.Forms.TextBox textBoxCelular;
        private System.Windows.Forms.Label labelCelularContacto;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label labelTelefonoContacto;
        private System.Windows.Forms.TextBox textBoxCargo;
        private System.Windows.Forms.Label labelCargoContacto;
        private System.Windows.Forms.TextBox textBoxNombreContacto;
        private System.Windows.Forms.Label labelNombreContacto;
        private System.Windows.Forms.TextBox textBoxNotasContacto;
        private System.Windows.Forms.Label labelNotasContacto;
        private System.Windows.Forms.DateTimePicker dateTimePickerContacto;
        private System.Windows.Forms.Label labelUltimoContacto;
    }
}
