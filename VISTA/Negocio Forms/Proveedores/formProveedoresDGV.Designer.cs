namespace VISTA.Negocio_Forms.Proveedores
{
    partial class formProveedoresDGV
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
            panel1 = new Panel();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            txtTextoBuscar = new TextBox();
            cmbBuscarPor = new ComboBox();
            label1 = new Label();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(778, 104);
            panel1.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Red;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 20;
            btnCerrar.Location = new Point(751, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 8;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(362, 62);
            label3.Name = "label3";
            label3.Size = new Size(302, 29);
            label3.TabIndex = 3;
            label3.Text = "Administrar Proveedores";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Magneto", 36F, FontStyle.Bold);
            label2.Location = new Point(324, 4);
            label2.Name = "label2";
            label2.Size = new Size(376, 58);
            label2.TabIndex = 2;
            label2.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtTextoBuscar
            // 
            txtTextoBuscar.Location = new Point(572, 128);
            txtTextoBuscar.Name = "txtTextoBuscar";
            txtTextoBuscar.Size = new Size(189, 23);
            txtTextoBuscar.TabIndex = 14;
            // 
            // cmbBuscarPor
            // 
            cmbBuscarPor.FormattingEnabled = true;
            cmbBuscarPor.Location = new Point(405, 129);
            cmbBuscarPor.Name = "cmbBuscarPor";
            cmbBuscarPor.Size = new Size(161, 23);
            cmbBuscarPor.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(324, 128);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 12;
            label1.Text = "Buscar Por";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Black;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9.75F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(193, 121);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 30);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Black;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 9.75F);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(104, 121);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 30);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar ";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Black;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9.75F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(15, 121);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 30);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 157);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(746, 239);
            dataGridView1.TabIndex = 8;
            // 
            // formProveedoresDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 89, 109);
            ClientSize = new Size(777, 410);
            Controls.Add(txtTextoBuscar);
            Controls.Add(cmbBuscarPor);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formProveedoresDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formProveedoresDGV";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox txtTextoBuscar;
        private ComboBox cmbBuscarPor;
        private Label label1;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}