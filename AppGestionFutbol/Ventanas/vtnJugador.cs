using AppGestionConsorcio.datos;
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
    public partial class vtnJugador : Form
    {
        public vtnJugador()
        {
            InitializeComponent();
        }

        clsJugador jugador = new clsJugador();
        clsTarjeta tarjeta = new clsTarjeta();
        clsPartido partido = new clsPartido();

        private void vtnJugador_Load(object sender, EventArgs e)
        {
            informacion();
        }

        private void informacion()
        {
            cbCedulaJugadorGoles.DataSource = jugador.cedulasJugadores();
            cbCedulaJugadorGoles.DisplayMember = "jug_nombre";
            cbCedulaJugadorGoles.ValueMember = "jug_cedula";

            cbCedulaJugador.DataSource = jugador.cedulasJugadores();
            cbCedulaJugador.DisplayMember = "jug_nombre";
            cbCedulaJugador.ValueMember = "jug_cedula";

            cbTarjeta.DataSource = tarjeta.tipoTarjetas();
            cbTarjeta.DisplayMember = "tar_tipo";
            cbTarjeta.ValueMember = "tar_id";

            cbPartido.DataSource = partido.idsPartidos();
            cbPartido.DisplayMember = "par_fecha";
            cbPartido.ValueMember = "par_id";
        }

        private void btnCrearJugador_Click(object sender, EventArgs e)
        {
            int cedula, sueldo, comision;
            string nombre, posicion;

            if (txtCedula.Text.Equals("") || txtComision.Text.Equals("") || txtNombre.Text.Equals("") || txtSueldo.Text.Equals("") || cbPosicion.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cedula = int.Parse(txtCedula.Text);
                nombre = txtNombre.Text;
                sueldo = int.Parse(txtSueldo.Text);
                comision = int.Parse(txtComision.Text);
                posicion = cbPosicion.Text;
                jugador.crearJugador(cedula, nombre, sueldo, posicion, comision);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Jugador registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCedula.Clear();
            txtNombre.Clear();
            txtSueldo.Clear();
            txtComision.Clear();
            informacion();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            if (cbTarjeta.Text.Equals("") || cbCedulaJugador.Text.Equals("") || cbPartido.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                tarjeta.agregarTarjeta(Convert.ToInt32(cbTarjeta.SelectedValue), Convert.ToInt32(cbCedulaJugador.SelectedValue), Convert.ToInt32(cbPartido.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tarjeta registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregarGoles_Click(object sender, EventArgs e)
        {
            if (cbCedulaJugadorGoles.Text.Equals("") || txtGoles.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                jugador.agregarGoles(Convert.ToInt32(cbCedulaJugadorGoles.SelectedValue), int.Parse(txtGoles.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Goles registrados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
