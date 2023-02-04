using AppGestionFutbol.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionFutbol.Ventanas
{
    public partial class vtnTorneo : Form
    {
        public vtnTorneo()
        {
            InitializeComponent();
        }

        clsEquipo equipo = new clsEquipo();
        clsTorneo torneo = new clsTorneo();

        private void btnCrearTorneo_Click(object sender, EventArgs e)
        {
            int id;
            string nombre;

            if (txtID.Text.Equals("") || txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                id = int.Parse(txtID.Text);
                nombre = txtNombre.Text;
                torneo.crearTorneo(id, nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Torneo creado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtID.Clear();
            txtNombre.Clear();
        }
    }
}
