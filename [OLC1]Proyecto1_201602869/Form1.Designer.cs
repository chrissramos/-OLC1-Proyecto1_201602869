namespace _OLC1_Proyecto1_201602869
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarArbolDeDerivacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTecnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtArchivo = new System.Windows.Forms.RichTextBox();
            this.listaTablas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxColumnas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTabla = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnTipo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1218, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem,
            this.cargarTablasToolStripMenuItem,
            this.verTablasToolStripMenuItem,
            this.mostrarTokensToolStripMenuItem,
            this.mostrarArbolDeDerivacionToolStripMenuItem,
            this.mostrarErroresToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // cargarTablasToolStripMenuItem
            // 
            this.cargarTablasToolStripMenuItem.Name = "cargarTablasToolStripMenuItem";
            this.cargarTablasToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.cargarTablasToolStripMenuItem.Text = "Cargar Tablas";
            this.cargarTablasToolStripMenuItem.Click += new System.EventHandler(this.cargarTablasToolStripMenuItem_Click);
            // 
            // verTablasToolStripMenuItem
            // 
            this.verTablasToolStripMenuItem.Name = "verTablasToolStripMenuItem";
            this.verTablasToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.verTablasToolStripMenuItem.Text = "Ver Tablas";
            this.verTablasToolStripMenuItem.Click += new System.EventHandler(this.verTablasToolStripMenuItem_Click);
            // 
            // mostrarTokensToolStripMenuItem
            // 
            this.mostrarTokensToolStripMenuItem.Name = "mostrarTokensToolStripMenuItem";
            this.mostrarTokensToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.mostrarTokensToolStripMenuItem.Text = "Mostrar Tokens";
            this.mostrarTokensToolStripMenuItem.Click += new System.EventHandler(this.mostrarTokensToolStripMenuItem_Click);
            // 
            // mostrarArbolDeDerivacionToolStripMenuItem
            // 
            this.mostrarArbolDeDerivacionToolStripMenuItem.Name = "mostrarArbolDeDerivacionToolStripMenuItem";
            this.mostrarArbolDeDerivacionToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.mostrarArbolDeDerivacionToolStripMenuItem.Text = "Mostrar Arbol de Derivacion";
            // 
            // mostrarErroresToolStripMenuItem
            // 
            this.mostrarErroresToolStripMenuItem.Name = "mostrarErroresToolStripMenuItem";
            this.mostrarErroresToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.mostrarErroresToolStripMenuItem.Text = "Mostrar Errores";
            this.mostrarErroresToolStripMenuItem.Click += new System.EventHandler(this.mostrarErroresToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualUsuarioToolStripMenuItem,
            this.manualTecnicoToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualUsuarioToolStripMenuItem
            // 
            this.manualUsuarioToolStripMenuItem.Name = "manualUsuarioToolStripMenuItem";
            this.manualUsuarioToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.manualUsuarioToolStripMenuItem.Text = "Manual Usuario";
            // 
            // manualTecnicoToolStripMenuItem
            // 
            this.manualTecnicoToolStripMenuItem.Name = "manualTecnicoToolStripMenuItem";
            this.manualTecnicoToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.manualTecnicoToolStripMenuItem.Text = "Manual Tecnico";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.acercaDeToolStripMenuItem.Text = "Acerca De";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(13, 32);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(482, 668);
            this.txtArchivo.TabIndex = 1;
            this.txtArchivo.Text = "";
            // 
            // listaTablas
            // 
            this.listaTablas.FormattingEnabled = true;
            this.listaTablas.ItemHeight = 16;
            this.listaTablas.Location = new System.Drawing.Point(528, 75);
            this.listaTablas.Name = "listaTablas";
            this.listaTablas.Size = new System.Drawing.Size(155, 180);
            this.listaTablas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(528, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista Tablas";
            // 
            // listBoxColumnas
            // 
            this.listBoxColumnas.FormattingEnabled = true;
            this.listBoxColumnas.ItemHeight = 16;
            this.listBoxColumnas.Location = new System.Drawing.Point(740, 75);
            this.listBoxColumnas.Name = "listBoxColumnas";
            this.listBoxColumnas.Size = new System.Drawing.Size(131, 180);
            this.listBoxColumnas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(743, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Columnas";
            // 
            // btnTabla
            // 
            this.btnTabla.Location = new System.Drawing.Point(672, 271);
            this.btnTabla.Name = "btnTabla";
            this.btnTabla.Size = new System.Drawing.Size(106, 23);
            this.btnTabla.TabIndex = 6;
            this.btnTabla.Text = "Ver Columnas";
            this.btnTabla.UseVisualStyleBackColor = true;
            this.btnTabla.Click += new System.EventHandler(this.btnTabla_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(908, 75);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(40, 17);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo ";
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(902, 114);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(75, 23);
            this.btnTipo.TabIndex = 8;
            this.btnTipo.Text = "Ver Tipo";
            this.btnTipo.UseVisualStyleBackColor = true;
            this.btnTipo.Click += new System.EventHandler(this.btnTipo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 754);
            this.Controls.Add(this.btnTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.btnTabla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxColumnas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaTablas);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarTablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarArbolDeDerivacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTecnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox txtArchivo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox listaTablas;
        private System.Windows.Forms.ListBox listBoxColumnas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTabla;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnTipo;
    }
}

