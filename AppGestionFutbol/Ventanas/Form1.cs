using AppGestionFutbol.Ventanas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionFutbol
{
    public partial class Form1 : Form
    {
        private Form fH;
        public Form1()
        {
            InitializeComponent();
        }

        public void abrirFormHija(object formHija)
        {
            if (this.panelCentral.Controls.Count > 0)
            {
                this.panelCentral.Controls.Clear();
            }
            if (fH != null)
            {
                fH.Dispose();
            }
            fH = formHija as Form;
            fH.TopLevel = false;
            fH.Dock = DockStyle.Fill;
            this.panelCentral.Controls.Add(fH);
            this.panelCentral.Tag = fH;
            fH.Show();
        }

        private void jugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnJugador());
        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnEquipo());
        }

        private void partidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnPartido());
        }

        private void canchaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnCancha());
        }

        private void torneoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnTorneo());
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnReportes());
        }

        private void clasificatoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHija(new vtnClasificatoria());
        }
    }
}
