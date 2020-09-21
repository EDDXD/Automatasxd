namespace PrinterLanguage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rtxtCodigo = new System.Windows.Forms.RichTextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.lblNumRenglon = new System.Windows.Forms.Label();
            this.txtNumRenglon = new System.Windows.Forms.TextBox();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.lblSubCadenaAEvaluar = new System.Windows.Forms.Label();
            this.lblCadenaDeTokens = new System.Windows.Forms.Label();
            this.txtSubCadenaAEvaluar = new System.Windows.Forms.TextBox();
            this.txtCadenaDeTokens = new System.Windows.Forms.TextBox();
            this.rtxtCodigoIntermedio = new System.Windows.Forms.RichTextBox();
            this.lblCodigoIntermedio = new System.Windows.Forms.Label();
            this.dgvIdentificadores = new System.Windows.Forms.DataGridView();
            this.dgvConstantesNumericas = new System.Windows.Forms.DataGridView();
            this.lblIdentificadores = new System.Windows.Forms.Label();
            this.lblConstantesNumericas = new System.Windows.Forms.Label();
            this.btnGramatica = new System.Windows.Forms.Button();
            this.rtxtGramatica = new System.Windows.Forms.RichTextBox();
            this.rtxttokens = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesNumericas)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtCodigo
            // 
            this.rtxtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.rtxtCodigo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodigo.ForeColor = System.Drawing.Color.Crimson;
            this.rtxtCodigo.Location = new System.Drawing.Point(12, 12);
            this.rtxtCodigo.Name = "rtxtCodigo";
            this.rtxtCodigo.Size = new System.Drawing.Size(400, 150);
            this.rtxtCodigo.TabIndex = 0;
            this.rtxtCodigo.Text = "";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackColor = System.Drawing.Color.Silver;
            this.btnEjecutar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutar.Location = new System.Drawing.Point(445, 132);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(95, 30);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // lblNumRenglon
            // 
            this.lblNumRenglon.AutoSize = true;
            this.lblNumRenglon.Location = new System.Drawing.Point(441, 59);
            this.lblNumRenglon.Name = "lblNumRenglon";
            this.lblNumRenglon.Size = new System.Drawing.Size(168, 28);
            this.lblNumRenglon.TabIndex = 0;
            this.lblNumRenglon.Text = "# de renglón";
            // 
            // txtNumRenglon
            // 
            this.txtNumRenglon.Enabled = false;
            this.txtNumRenglon.Location = new System.Drawing.Point(469, 86);
            this.txtNumRenglon.Name = "txtNumRenglon";
            this.txtNumRenglon.Size = new System.Drawing.Size(50, 37);
            this.txtNumRenglon.TabIndex = 0;
            this.txtNumRenglon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackColor = System.Drawing.Color.Silver;
            this.btnCargarArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCargarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarArchivo.Location = new System.Drawing.Point(422, 12);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(150, 30);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "Cargar Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = false;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // lblSubCadenaAEvaluar
            // 
            this.lblSubCadenaAEvaluar.AutoSize = true;
            this.lblSubCadenaAEvaluar.Location = new System.Drawing.Point(12, 175);
            this.lblSubCadenaAEvaluar.Name = "lblSubCadenaAEvaluar";
            this.lblSubCadenaAEvaluar.Size = new System.Drawing.Size(278, 28);
            this.lblSubCadenaAEvaluar.TabIndex = 0;
            this.lblSubCadenaAEvaluar.Text = "Sub-cadena a evaluar";
            // 
            // lblCadenaDeTokens
            // 
            this.lblCadenaDeTokens.AutoSize = true;
            this.lblCadenaDeTokens.Location = new System.Drawing.Point(12, 237);
            this.lblCadenaDeTokens.Name = "lblCadenaDeTokens";
            this.lblCadenaDeTokens.Size = new System.Drawing.Size(236, 28);
            this.lblCadenaDeTokens.TabIndex = 0;
            this.lblCadenaDeTokens.Text = "Cadena de tokens";
            // 
            // txtSubCadenaAEvaluar
            // 
            this.txtSubCadenaAEvaluar.Location = new System.Drawing.Point(12, 197);
            this.txtSubCadenaAEvaluar.Name = "txtSubCadenaAEvaluar";
            this.txtSubCadenaAEvaluar.Size = new System.Drawing.Size(400, 37);
            this.txtSubCadenaAEvaluar.TabIndex = 0;
            // 
            // txtCadenaDeTokens
            // 
            this.txtCadenaDeTokens.Location = new System.Drawing.Point(12, 259);
            this.txtCadenaDeTokens.Name = "txtCadenaDeTokens";
            this.txtCadenaDeTokens.Size = new System.Drawing.Size(400, 37);
            this.txtCadenaDeTokens.TabIndex = 0;
            // 
            // rtxtCodigoIntermedio
            // 
            this.rtxtCodigoIntermedio.BackColor = System.Drawing.Color.Black;
            this.rtxtCodigoIntermedio.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodigoIntermedio.ForeColor = System.Drawing.Color.White;
            this.rtxtCodigoIntermedio.Location = new System.Drawing.Point(12, 321);
            this.rtxtCodigoIntermedio.Name = "rtxtCodigoIntermedio";
            this.rtxtCodigoIntermedio.Size = new System.Drawing.Size(400, 150);
            this.rtxtCodigoIntermedio.TabIndex = 0;
            this.rtxtCodigoIntermedio.Text = "";
            // 
            // lblCodigoIntermedio
            // 
            this.lblCodigoIntermedio.AutoSize = true;
            this.lblCodigoIntermedio.Location = new System.Drawing.Point(12, 299);
            this.lblCodigoIntermedio.Name = "lblCodigoIntermedio";
            this.lblCodigoIntermedio.Size = new System.Drawing.Size(241, 28);
            this.lblCodigoIntermedio.TabIndex = 0;
            this.lblCodigoIntermedio.Text = "Código Intermedio";
            // 
            // dgvIdentificadores
            // 
            this.dgvIdentificadores.AllowUserToAddRows = false;
            this.dgvIdentificadores.AllowUserToDeleteRows = false;
            this.dgvIdentificadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIdentificadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIdentificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIdentificadores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIdentificadores.Location = new System.Drawing.Point(12, 500);
            this.dgvIdentificadores.Name = "dgvIdentificadores";
            this.dgvIdentificadores.RowHeadersWidth = 62;
            this.dgvIdentificadores.Size = new System.Drawing.Size(275, 150);
            this.dgvIdentificadores.TabIndex = 0;
            // 
            // dgvConstantesNumericas
            // 
            this.dgvConstantesNumericas.AllowUserToAddRows = false;
            this.dgvConstantesNumericas.AllowUserToDeleteRows = false;
            this.dgvConstantesNumericas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConstantesNumericas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConstantesNumericas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConstantesNumericas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConstantesNumericas.Location = new System.Drawing.Point(297, 500);
            this.dgvConstantesNumericas.Name = "dgvConstantesNumericas";
            this.dgvConstantesNumericas.RowHeadersWidth = 62;
            this.dgvConstantesNumericas.Size = new System.Drawing.Size(275, 150);
            this.dgvConstantesNumericas.TabIndex = 0;
            // 
            // lblIdentificadores
            // 
            this.lblIdentificadores.AutoSize = true;
            this.lblIdentificadores.Location = new System.Drawing.Point(87, 478);
            this.lblIdentificadores.Name = "lblIdentificadores";
            this.lblIdentificadores.Size = new System.Drawing.Size(191, 28);
            this.lblIdentificadores.TabIndex = 0;
            this.lblIdentificadores.Text = "Identificadores";
            // 
            // lblConstantesNumericas
            // 
            this.lblConstantesNumericas.AutoSize = true;
            this.lblConstantesNumericas.Location = new System.Drawing.Point(341, 478);
            this.lblConstantesNumericas.Name = "lblConstantesNumericas";
            this.lblConstantesNumericas.Size = new System.Drawing.Size(282, 28);
            this.lblConstantesNumericas.TabIndex = 0;
            this.lblConstantesNumericas.Text = "Constantes Numéricas";
            // 
            // btnGramatica
            // 
            this.btnGramatica.Location = new System.Drawing.Point(923, 596);
            this.btnGramatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGramatica.Name = "btnGramatica";
            this.btnGramatica.Size = new System.Drawing.Size(174, 40);
            this.btnGramatica.TabIndex = 3;
            this.btnGramatica.Text = "Gramatica";
            this.btnGramatica.UseVisualStyleBackColor = true;
            this.btnGramatica.Click += new System.EventHandler(this.btnGramatica_Click);
            // 
            // rtxtGramatica
            // 
            this.rtxtGramatica.BackColor = System.Drawing.Color.Black;
            this.rtxtGramatica.ForeColor = System.Drawing.Color.LimeGreen;
            this.rtxtGramatica.Location = new System.Drawing.Point(630, 259);
            this.rtxtGramatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxtGramatica.Name = "rtxtGramatica";
            this.rtxtGramatica.Size = new System.Drawing.Size(673, 229);
            this.rtxtGramatica.TabIndex = 5;
            this.rtxtGramatica.Text = "";
            // 
            // rtxttokens
            // 
            this.rtxttokens.BackColor = System.Drawing.Color.LightGray;
            this.rtxttokens.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxttokens.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rtxttokens.Location = new System.Drawing.Point(626, 14);
            this.rtxttokens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxttokens.Name = "rtxttokens";
            this.rtxttokens.Size = new System.Drawing.Size(673, 229);
            this.rtxttokens.TabIndex = 4;
            this.rtxttokens.Text = "";
            this.rtxttokens.TextChanged += new System.EventHandler(this.rtxttokens_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1877, 793);
            this.Controls.Add(this.rtxtGramatica);
            this.Controls.Add(this.rtxttokens);
            this.Controls.Add(this.btnGramatica);
            this.Controls.Add(this.lblConstantesNumericas);
            this.Controls.Add(this.lblIdentificadores);
            this.Controls.Add(this.dgvConstantesNumericas);
            this.Controls.Add(this.dgvIdentificadores);
            this.Controls.Add(this.lblCodigoIntermedio);
            this.Controls.Add(this.rtxtCodigoIntermedio);
            this.Controls.Add(this.txtCadenaDeTokens);
            this.Controls.Add(this.txtSubCadenaAEvaluar);
            this.Controls.Add(this.lblCadenaDeTokens);
            this.Controls.Add(this.lblSubCadenaAEvaluar);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.txtNumRenglon);
            this.Controls.Add(this.lblNumRenglon);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.rtxtCodigo);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Printer Language";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesNumericas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtCodigo;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Label lblNumRenglon;
        private System.Windows.Forms.TextBox txtNumRenglon;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Label lblSubCadenaAEvaluar;
        private System.Windows.Forms.Label lblCadenaDeTokens;
        private System.Windows.Forms.TextBox txtSubCadenaAEvaluar;
        private System.Windows.Forms.TextBox txtCadenaDeTokens;
        private System.Windows.Forms.RichTextBox rtxtCodigoIntermedio;
        private System.Windows.Forms.Label lblCodigoIntermedio;
        private System.Windows.Forms.DataGridView dgvIdentificadores;
        private System.Windows.Forms.DataGridView dgvConstantesNumericas;
        private System.Windows.Forms.Label lblIdentificadores;
        private System.Windows.Forms.Label lblConstantesNumericas;
        private System.Windows.Forms.Button btnGramatica;
        private System.Windows.Forms.RichTextBox rtxtGramatica;
        private System.Windows.Forms.RichTextBox rtxttokens;
    }
}

