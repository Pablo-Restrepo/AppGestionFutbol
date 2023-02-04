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
    public partial class vtnPartido : Form
    {
        public vtnPartido()
        {
            InitializeComponent();
        }

        clsTorneo torneo = new clsTorneo();

        private void vtnPartido_Load(object sender, EventArgs e)
        {
            informacion();
        }

        private void informacion()
        {
            cbTorneo.DataSource = torneo.IDsToneos();
            cbTorneo.DisplayMember = "tor_nombre";
            cbTorneo.ValueMember = "tor_id";
        }

        private void btnBuscarTorneo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt2 = new DataTable();
			dt2 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt3 = new DataTable();
			dt3 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt4 = new DataTable();
			dt4 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt5 = new DataTable();
			dt5 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt6 = new DataTable();
			dt6 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt7 = new DataTable();
			dt7 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			DataTable dt8 = new DataTable();
			dt8 = torneo.equiposXTorneo(Convert.ToInt32(cbTorneo.SelectedValue));

			cbEquipo1.DataSource = dt;
            cbEquipo1.DisplayMember = "EQU_NOMBRE";
            cbEquipo1.ValueMember = "EQU_ID";

            cbEquipo2.DataSource = dt2;
            cbEquipo2.DisplayMember = "EQU_NOMBRE";
            cbEquipo2.ValueMember = "EQU_ID";

            cbEquipo3.DataSource = dt3;
            cbEquipo3.DisplayMember = "EQU_NOMBRE";
            cbEquipo3.ValueMember = "EQU_ID";

            cbEquipo4.DataSource = dt4;
            cbEquipo4.DisplayMember = "EQU_NOMBRE";
            cbEquipo4.ValueMember = "EQU_ID";

            cbEquipo5.DataSource = dt5;
            cbEquipo5.DisplayMember = "EQU_NOMBRE";
            cbEquipo5.ValueMember = "EQU_ID";

            cbEquipo6.DataSource = dt6;
            cbEquipo6.DisplayMember = "EQU_NOMBRE";
            cbEquipo6.ValueMember = "EQU_ID";

            cbEquipo7.DataSource = dt7;
            cbEquipo7.DisplayMember = "EQU_NOMBRE";
            cbEquipo7.ValueMember = "EQU_ID";

            cbEquipo8.DataSource = dt8;
            cbEquipo8.DisplayMember = "EQU_NOMBRE";
            cbEquipo8.ValueMember = "EQU_ID";
        }

        private void btnEmpezarTorneo_Click(object sender, EventArgs e)
        {
            if (cbTorneo.Text.Equals("") || cbEquipo1.Text.Equals("") || cbEquipo2.Text.Equals("") || cbEquipo3.Text.Equals("") || cbEquipo4.Text.Equals("") || cbEquipo5.Text.Equals("") || cbEquipo6.Text.Equals("") || cbEquipo7.Text.Equals("") || cbEquipo8.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<int> numbers = new List<int> { Convert.ToInt32(cbEquipo1.SelectedValue), Convert.ToInt32(cbEquipo2.SelectedValue), Convert.ToInt32(cbEquipo3.SelectedValue), Convert.ToInt32(cbEquipo4.SelectedValue), Convert.ToInt32(cbEquipo5.SelectedValue), Convert.ToInt32(cbEquipo6.SelectedValue), Convert.ToInt32(cbEquipo7.SelectedValue), Convert.ToInt32(cbEquipo8.SelectedValue)};
            List<int> numbersToCheck = numbers;

            foreach (int num in numbersToCheck)
            {
                // Comprobar si el número se repite en la lista inicial
                if (numbers.FindAll(x => x == num).Count > 1)
                {
                    MessageBox.Show("Hay un equipo repetido. Verificar los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                torneo.empezarTorneo(Convert.ToInt32(cbTorneo.SelectedValue),Convert.ToInt32(cbEquipo1.SelectedValue), Convert.ToInt32(cbEquipo2.SelectedValue), Convert.ToInt32(cbEquipo3.SelectedValue), Convert.ToInt32(cbEquipo4.SelectedValue), Convert.ToInt32(cbEquipo5.SelectedValue), Convert.ToInt32(cbEquipo6.SelectedValue), Convert.ToInt32(cbEquipo7.SelectedValue), Convert.ToInt32(cbEquipo8.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Torneo empezado!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
