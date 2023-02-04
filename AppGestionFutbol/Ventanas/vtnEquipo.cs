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
    public partial class vtnEquipo : Form
    {
        public vtnEquipo()
        {
            InitializeComponent();
        }

        clsJugador jugador = new clsJugador();
        clsEquipo equipo = new clsEquipo();

        private void vtnEquipo_Load(object sender, EventArgs e)
        {
            informacion();
        }

        private void informacion()
        {
            cbEquipo.DataSource = equipo.IDsEquipos();
            cbEquipo.DisplayMember = "equ_nombre";
            cbEquipo.ValueMember = "equ_id";

            cbJugador.DataSource = jugador.cedulasJugadores();
            cbJugador.DisplayMember = "jug_nombre";
            cbJugador.ValueMember = "jug_cedula";
        }

        private void btnCrearEquipo_Click(object sender, EventArgs e)
        {
            int ID;
            string nombre;

            if (txtID.Text.Equals("") || txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ID = int.Parse(txtID.Text);
                nombre = txtNombre.Text;
                equipo.crearEquipo(ID, nombre, cbRepresenta.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Equipo registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtID.Clear();
            txtNombre.Clear();
            informacion();
        }

        private void btnAgregarJugEqui_Click(object sender, EventArgs e)
        {
            if (cbEquipo.Text.Equals("") || cbJugador.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                equipo.agregarJugador(Convert.ToInt32(cbEquipo.SelectedValue), Convert.ToInt32(cbJugador.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Jugador Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
