namespace InterfazClientes2Secure
{
    partial class BarraNuevoClienteControl
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
            this.toolStripNuevoCliente = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelCliente = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelEstado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.toolStripNuevoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripNuevoCliente
            // 
            this.toolStripNuevoCliente.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.toolStripNuevoCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelCliente,
            this.toolStripLabelEstado,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripLabel2});
            this.toolStripNuevoCliente.Location = new System.Drawing.Point(0, 0);
            this.toolStripNuevoCliente.Name = "toolStripNuevoCliente";
            this.toolStripNuevoCliente.Size = new System.Drawing.Size(978, 25);
            this.toolStripNuevoCliente.TabIndex = 1;
            this.toolStripNuevoCliente.Text = "Empresa Pepito";
            // 
            // toolStripLabelCliente
            // 
            this.toolStripLabelCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabelCliente.Name = "toolStripLabelCliente";
            this.toolStripLabelCliente.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabelCliente.Text = "Nuevo Cliente";
            // 
            // toolStripLabelEstado
            // 
            this.toolStripLabelEstado.Name = "toolStripLabelEstado";
            this.toolStripLabelEstado.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel1.Text = "Nombre: ";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(112, 22);
            this.toolStripLabel2.Text = "Tipo de asociación: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(900, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.radioButton1.Location = new System.Drawing.Point(472, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Directo";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.radioButton2.Location = new System.Drawing.Point(537, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(103, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Por intermediario";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // BarraNuevoClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStripNuevoCliente);
            this.Name = "BarraNuevoClienteControl";
            this.Size = new System.Drawing.Size(978, 30);
            this.toolStripNuevoCliente.ResumeLayout(false);
            this.toolStripNuevoCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripNuevoCliente;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCliente;
        private System.Windows.Forms.ToolStripLabel toolStripLabelEstado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}
