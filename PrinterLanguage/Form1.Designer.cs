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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvTripleta = new System.Windows.Forms.DataGridView();
            this.DatoObjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatoFuente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCadenas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesNumericas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripleta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadenas)).BeginInit();
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
            this.rtxtCodigo.Size = new System.Drawing.Size(573, 227);
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
            this.lblNumRenglon.Location = new System.Drawing.Point(442, 269);
            this.lblNumRenglon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumRenglon.Name = "lblNumRenglon";
            this.lblNumRenglon.Size = new System.Drawing.Size(104, 18);
            this.lblNumRenglon.TabIndex = 0;
            this.lblNumRenglon.Text = "# de renglón";
            // 
            // txtNumRenglon
            // 
            this.txtNumRenglon.Enabled = false;
            this.txtNumRenglon.Location = new System.Drawing.Point(550, 266);
            this.txtNumRenglon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNumRenglon.Name = "txtNumRenglon";
            this.txtNumRenglon.Size = new System.Drawing.Size(34, 25);
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
            this.lblSubCadenaAEvaluar.Size = new System.Drawing.Size(160, 18);
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
            this.lblCadenaDeTokens.Size = new System.Drawing.Size(136, 18);
            this.lblCadenaDeTokens.TabIndex = 0;
            this.lblCadenaDeTokens.Text = "Cadena de tokens";
            // 
            // txtSubCadenaAEvaluar
            // 
            this.txtSubCadenaAEvaluar.Enabled = false;
            this.txtSubCadenaAEvaluar.Location = new System.Drawing.Point(11, 313);
            this.txtSubCadenaAEvaluar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSubCadenaAEvaluar.Name = "txtSubCadenaAEvaluar";
            this.txtSubCadenaAEvaluar.Size = new System.Drawing.Size(573, 25);
            this.txtSubCadenaAEvaluar.TabIndex = 0;
            // 
            // txtCadenaDeTokens
            // 
            this.txtCadenaDeTokens.Enabled = false;
            this.txtCadenaDeTokens.Location = new System.Drawing.Point(11, 362);
            this.txtCadenaDeTokens.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCadenaDeTokens.Name = "txtCadenaDeTokens";
            this.txtCadenaDeTokens.Size = new System.Drawing.Size(573, 25);
            this.txtCadenaDeTokens.TabIndex = 0;
            // 
            // rtxtCodigoIntermedio
            // 
            this.rtxtCodigoIntermedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxtCodigoIntermedio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtCodigoIntermedio.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodigoIntermedio.ForeColor = System.Drawing.Color.White;
            this.rtxtCodigoIntermedio.Location = new System.Drawing.Point(682, 31);
            this.rtxtCodigoIntermedio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rtxtCodigoIntermedio.Name = "rtxtCodigoIntermedio";
            this.rtxtCodigoIntermedio.Size = new System.Drawing.Size(396, 228);
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
            this.lblCodigoIntermedio.Size = new System.Drawing.Size(144, 18);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIdentificadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIdentificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIdentificadores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIdentificadores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dgvIdentificadores.Location = new System.Drawing.Point(11, 613);
            this.dgvIdentificadores.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvIdentificadores.Name = "dgvIdentificadores";
            this.dgvIdentificadores.RowHeadersVisible = false;
            this.dgvIdentificadores.RowHeadersWidth = 62;
            this.dgvIdentificadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdentificadores.Size = new System.Drawing.Size(302, 185);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConstantesNumericas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConstantesNumericas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConstantesNumericas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConstantesNumericas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dgvConstantesNumericas.Location = new System.Drawing.Point(325, 613);
            this.dgvConstantesNumericas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvConstantesNumericas.Name = "dgvConstantesNumericas";
            this.dgvConstantesNumericas.RowHeadersVisible = false;
            this.dgvConstantesNumericas.RowHeadersWidth = 62;
            this.dgvConstantesNumericas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstantesNumericas.Size = new System.Drawing.Size(149, 185);
            this.dgvConstantesNumericas.TabIndex = 0;
            // 
            // lblIdentificadores
            // 
            this.lblIdentificadores.AutoSize = true;
            this.lblIdentificadores.ForeColor = System.Drawing.Color.Black;
            this.lblIdentificadores.Location = new System.Drawing.Point(8, 592);
            this.lblIdentificadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentificadores.Name = "lblIdentificadores";
            this.lblIdentificadores.Size = new System.Drawing.Size(128, 18);
            this.lblIdentificadores.TabIndex = 0;
            this.lblIdentificadores.Text = "Identificadores";
            // 
            // lblConstantesNumericas
            // 
            this.lblConstantesNumericas.AutoSize = true;
            this.lblConstantesNumericas.ForeColor = System.Drawing.Color.Black;
            this.lblConstantesNumericas.Location = new System.Drawing.Point(322, 592);
            this.lblConstantesNumericas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConstantesNumericas.Name = "lblConstantesNumericas";
            this.lblConstantesNumericas.Size = new System.Drawing.Size(136, 18);
            this.lblConstantesNumericas.TabIndex = 0;
            this.lblConstantesNumericas.Text = "Const. numéricas";
            // 
            // btnGramatica
            // 
            this.btnGramatica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGramatica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGramatica.Location = new System.Drawing.Point(975, 558);
            this.btnGramatica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGramatica.Name = "btnGramatica";
            this.btnGramatica.Size = new System.Drawing.Size(103, 31);
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
            this.rtxtGramatica.Location = new System.Drawing.Point(682, 284);
            this.rtxtGramatica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtGramatica.Name = "rtxtGramatica";
            this.rtxtGramatica.Size = new System.Drawing.Size(396, 305);
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
            this.rtxttokens.Size = new System.Drawing.Size(658, 178);
            this.rtxttokens.TabIndex = 4;
            this.rtxttokens.Text = "";
            // 
            // rtxTipos
            // 
            this.rtxTipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxTipos.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxTipos.ForeColor = System.Drawing.Color.White;
            this.rtxTipos.Location = new System.Drawing.Point(1090, 30);
            this.rtxTipos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxTipos.Name = "rtxTipos";
            this.rtxTipos.Size = new System.Drawing.Size(396, 228);
            this.rtxTipos.TabIndex = 6;
            this.rtxTipos.Text = "";
            // 
            // rtxtSemantica
            // 
            this.rtxtSemantica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rtxtSemantica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtSemantica.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtSemantica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rtxtSemantica.Location = new System.Drawing.Point(1090, 283);
            this.rtxtSemantica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtSemantica.Name = "rtxtSemantica";
            this.rtxtSemantica.Size = new System.Drawing.Size(396, 305);
            this.rtxtSemantica.TabIndex = 7;
            this.rtxtSemantica.Text = "";
            // 
            // btnSemantica
            // 
            this.btnSemantica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSemantica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemantica.Location = new System.Drawing.Point(1383, 557);
            this.btnSemantica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSemantica.Name = "btnSemantica";
            this.btnSemantica.Size = new System.Drawing.Size(103, 31);
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
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Consola";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(678, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tokens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1088, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(679, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sintaxis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1088, 264);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Semántica";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1089, 593);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Postfijo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(679, 593);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Infijo";
            // 
            // rtxInfijo
            // 
            this.rtxInfijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxInfijo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxInfijo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxInfijo.ForeColor = System.Drawing.Color.White;
            this.rtxInfijo.Location = new System.Drawing.Point(682, 614);
            this.rtxInfijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxInfijo.Name = "rtxInfijo";
            this.rtxInfijo.Size = new System.Drawing.Size(396, 183);
            this.rtxInfijo.TabIndex = 16;
            this.rtxInfijo.Text = "";
            // 
            // rtxPostfijo
            // 
            this.rtxPostfijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rtxPostfijo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxPostfijo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxPostfijo.ForeColor = System.Drawing.Color.White;
            this.rtxPostfijo.Location = new System.Drawing.Point(1091, 614);
            this.rtxPostfijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxPostfijo.Name = "rtxPostfijo";
            this.rtxPostfijo.Size = new System.Drawing.Size(396, 183);
            this.rtxPostfijo.TabIndex = 17;
            this.rtxPostfijo.Text = "";
            // 
            // dgvTripleta
            // 
            this.dgvTripleta.AllowUserToAddRows = false;
            this.dgvTripleta.AllowUserToDeleteRows = false;
            this.dgvTripleta.AllowUserToResizeRows = false;
            this.dgvTripleta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTripleta.BackgroundColor = System.Drawing.Color.White;
            this.dgvTripleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTripleta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTripleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatoObjeto,
            this.DatoFuente,
            this.Operador});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTripleta.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTripleta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dgvTripleta.Location = new System.Drawing.Point(1499, 29);
            this.dgvTripleta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvTripleta.Name = "dgvTripleta";
            this.dgvTripleta.ReadOnly = true;
            this.dgvTripleta.RowHeadersVisible = false;
            this.dgvTripleta.RowHeadersWidth = 62;
            this.dgvTripleta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTripleta.Size = new System.Drawing.Size(405, 401);
            this.dgvTripleta.TabIndex = 18;
            // 
            // DatoObjeto
            // 
            this.DatoObjeto.HeaderText = "Dato Objeto";
            this.DatoObjeto.MinimumWidth = 6;
            this.DatoObjeto.Name = "DatoObjeto";
            this.DatoObjeto.ReadOnly = true;
            // 
            // DatoFuente
            // 
            this.DatoFuente.HeaderText = "Dato Fuente";
            this.DatoFuente.MinimumWidth = 6;
            this.DatoFuente.Name = "DatoFuente";
            this.DatoFuente.ReadOnly = true;
            // 
            // Operador
            // 
            this.Operador.HeaderText = "Operador";
            this.Operador.MinimumWidth = 6;
            this.Operador.Name = "Operador";
            this.Operador.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(1496, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tripleta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(485, 593);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Cadenas";
            // 
            // dgvCadenas
            // 
            this.dgvCadenas.AllowUserToAddRows = false;
            this.dgvCadenas.AllowUserToDeleteRows = false;
            this.dgvCadenas.AllowUserToResizeRows = false;
            this.dgvCadenas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCadenas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCadenas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCadenas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCadenas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCadenas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCadenas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dgvCadenas.Location = new System.Drawing.Point(488, 613);
            this.dgvCadenas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvCadenas.Name = "dgvCadenas";
            this.dgvCadenas.RowHeadersVisible = false;
            this.dgvCadenas.RowHeadersWidth = 62;
            this.dgvCadenas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCadenas.Size = new System.Drawing.Size(181, 185);
            this.dgvCadenas.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1915, 812);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvCadenas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvTripleta);
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
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Printer Language";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesNumericas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripleta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadenas)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvTripleta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatoObjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatoFuente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operador;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCadenas;
    }
}

