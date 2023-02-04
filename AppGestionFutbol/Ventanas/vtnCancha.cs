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
    public partial class vtnCancha : Form
    {
        public vtnCancha()
        {
            InitializeComponent();
        }

        clsUbicacion ubicacion = new clsUbicacion();
        clsCancha cancha = new clsCancha();

        private void vtnCancha_Load(object sender, EventArgs e)
        {
            informacion();
        }

        private void informacion()
        {
            cbUbicacion.DataSource = ubicacion.IDsCanchas();
            cbUbicacion.DisplayMember = "ubi_direccion";
            cbUbicacion.ValueMember = "ubi_id";
        }

        private void btnCrearCancha_Click(object sender, EventArgs e)
        {
            int ID;
            string nombre;

            if (txtIDCancha.Text.Equals("") || txtNombre.Text.Equals("") || cbUbicacion.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ID = int.Parse(txtIDCancha.Text);
                nombre = txtNombre.Text;
                cancha.crearCancha(ID, nombre, Convert.ToInt32(cbUbicacion.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Cancha registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtIDCancha.Clear();
            txtNombre.Clear();
            informacion();
        }

        private void btnCrearUbic_Click(object sender, EventArgs e)
        {
            int ID;
            string direccion, ciudad;

            if (txtIDUbi.Text.Equals("") || txtDireccion.Text.Equals("") || txtCiudad.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
				ID = int.Parse(txtIDUbi.Text);
				direccion = txtDireccion.Text;
                ciudad = txtCiudad.Text;
                ubicacion.crearUbicacion(ID, direccion, ciudad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Ubicacion registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtIDUbi.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            informacion();
        }
    }
}
