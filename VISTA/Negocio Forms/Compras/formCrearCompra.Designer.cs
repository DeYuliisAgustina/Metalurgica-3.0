namespace VISTA.Negocio_Forms.Compras
{
    partial class formCrearCompra
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
            label1 = new Label();
            btnAutogenerar = new Button();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panelDatos = new Panel();
            txtDNIProveedorSeleccionado = new TextBox();
            cmbNombresProveedores = new ComboBox();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            cmbMedioPago = new ComboBox();
            label4 = new Label();
            dtpFecha = new DateTimePicker();
            label11 = new Label();
            label9 = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            dgvNotaCompra = new DataGridView();
            btnCrearCompra = new FontAwesome.Sharp.IconButton();
            btnCancelarCompra = new FontAwesome.Sharp.IconButton();
            label10 = new Label();
            txtTotalPagar = new TextBox();
            gbDetalleEstado = new GroupBox();
            cmbEstadoNotaCompra = new ComboBox();
            label5 = new Label();
            btnModificarDetalle = new FontAwesome.Sharp.IconButton();
            btnAgregarDetalle = new FontAwesome.Sharp.IconButton();
            label14 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotaCompra).BeginInit();
            gbDetalleEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAutogenerar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(827, 143);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(374, 106);
            label1.Name = "label1";
            label1.Size = new Size(162, 17);
            label1.TabIndex = 4;
            label1.Text = "Número Nota de Compra:";
            // 
            // btnAutogenerar
            // 
            btnAutogenerar.BackColor = Color.FromArgb(192, 203, 220);
            btnAutogenerar.FlatStyle = FlatStyle.Flat;
            btnAutogenerar.Location = new Point(542, 104);
            btnAutogenerar.Name = "btnAutogenerar";
            btnAutogenerar.Size = new Size(105, 23);
            btnAutogenerar.TabIndex = 2;
            btnAutogenerar.Text = "AUTOGENERADO";
            btnAutogenerar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(386, 62);
            label3.Name = "label3";
            label3.Size = new Size(244, 29);
            label3.TabIndex = 3;
            label3.Text = "NOTA DE COMPRA";
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
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 143);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.LightGray;
            panelDatos.Controls.Add(txtDNIProveedorSeleccionado);
            panelDatos.Controls.Add(cmbNombresProveedores);
            panelDatos.Controls.Add(btnAgregar);
            panelDatos.Controls.Add(cmbMedioPago);
            panelDatos.Controls.Add(label4);
            panelDatos.Controls.Add(dtpFecha);
            panelDatos.Controls.Add(label11);
            panelDatos.Controls.Add(label9);
            panelDatos.Controls.Add(label7);
            panelDatos.Location = new Point(15, 148);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(794, 116);
            panelDatos.TabIndex = 2;
            // 
            // txtDNIProveedorSeleccionado
            // 
            txtDNIProveedorSeleccionado.Location = new Point(590, 10);
            txtDNIProveedorSeleccionado.Name = "txtDNIProveedorSeleccionado";
            txtDNIProveedorSeleccionado.Size = new Size(195, 23);
            txtDNIProveedorSeleccionado.TabIndex = 31;
            // 
            // cmbNombresProveedores
            // 
            cmbNombresProveedores.FormattingEnabled = true;
            cmbNombresProveedores.Location = new Point(129, 54);
            cmbNombresProveedores.Name = "cmbNombresProveedores";
            cmbNombresProveedores.Size = new Size(227, 23);
            cmbNombresProveedores.TabIndex = 30;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Black;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9.75F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAgregar.IconColor = Color.Lime;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.IconSize = 20;
            btnAgregar.ImageAlign = ContentAlignment.MiddleRight;
            btnAgregar.Location = new Point(558, 80);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(227, 34);
            btnAgregar.TabIndex = 29;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(590, 51);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(195, 23);
            cmbMedioPago.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(468, 55);
            label4.Name = "label4";
            label4.Size = new Size(102, 17);
            label4.TabIndex = 27;
            label4.Text = "Medio de Pago:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(129, 12);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(227, 23);
            dtpFecha.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.Location = new Point(8, 16);
            label11.Name = "label11";
            label11.Size = new Size(97, 17);
            label11.TabIndex = 25;
            label11.Text = "Fecha Registro:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(468, 12);
            label9.Name = "label9";
            label9.Size = new Size(98, 17);
            label9.TabIndex = 8;
            label9.Text = "DNI Proveedor:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(7, 59);
            label7.Name = "label7";
            label7.Size = new Size(125, 17);
            label7.TabIndex = 6;
            label7.Text = "Nombre Proveedor:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvNotaCompra);
            groupBox1.Location = new Point(15, 339);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(793, 236);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // dgvNotaCompra
            // 
            dgvNotaCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotaCompra.Location = new Point(8, 16);
            dgvNotaCompra.Name = "dgvNotaCompra";
            dgvNotaCompra.Size = new Size(777, 211);
            dgvNotaCompra.TabIndex = 0;
            // 
            // btnCrearCompra
            // 
            btnCrearCompra.BackColor = Color.Black;
            btnCrearCompra.FlatStyle = FlatStyle.Flat;
            btnCrearCompra.Font = new Font("Segoe UI", 9.75F);
            btnCrearCompra.ForeColor = Color.White;
            btnCrearCompra.IconChar = FontAwesome.Sharp.IconChar.Tag;
            btnCrearCompra.IconColor = Color.White;
            btnCrearCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCrearCompra.IconSize = 23;
            btnCrearCompra.ImageAlign = ContentAlignment.MiddleRight;
            btnCrearCompra.Location = new Point(14, 581);
            btnCrearCompra.Name = "btnCrearCompra";
            btnCrearCompra.Size = new Size(138, 35);
            btnCrearCompra.TabIndex = 16;
            btnCrearCompra.Text = "Crear Compra";
            btnCrearCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCrearCompra.UseVisualStyleBackColor = false;
            // 
            // btnCancelarCompra
            // 
            btnCancelarCompra.BackColor = Color.Black;
            btnCancelarCompra.FlatStyle = FlatStyle.Flat;
            btnCancelarCompra.Font = new Font("Segoe UI", 9.75F);
            btnCancelarCompra.ForeColor = Color.White;
            btnCancelarCompra.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelarCompra.IconColor = Color.Red;
            btnCancelarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelarCompra.IconSize = 23;
            btnCancelarCompra.Location = new Point(172, 581);
            btnCancelarCompra.Name = "btnCancelarCompra";
            btnCancelarCompra.Size = new Size(148, 35);
            btnCancelarCompra.TabIndex = 17;
            btnCancelarCompra.Text = "Cancelar Compra";
            btnCancelarCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelarCompra.UseVisualStyleBackColor = false;
            btnCancelarCompra.Click += btnCancelarCompra_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(593, 589);
            label10.Name = "label10";
            label10.Size = new Size(101, 21);
            label10.TabIndex = 18;
            label10.Text = "Total a pagar:";
            // 
            // txtTotalPagar
            // 
            txtTotalPagar.Location = new Point(700, 589);
            txtTotalPagar.Name = "txtTotalPagar";
            txtTotalPagar.Size = new Size(100, 23);
            txtTotalPagar.TabIndex = 0;
            // 
            // gbDetalleEstado
            // 
            gbDetalleEstado.BackColor = Color.White;
            gbDetalleEstado.Controls.Add(cmbEstadoNotaCompra);
            gbDetalleEstado.Controls.Add(label5);
            gbDetalleEstado.Controls.Add(btnModificarDetalle);
            gbDetalleEstado.Controls.Add(btnAgregarDetalle);
            gbDetalleEstado.Controls.Add(label14);
            gbDetalleEstado.Location = new Point(18, 274);
            gbDetalleEstado.Name = "gbDetalleEstado";
            gbDetalleEstado.Size = new Size(791, 64);
            gbDetalleEstado.TabIndex = 23;
            gbDetalleEstado.TabStop = false;
            // 
            // cmbEstadoNotaCompra
            // 
            cmbEstadoNotaCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoNotaCompra.FormattingEnabled = true;
            cmbEstadoNotaCompra.Location = new Point(554, 25);
            cmbEstadoNotaCompra.Name = "cmbEstadoNotaCompra";
            cmbEstadoNotaCompra.Size = new Size(216, 23);
            cmbEstadoNotaCompra.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(404, 25);
            label5.Name = "label5";
            label5.Size = new Size(151, 20);
            label5.TabIndex = 31;
            label5.Text = "Estado Nota Compra:";
            // 
            // btnModificarDetalle
            // 
            btnModificarDetalle.BackColor = Color.Black;
            btnModificarDetalle.FlatStyle = FlatStyle.Flat;
            btnModificarDetalle.Font = new Font("Segoe UI", 9.75F);
            btnModificarDetalle.ForeColor = Color.White;
            btnModificarDetalle.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnModificarDetalle.IconColor = Color.Red;
            btnModificarDetalle.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnModificarDetalle.IconSize = 25;
            btnModificarDetalle.ImageAlign = ContentAlignment.MiddleRight;
            btnModificarDetalle.Location = new Point(272, 18);
            btnModificarDetalle.Name = "btnModificarDetalle";
            btnModificarDetalle.Size = new Size(103, 35);
            btnModificarDetalle.TabIndex = 34;
            btnModificarDetalle.Text = "Modificar";
            btnModificarDetalle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnModificarDetalle.UseVisualStyleBackColor = false;
            btnModificarDetalle.Click += btnModificarDetalle_Click;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.BackColor = Color.Black;
            btnAgregarDetalle.FlatStyle = FlatStyle.Flat;
            btnAgregarDetalle.Font = new Font("Segoe UI", 9.75F);
            btnAgregarDetalle.ForeColor = Color.White;
            btnAgregarDetalle.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAgregarDetalle.IconColor = Color.Lime;
            btnAgregarDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarDetalle.IconSize = 20;
            btnAgregarDetalle.ImageAlign = ContentAlignment.MiddleRight;
            btnAgregarDetalle.Location = new Point(169, 18);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(97, 35);
            btnAgregarDetalle.TabIndex = 33;
            btnAgregarDetalle.Text = "Agregar";
            btnAgregarDetalle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregarDetalle.UseVisualStyleBackColor = false;
            btnAgregarDetalle.Click += this.btnAgregarDetalle_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(14, 27);
            label14.Name = "label14";
            label14.Size = new Size(154, 17);
            label14.TabIndex = 32;
            label14.Text = "Detalle Nota de Compra:";
            // 
            // formCrearCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(826, 624);
            Controls.Add(gbDetalleEstado);
            Controls.Add(txtTotalPagar);
            Controls.Add(label10);
            Controls.Add(btnCancelarCompra);
            Controls.Add(btnCrearCompra);
            Controls.Add(groupBox1);
            Controls.Add(panelDatos);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formCrearCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formCrearCompra";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNotaCompra).EndInit();
            gbDetalleEstado.ResumeLayout(false);
            gbDetalleEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btnAutogenerar;
        private Label label1;
        private Panel panelDatos;
        private Label label9;
        private Label label7;
        private GroupBox groupBox1;
        private DataGridView dgvNotaCompra;
        private FontAwesome.Sharp.IconButton btnCrearCompra;
        private FontAwesome.Sharp.IconButton btnCancelarCompra;
        private Label label10;
        private TextBox txtTotalPagar;
        private DateTimePicker dtpFecha;
        private Label label11;
        private ComboBox cmbMedioPago;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private GroupBox gbDetalleEstado;
        private ComboBox cmbEstadoNotaCompra;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnModificarDetalle;
        private FontAwesome.Sharp.IconButton btnAgregarDetalle;
        private Label label14;
        private TextBox txtDNIProveedorSeleccionado;
        private ComboBox cmbNombresProveedores;
    }
}