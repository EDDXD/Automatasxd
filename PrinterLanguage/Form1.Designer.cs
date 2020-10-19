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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.rtxTipos = new System.Windows.Forms.RichTextBox();
            this.rtxtSemantica = new System.Windows.Forms.RichTextBox();
            this.btnSemantica = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rtxInfijo = new System.Windows.Forms.RichTextBox();
            this.rtxPostfijo = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVerde = new System.Windows.Forms.Panel();
            this.pantalla = new System.Windows.Forms.PictureBox();
            this.impresora = new System.Windows.Forms.PictureBox();
            this.hoja = new System.Windows.Forms.PictureBox();
            this.btnRojo = new System.Windows.Forms.Panel();
            this.btnAmarillo = new System.Windows.Forms.Panel();
            this.hojaEscaner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesNumericas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pantalla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hojaEscaner)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtCodigo
            // 
            this.rtxtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rtxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtCodigo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rtxtCodigo.Location = new System.Drawing.Point(11, 30);
            this.rtxtCodigo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rtxtCodigo.Name = "rtxtCodigo";
            this.rtxtCodigo.Size = new System.Drawing.Size(504, 227);
            this.rtxtCodigo.TabIndex = 0;
            this.rtxtCodigo.Text = "";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEjecutar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutar.Location = new System.Drawing.Point(144, 263);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(91, 30);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // lblNumRenglon
            // 
            this.lblNumRenglon.AutoSize = true;
            this.lblNumRenglon.ForeColor = System.Drawing.Color.Black;
            this.lblNumRenglon.Location = new System.Drawing.Point(373, 271);
            this.lblNumRenglon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumRenglon.Name = "lblNumRenglon";
            this.lblNumRenglon.Size = new System.Drawing.Size(91, 14);
            this.lblNumRenglon.TabIndex = 0;
            this.lblNumRenglon.Text = "# de renglón";
            // 
            // txtNumRenglon
            // 
            this.txtNumRenglon.Enabled = false;
            this.txtNumRenglon.Location = new System.Drawing.Point(481, 268);
            this.txtNumRenglon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNumRenglon.Name = "txtNumRenglon";
            this.txtNumRenglon.Size = new System.Drawing.Size(34, 22);
            this.txtNumRenglon.TabIndex = 0;
            this.txtNumRenglon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCargarArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCargarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarArchivo.Location = new System.Drawing.Point(11, 263);
            this.btnCargarArchivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(129, 30);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "Cargar archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = false;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // lblSubCadenaAEvaluar
            // 
            this.lblSubCadenaAEvaluar.AutoSize = true;
            this.lblSubCadenaAEvaluar.ForeColor = System.Drawing.Color.Black;
            this.lblSubCadenaAEvaluar.Location = new System.Drawing.Point(11, 296);
            this.lblSubCadenaAEvaluar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubCadenaAEvaluar.Name = "lblSubCadenaAEvaluar";
            this.lblSubCadenaAEvaluar.Size = new System.Drawing.Size(140, 14);
            this.lblSubCadenaAEvaluar.TabIndex = 0;
            this.lblSubCadenaAEvaluar.Text = "Subcadena a evaluar";
            // 
            // lblCadenaDeTokens
            // 
            this.lblCadenaDeTokens.AutoSize = true;
            this.lblCadenaDeTokens.ForeColor = System.Drawing.Color.Black;
            this.lblCadenaDeTokens.Location = new System.Drawing.Point(11, 344);
            this.lblCadenaDeTokens.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCadenaDeTokens.Name = "lblCadenaDeTokens";
            this.lblCadenaDeTokens.Size = new System.Drawing.Size(119, 14);
            this.lblCadenaDeTokens.TabIndex = 0;
            this.lblCadenaDeTokens.Text = "Cadena de tokens";
            // 
            // txtSubCadenaAEvaluar
            // 
            this.txtSubCadenaAEvaluar.Enabled = false;
            this.txtSubCadenaAEvaluar.Location = new System.Drawing.Point(11, 313);
            this.txtSubCadenaAEvaluar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSubCadenaAEvaluar.Name = "txtSubCadenaAEvaluar";
            this.txtSubCadenaAEvaluar.Size = new System.Drawing.Size(504, 22);
            this.txtSubCadenaAEvaluar.TabIndex = 0;
            // 
            // txtCadenaDeTokens
            // 
            this.txtCadenaDeTokens.Enabled = false;
            this.txtCadenaDeTokens.Location = new System.Drawing.Point(11, 362);
            this.txtCadenaDeTokens.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCadenaDeTokens.Name = "txtCadenaDeTokens";
            this.txtCadenaDeTokens.Size = new System.Drawing.Size(504, 22);
            this.txtCadenaDeTokens.TabIndex = 0;
            // 
            // rtxtCodigoIntermedio
            // 
            this.rtxtCodigoIntermedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxtCodigoIntermedio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtCodigoIntermedio.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodigoIntermedio.ForeColor = System.Drawing.Color.White;
            this.rtxtCodigoIntermedio.Location = new System.Drawing.Point(526, 30);
            this.rtxtCodigoIntermedio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rtxtCodigoIntermedio.Name = "rtxtCodigoIntermedio";
            this.rtxtCodigoIntermedio.Size = new System.Drawing.Size(384, 228);
            this.rtxtCodigoIntermedio.TabIndex = 0;
            this.rtxtCodigoIntermedio.Text = "";
            // 
            // lblCodigoIntermedio
            // 
            this.lblCodigoIntermedio.AutoSize = true;
            this.lblCodigoIntermedio.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoIntermedio.Location = new System.Drawing.Point(11, 389);
            this.lblCodigoIntermedio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigoIntermedio.Name = "lblCodigoIntermedio";
            this.lblCodigoIntermedio.Size = new System.Drawing.Size(126, 14);
            this.lblCodigoIntermedio.TabIndex = 0;
            this.lblCodigoIntermedio.Text = "Código intermedio";
            // 
            // dgvIdentificadores
            // 
            this.dgvIdentificadores.AllowUserToAddRows = false;
            this.dgvIdentificadores.AllowUserToDeleteRows = false;
            this.dgvIdentificadores.AllowUserToResizeRows = false;
            this.dgvIdentificadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIdentificadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvIdentificadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIdentificadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvIdentificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIdentificadores.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgvIdentificadores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dgvIdentificadores.Location = new System.Drawing.Point(11, 613);
            this.dgvIdentificadores.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvIdentificadores.Name = "dgvIdentificadores";
            this.dgvIdentificadores.RowHeadersVisible = false;
            this.dgvIdentificadores.RowHeadersWidth = 62;
            this.dgvIdentificadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdentificadores.Size = new System.Drawing.Size(324, 185);
            this.dgvIdentificadores.TabIndex = 0;
            // 
            // dgvConstantesNumericas
            // 
            this.dgvConstantesNumericas.AllowUserToAddRows = false;
            this.dgvConstantesNumericas.AllowUserToDeleteRows = false;
            this.dgvConstantesNumericas.AllowUserToResizeRows = false;
            this.dgvConstantesNumericas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConstantesNumericas.BackgroundColor = System.Drawing.Color.White;
            this.dgvConstantesNumericas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConstantesNumericas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgvConstantesNumericas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConstantesNumericas.DefaultCellStyle = dataGridViewCellStyle40;
            this.dgvConstantesNumericas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dgvConstantesNumericas.Location = new System.Drawing.Point(350, 613);
            this.dgvConstantesNumericas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvConstantesNumericas.Name = "dgvConstantesNumericas";
            this.dgvConstantesNumericas.RowHeadersVisible = false;
            this.dgvConstantesNumericas.RowHeadersWidth = 62;
            this.dgvConstantesNumericas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstantesNumericas.Size = new System.Drawing.Size(165, 185);
            this.dgvConstantesNumericas.TabIndex = 0;
            // 
            // lblIdentificadores
            // 
            this.lblIdentificadores.AutoSize = true;
            this.lblIdentificadores.ForeColor = System.Drawing.Color.Black;
            this.lblIdentificadores.Location = new System.Drawing.Point(8, 592);
            this.lblIdentificadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentificadores.Name = "lblIdentificadores";
            this.lblIdentificadores.Size = new System.Drawing.Size(112, 14);
            this.lblIdentificadores.TabIndex = 0;
            this.lblIdentificadores.Text = "Identificadores";
            // 
            // lblConstantesNumericas
            // 
            this.lblConstantesNumericas.AutoSize = true;
            this.lblConstantesNumericas.ForeColor = System.Drawing.Color.Black;
            this.lblConstantesNumericas.Location = new System.Drawing.Point(347, 592);
            this.lblConstantesNumericas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConstantesNumericas.Name = "lblConstantesNumericas";
            this.lblConstantesNumericas.Size = new System.Drawing.Size(147, 14);
            this.lblConstantesNumericas.TabIndex = 0;
            this.lblConstantesNumericas.Text = "Constantes numéricas";
            // 
            // btnGramatica
            // 
            this.btnGramatica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGramatica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGramatica.Location = new System.Drawing.Point(819, 557);
            this.btnGramatica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGramatica.Name = "btnGramatica";
            this.btnGramatica.Size = new System.Drawing.Size(91, 31);
            this.btnGramatica.TabIndex = 3;
            this.btnGramatica.Text = "Sintaxis";
            this.btnGramatica.UseVisualStyleBackColor = false;
            this.btnGramatica.Click += new System.EventHandler(this.btnGramatica_Click);
            // 
            // rtxtGramatica
            // 
            this.rtxtGramatica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rtxtGramatica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtGramatica.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtGramatica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rtxtGramatica.Location = new System.Drawing.Point(526, 283);
            this.rtxtGramatica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtGramatica.Name = "rtxtGramatica";
            this.rtxtGramatica.Size = new System.Drawing.Size(384, 305);
            this.rtxtGramatica.TabIndex = 5;
            this.rtxtGramatica.Text = "";
            // 
            // rtxttokens
            // 
            this.rtxttokens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxttokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxttokens.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxttokens.ForeColor = System.Drawing.Color.White;
            this.rtxttokens.Location = new System.Drawing.Point(11, 410);
            this.rtxttokens.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxttokens.Name = "rtxttokens";
            this.rtxttokens.Size = new System.Drawing.Size(504, 178);
            this.rtxttokens.TabIndex = 4;
            this.rtxttokens.Text = "";
            // 
            // rtxTipos
            // 
            this.rtxTipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxTipos.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxTipos.ForeColor = System.Drawing.Color.White;
            this.rtxTipos.Location = new System.Drawing.Point(921, 30);
            this.rtxTipos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxTipos.Name = "rtxTipos";
            this.rtxTipos.Size = new System.Drawing.Size(384, 228);
            this.rtxTipos.TabIndex = 6;
            this.rtxTipos.Text = "";
            // 
            // rtxtSemantica
            // 
            this.rtxtSemantica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rtxtSemantica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtSemantica.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtSemantica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rtxtSemantica.Location = new System.Drawing.Point(921, 283);
            this.rtxtSemantica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtSemantica.Name = "rtxtSemantica";
            this.rtxtSemantica.Size = new System.Drawing.Size(384, 305);
            this.rtxtSemantica.TabIndex = 7;
            this.rtxtSemantica.Text = "";
            // 
            // btnSemantica
            // 
            this.btnSemantica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSemantica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemantica.Location = new System.Drawing.Point(1214, 557);
            this.btnSemantica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSemantica.Name = "btnSemantica";
            this.btnSemantica.Size = new System.Drawing.Size(91, 31);
            this.btnSemantica.TabIndex = 8;
            this.btnSemantica.Text = "Semántica";
            this.btnSemantica.UseVisualStyleBackColor = false;
            this.btnSemantica.Click += new System.EventHandler(this.btnSemantica_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Consola";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(522, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tokens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(917, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(523, 261);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sintaxis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(917, 263);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Semántica";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(918, 592);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Postfijo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(523, 592);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Infijo";
            // 
            // rtxInfijo
            // 
            this.rtxInfijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxInfijo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxInfijo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxInfijo.ForeColor = System.Drawing.Color.White;
            this.rtxInfijo.Location = new System.Drawing.Point(526, 613);
            this.rtxInfijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxInfijo.Name = "rtxInfijo";
            this.rtxInfijo.Size = new System.Drawing.Size(384, 183);
            this.rtxInfijo.TabIndex = 16;
            this.rtxInfijo.Text = "";
            // 
            // rtxPostfijo
            // 
            this.rtxPostfijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxPostfijo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxPostfijo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxPostfijo.ForeColor = System.Drawing.Color.White;
            this.rtxPostfijo.Location = new System.Drawing.Point(922, 614);
            this.rtxPostfijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxPostfijo.Name = "rtxPostfijo";
            this.rtxPostfijo.Size = new System.Drawing.Size(384, 183);
            this.rtxPostfijo.TabIndex = 17;
            this.rtxPostfijo.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(1510, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "APAGADA";
            // 
            // btnVerde
            // 
            this.btnVerde.BackColor = System.Drawing.Color.Transparent;
            this.btnVerde.BackgroundImage = global::PrinterLanguage.Properties.Resources.boton_verde;
            this.btnVerde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerde.Location = new System.Drawing.Point(1422, 178);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(14, 15);
            this.btnVerde.TabIndex = 22;
            this.btnVerde.Visible = false;
            // 
            // pantalla
            // 
            this.pantalla.BackgroundImage = global::PrinterLanguage.Properties.Resources.pantalla;
            this.pantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pantalla.Location = new System.Drawing.Point(1459, 211);
            this.pantalla.Name = "pantalla";
            this.pantalla.Size = new System.Drawing.Size(149, 24);
            this.pantalla.TabIndex = 20;
            this.pantalla.TabStop = false;
            // 
            // impresora
            // 
            this.impresora.BackColor = System.Drawing.Color.Transparent;
            this.impresora.BackgroundImage = global::PrinterLanguage.Properties.Resources.fondo;
            this.impresora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.impresora.Location = new System.Drawing.Point(1396, 163);
            this.impresora.Name = "impresora";
            this.impresora.Size = new System.Drawing.Size(275, 157);
            this.impresora.TabIndex = 18;
            this.impresora.TabStop = false;
            // 
            // hoja
            // 
            this.hoja.BackColor = System.Drawing.Color.Transparent;
            this.hoja.BackgroundImage = global::PrinterLanguage.Properties.Resources.hoja;
            this.hoja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hoja.Location = new System.Drawing.Point(1455, 42);
            this.hoja.Name = "hoja";
            this.hoja.Size = new System.Drawing.Size(154, 230);
            this.hoja.TabIndex = 19;
            this.hoja.TabStop = false;
            // 
            // btnRojo
            // 
            this.btnRojo.BackColor = System.Drawing.Color.Transparent;
            this.btnRojo.BackgroundImage = global::PrinterLanguage.Properties.Resources.boton_rojo;
            this.btnRojo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRojo.Location = new System.Drawing.Point(1422, 213);
            this.btnRojo.Name = "btnRojo";
            this.btnRojo.Size = new System.Drawing.Size(14, 15);
            this.btnRojo.TabIndex = 23;
            this.btnRojo.Visible = false;
            // 
            // btnAmarillo
            // 
            this.btnAmarillo.BackColor = System.Drawing.Color.Transparent;
            this.btnAmarillo.BackgroundImage = global::PrinterLanguage.Properties.Resources.boton_amarillo;
            this.btnAmarillo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAmarillo.Location = new System.Drawing.Point(1422, 195);
            this.btnAmarillo.Name = "btnAmarillo";
            this.btnAmarillo.Size = new System.Drawing.Size(14, 15);
            this.btnAmarillo.TabIndex = 23;
            this.btnAmarillo.Visible = false;
            // 
            // hojaEscaner
            // 
            this.hojaEscaner.BackgroundImage = global::PrinterLanguage.Properties.Resources.hojaEscaner;
            this.hojaEscaner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hojaEscaner.Location = new System.Drawing.Point(1677, 170);
            this.hojaEscaner.Name = "hojaEscaner";
            this.hojaEscaner.Size = new System.Drawing.Size(269, 88);
            this.hojaEscaner.TabIndex = 24;
            this.hojaEscaner.TabStop = false;
            this.hojaEscaner.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1711, 809);
            this.Controls.Add(this.btnAmarillo);
            this.Controls.Add(this.btnRojo);
            this.Controls.Add(this.btnVerde);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pantalla);
            this.Controls.Add(this.impresora);
            this.Controls.Add(this.rtxPostfijo);
            this.Controls.Add(this.rtxInfijo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSemantica);
            this.Controls.Add(this.rtxTipos);
            this.Controls.Add(this.rtxtSemantica);
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
            this.Controls.Add(this.rtxtGramatica);
            this.Controls.Add(this.hoja);
            this.Controls.Add(this.hojaEscaner);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "     ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesNumericas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pantalla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hojaEscaner)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtxTipos;
        private System.Windows.Forms.RichTextBox rtxtSemantica;
        private System.Windows.Forms.Button btnSemantica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtxInfijo;
        private System.Windows.Forms.RichTextBox rtxPostfijo;
        private System.Windows.Forms.PictureBox impresora;
        private System.Windows.Forms.PictureBox hoja;
        private System.Windows.Forms.PictureBox pantalla;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel btnVerde;
        private System.Windows.Forms.Panel btnRojo;
        private System.Windows.Forms.Panel btnAmarillo;
        private System.Windows.Forms.PictureBox hojaEscaner;
    }
}

