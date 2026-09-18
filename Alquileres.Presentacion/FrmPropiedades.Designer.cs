
namespace Alquileres.Presentacion
{
    partial class FrmPropiedades
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
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnAgregar = new Button();
            btnCargar = new Button();
            dvgPropiedades = new DataGridView();
            txtDireccion = new TextBox();
            txtTipo = new TextBox();
            txtHabitaciones = new TextBox();
            txtBanios = new TextBox();
            cmbEstado = new ComboBox();
            txtPrecio = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dvgPropiedades).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(168, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 45);
            label1.TabIndex = 0;
            label1.Text = "PROPIEDADES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(133, 79);
            label2.Name = "label2";
            label2.Size = new Size(65, 17);
            label2.TabIndex = 1;
            label2.Text = "Direccion:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(133, 108);
            label3.Name = "label3";
            label3.Size = new Size(37, 17);
            label3.TabIndex = 2;
            label3.Text = "Tipo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(133, 137);
            label4.Name = "label4";
            label4.Size = new Size(86, 17);
            label4.TabIndex = 3;
            label4.Text = "Habitaciones:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(133, 166);
            label5.Name = "label5";
            label5.Size = new Size(46, 17);
            label5.TabIndex = 4;
            label5.Text = "Baños:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(133, 195);
            label6.Name = "label6";
            label6.Size = new Size(47, 17);
            label6.TabIndex = 5;
            label6.Text = "Precio:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(133, 224);
            label7.Name = "label7";
            label7.Size = new Size(51, 17);
            label7.TabIndex = 6;
            label7.Text = "Estado:";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.ActiveCaptionText;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.ButtonHighlight;
            btnAgregar.Location = new Point(181, 269);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(89, 43);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = SystemColors.ActiveCaptionText;
            btnCargar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargar.ForeColor = SystemColors.ButtonHighlight;
            btnCargar.Location = new Point(289, 269);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(89, 43);
            btnCargar.TabIndex = 8;
            btnCargar.Text = "CARGAR";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // dvgPropiedades
            // 
            dvgPropiedades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgPropiedades.Location = new Point(82, 328);
            dvgPropiedades.Name = "dvgPropiedades";
            dvgPropiedades.Size = new Size(489, 93);
            dvgPropiedades.TabIndex = 9;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(218, 76);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(215, 23);
            txtDireccion.TabIndex = 10;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(218, 105);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(131, 23);
            txtTipo.TabIndex = 11;
            // 
            // txtHabitaciones
            // 
            txtHabitaciones.Location = new Point(218, 134);
            txtHabitaciones.Name = "txtHabitaciones";
            txtHabitaciones.Size = new Size(53, 23);
            txtHabitaciones.TabIndex = 12;
            // 
            // txtBanios
            // 
            txtBanios.Location = new Point(218, 163);
            txtBanios.Name = "txtBanios";
            txtBanios.Size = new Size(53, 23);
            txtBanios.TabIndex = 13;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Disponible" });
            cmbEstado.Location = new Point(218, 221);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(144, 23);
            cmbEstado.TabIndex = 14;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(218, 192);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(73, 23);
            txtPrecio.TabIndex = 15;
            // 
            // FrmPropiedades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPrecio);
            Controls.Add(cmbEstado);
            Controls.Add(txtBanios);
            Controls.Add(txtHabitaciones);
            Controls.Add(txtTipo);
            Controls.Add(txtDireccion);
            Controls.Add(dvgPropiedades);
            Controls.Add(btnCargar);
            Controls.Add(btnAgregar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmPropiedades";
            Text = "Propiedades";
            ((System.ComponentModel.ISupportInitialize)dvgPropiedades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnAgregar;
        private Button btnCargar;
        private DataGridView dvgPropiedades;
        private TextBox txtDireccion;
        private TextBox txtTipo;
        private TextBox txtHabitaciones;
        private TextBox txtBanios;
        private ComboBox cmbEstado;
        private TextBox txtPrecio;
    }
}