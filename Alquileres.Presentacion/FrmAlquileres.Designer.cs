namespace Alquileres.Presentacion
{
    partial class FrmAlquileres
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnRegistrar = new Button();
            DvgAlquileres = new DataGridView();
            cmbPropiedad = new ComboBox();
            txtCliente = new TextBox();
            dtpFechaInicio = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)DvgAlquileres).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(245, 19);
            label1.Name = "label1";
            label1.Size = new Size(275, 45);
            label1.TabIndex = 0;
            label1.Text = "NUEVO ALQUILER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(107, 77);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 1;
            label2.Text = "Propiedad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(107, 122);
            label3.Name = "label3";
            label3.Size = new Size(61, 21);
            label3.TabIndex = 2;
            label3.Text = "Cliente:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(107, 169);
            label4.Name = "label4";
            label4.Size = new Size(50, 21);
            label4.TabIndex = 3;
            label4.Text = "Inicio:";
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = SystemColors.ActiveCaptionText;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = SystemColors.ButtonHighlight;
            btnRegistrar.Location = new Point(245, 244);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(155, 42);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "REGISTRAR ALQUILER";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // DvgAlquileres
            // 
            DvgAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DvgAlquileres.Location = new Point(94, 322);
            DvgAlquileres.Name = "DvgAlquileres";
            DvgAlquileres.Size = new Size(401, 150);
            DvgAlquileres.TabIndex = 5;
            // 
            // cmbPropiedad
            // 
            cmbPropiedad.FormattingEnabled = true;
            cmbPropiedad.Location = new Point(200, 80);
            cmbPropiedad.Name = "cmbPropiedad";
            cmbPropiedad.Size = new Size(200, 23);
            cmbPropiedad.TabIndex = 6;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(200, 125);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(200, 23);
            txtCliente.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(200, 167);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(200, 23);
            dtpFechaInicio.TabIndex = 8;
            // 
            // FrmAlquileres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpFechaInicio);
            Controls.Add(txtCliente);
            Controls.Add(cmbPropiedad);
            Controls.Add(DvgAlquileres);
            Controls.Add(btnRegistrar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAlquileres";
            Text = "Alquileres";
            ((System.ComponentModel.ISupportInitialize)DvgAlquileres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnRegistrar;
        private DataGridView DvgAlquileres;
        private ComboBox cmbPropiedad;
        private TextBox txtCliente;
        private DateTimePicker dtpFechaInicio;
    }
}