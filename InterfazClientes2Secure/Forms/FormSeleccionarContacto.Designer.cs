namespace InterfazClientes2Secure
{
    partial class FormSeleccionarContacto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeleccionarContacto));
            this.listBoxContactos = new System.Windows.Forms.ListBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCambiarContactos = new System.Windows.Forms.Button();
            this.labelCliente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxContactos
            // 
            this.listBoxContactos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxContactos.FormattingEnabled = true;
            this.listBoxContactos.HorizontalScrollbar = true;
            this.listBoxContactos.ItemHeight = 16;
            this.listBoxContactos.Location = new System.Drawing.Point(12, 43);
            this.listBoxContactos.Name = "listBoxContactos";
            this.listBoxContactos.Size = new System.Drawing.Size(270, 276);
            this.listBoxContactos.Sorted = true;
            this.listBoxContactos.TabIndex = 4;
            this.listBoxContactos.SelectedIndexChanged += new System.EventHandler(this.SeleccionarContacto);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAceptar.Location = new System.Drawing.Point(126, 325);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 2;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(207, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonCambiarContactos
            // 
            this.buttonCambiarContactos.Location = new System.Drawing.Point(166, 14);
            this.buttonCambiarContactos.Name = "buttonCambiarContactos";
            this.buttonCambiarContactos.Size = new System.Drawing.Size(116, 23);
            this.buttonCambiarContactos.TabIndex = 1;
            this.buttonCambiarContactos.Tag = "Todos";
            this.buttonCambiarContactos.Text = "Mostrar todos...";
            this.buttonCambiarContactos.UseVisualStyleBackColor = true;
            this.buttonCambiarContactos.Click += new System.EventHandler(this.CambiarContactos);
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.ForeColor = System.Drawing.Color.Brown;
            this.labelCliente.Location = new System.Drawing.Point(9, 17);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(65, 17);
            this.labelCliente.TabIndex = 5;
            this.labelCliente.Text = "2Secure:";
            // 
            // FormSeleccionarContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 360);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.buttonCambiarContactos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.listBoxContactos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeleccionarContacto";
            this.Text = "Seleccionar contacto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxContactos;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonCambiarContactos;
        private System.Windows.Forms.Label labelCliente;
    }
}