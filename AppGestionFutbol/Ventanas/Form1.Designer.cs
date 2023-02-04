namespace AppGestionFutbol
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.jugadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.equiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.canchaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.torneoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.partidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clasificatoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelCentral = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.panelCentral.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.AutoSize = false;
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jugadoresToolStripMenuItem,
            this.equiposToolStripMenuItem,
            this.canchaToolStripMenuItem,
            this.torneoToolStripMenuItem,
            this.partidosToolStripMenuItem,
            this.clasificatoriaToolStripMenuItem,
            this.reportesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 49);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// jugadoresToolStripMenuItem
			// 
			this.jugadoresToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
			this.jugadoresToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.jugadoresToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.jugadoresToolStripMenuItem.Name = "jugadoresToolStripMenuItem";
			this.jugadoresToolStripMenuItem.Size = new System.Drawing.Size(116, 45);
			this.jugadoresToolStripMenuItem.Text = "Jugadores";
			this.jugadoresToolStripMenuItem.Click += new System.EventHandler(this.jugadoresToolStripMenuItem_Click);
			// 
			// equiposToolStripMenuItem
			// 
			this.equiposToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.equiposToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.equiposToolStripMenuItem.Name = "equiposToolStripMenuItem";
			this.equiposToolStripMenuItem.Size = new System.Drawing.Size(95, 45);
			this.equiposToolStripMenuItem.Text = "Equipos";
			this.equiposToolStripMenuItem.Click += new System.EventHandler(this.equiposToolStripMenuItem_Click);
			// 
			// canchaToolStripMenuItem
			// 
			this.canchaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.canchaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.canchaToolStripMenuItem.Name = "canchaToolStripMenuItem";
			this.canchaToolStripMenuItem.Size = new System.Drawing.Size(96, 45);
			this.canchaToolStripMenuItem.Text = "Canchas";
			this.canchaToolStripMenuItem.Click += new System.EventHandler(this.canchaToolStripMenuItem_Click);
			// 
			// torneoToolStripMenuItem
			// 
			this.torneoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.torneoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.torneoToolStripMenuItem.Name = "torneoToolStripMenuItem";
			this.torneoToolStripMenuItem.Size = new System.Drawing.Size(95, 45);
			this.torneoToolStripMenuItem.Text = "Torneos";
			this.torneoToolStripMenuItem.Click += new System.EventHandler(this.torneoToolStripMenuItem_Click);
			// 
			// partidosToolStripMenuItem
			// 
			this.partidosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.partidosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.partidosToolStripMenuItem.Name = "partidosToolStripMenuItem";
			this.partidosToolStripMenuItem.Size = new System.Drawing.Size(99, 45);
			this.partidosToolStripMenuItem.Text = "Partidos";
			this.partidosToolStripMenuItem.Click += new System.EventHandler(this.partidosToolStripMenuItem_Click);
			// 
			// clasificatoriaToolStripMenuItem
			// 
			this.clasificatoriaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
			this.clasificatoriaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.clasificatoriaToolStripMenuItem.Name = "clasificatoriaToolStripMenuItem";
			this.clasificatoriaToolStripMenuItem.Size = new System.Drawing.Size(137, 45);
			this.clasificatoriaToolStripMenuItem.Text = "Clasificatoria";
			this.clasificatoriaToolStripMenuItem.Click += new System.EventHandler(this.clasificatoriaToolStripMenuItem_Click);
			// 
			// reportesToolStripMenuItem
			// 
			this.reportesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.reportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
			this.reportesToolStripMenuItem.Size = new System.Drawing.Size(104, 45);
			this.reportesToolStripMenuItem.Text = "Reportes";
			this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
			// 
			// panelCentral
			// 
			this.panelCentral.Controls.Add(this.label2);
			this.panelCentral.Controls.Add(this.label1);
			this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCentral.Location = new System.Drawing.Point(0, 49);
			this.panelCentral.Name = "panelCentral";
			this.panelCentral.Size = new System.Drawing.Size(800, 401);
			this.panelCentral.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(12, 296);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(250, 96);
			this.label2.TabIndex = 4;
			this.label2.Text = "Grupo:\r\n\r\nPablo Jose Restrepo Ruiz\r\nBraian Rey Castillo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(758, 48);
			this.label1.TabIndex = 3;
			this.label1.Text = "Aplicación para administrar equipos, partidos, estadísticas, jugadores, torneos y" +
    " \r\nclasificatorias.";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panelCentral);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gestión de Futbol";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelCentral.ResumeLayout(false);
			this.panelCentral.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jugadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canchaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem torneoToolStripMenuItem;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificatoriaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

