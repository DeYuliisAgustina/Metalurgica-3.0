namespace VISTA.Negocio_Forms.Ventas
{
    partial class formDetalleVenta
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
            pictureBox1 = new PictureBox();
            label8 = new Label();
            label7 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            textBox6 = new TextBox();
            label9 = new Label();
            label4 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 104);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(219, 58);
            label8.Name = "label8";
            label8.Size = new Size(201, 20);
            label8.TabIndex = 5;
            label8.Text = "Agregar o Modificar Detalle";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(205, 18);
            label7.Name = "label7";
            label7.Size = new Size(231, 29);
            label7.TabIndex = 4;
            label7.Text = "Detalle Nota Venta";
            // 
            // iconButton3
            // 
            iconButton3.BackColor = Color.Black;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Microsoft Sans Serif", 11.25F);
            iconButton3.ForeColor = Color.White;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Close;
            iconButton3.IconColor = Color.Red;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 20;
            iconButton3.ImageAlign = ContentAlignment.MiddleRight;
            iconButton3.Location = new Point(270, 300);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(0, 0, 8, 0);
            iconButton3.Size = new Size(172, 27);
            iconButton3.TabIndex = 18;
            iconButton3.Text = "Cancelar";
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.Black;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Microsoft Sans Serif", 11.25F);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Check;
            iconButton1.IconColor = Color.Lime;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 20;
            iconButton1.ImageAlign = ContentAlignment.MiddleRight;
            iconButton1.Location = new Point(68, 300);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(0, 0, 8, 0);
            iconButton1.Size = new Size(172, 27);
            iconButton1.TabIndex = 17;
            iconButton1.Text = "Aceptar";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(iconButton2);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(13, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(490, 180);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Deatalle Nota de Venta";
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.Black;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI", 9.75F);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 20;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(397, 35);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(80, 33);
            iconButton2.TabIndex = 17;
            iconButton2.Text = "Buscar";
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(175, 80);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(216, 29);
            numericUpDown1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(175, 37);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(216, 29);
            textBox2.TabIndex = 14;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(175, 123);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(216, 29);
            textBox6.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(19, 127);
            label9.Name = "label9";
            label9.Size = new Size(110, 20);
            label9.TabIndex = 12;
            label9.Text = "Precio Unitario:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(19, 83);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Cantidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(19, 41);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Producto:";
            // 
            // formDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(516, 344);
            Controls.Add(iconButton3);
            Controls.Add(iconButton1);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formDetalleVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formBuscarVenta";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label8;
        private Label label7;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private TextBox textBox6;
        private Label label9;
        private Label label4;
        private Label label1;
    }
}