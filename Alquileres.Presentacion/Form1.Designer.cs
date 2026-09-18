namespace Alquileres.Presentacion
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
            label1 = new Label();
            btnPropiedades = new Button();
            btnAlquileres = new Button();
            BtnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(201, 66);
            label1.Name = "label1";
            label1.Size = new Size(399, 45);
            label1.TabIndex = 0;
            label1.Text = "SISTEMA DE ALQUILERES";
            // 
            // btnPropiedades
            // 
            btnPropiedades.BackColor = SystemColors.ActiveCaptionText;
            btnPropiedades.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPropiedades.ForeColor = SystemColors.ButtonHighlight;
            btnPropiedades.Location = new Point(332, 166);
            btnPropiedades.Name = "btnPropiedades";
            btnPropiedades.Size = new Size(107, 39);
            btnPropiedades.TabIndex = 1;
            btnPropiedades.Text = "PROPIEDADES";
            btnPropiedades.UseVisualStyleBackColor = false;
            btnPropiedades.Click += btnPropiedades_Click;
            // 
            // btnAlquileres
            // 
            btnAlquileres.BackColor = SystemColors.ActiveCaptionText;
            btnAlquileres.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAlquileres.ForeColor = SystemColors.ButtonHighlight;
            btnAlquileres.Location = new Point(332, 223);
            btnAlquileres.Name = "btnAlquileres";
            btnAlquileres.Size = new Size(107, 41);
            btnAlquileres.TabIndex = 2;
            btnAlquileres.Text = "ALQUILERES";
            btnAlquileres.UseVisualStyleBackColor = false;
            btnAlquileres.Click += btnAlquileres_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.BackColor = SystemColors.ActiveCaptionText;
            BtnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            BtnSalir.ForeColor = SystemColors.ButtonHighlight;
            BtnSalir.Location = new Point(332, 284);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(107, 41);
            BtnSalir.TabIndex = 3;
            BtnSalir.Text = "SALIR";
            BtnSalir.UseVisualStyleBackColor = false;
            BtnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnSalir);
            Controls.Add(btnAlquileres);
            Controls.Add(btnPropiedades);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Menu Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnPropiedades;
        private Button btnAlquileres;
        private Button BtnSalir;
    }
}