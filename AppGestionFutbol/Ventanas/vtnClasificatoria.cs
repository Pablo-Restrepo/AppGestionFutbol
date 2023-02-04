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
    public partial class vtnClasificatoria : Form
    {
        public vtnClasificatoria()
        {
            InitializeComponent();
        }

        clsTorneo torneo = new clsTorneo();

        private void vtnClasificatoria_Load(object sender, EventArgs e)
        {
            informacion();
        }
        private void informacion()
        {
            cbTorneo.DataSource = torneo.IDsToneos();
            cbTorneo.DisplayMember = "tor_nombre";
            cbTorneo.ValueMember = "tor_id";
        }

		private void informacionClasi()
		{
			try
			{
				DataTable tableCuartos = new DataTable();
				tableCuartos = torneo.clasificatoriaCuartos(Convert.ToInt32(cbTorneo.SelectedValue));

				txtEquipo1.Text = tableCuartos.Rows[0][0].ToString();
				txtEquipo2.Text = tableCuartos.Rows[1][0].ToString();
				txtEquipo3.Text = tableCuartos.Rows[2][0].ToString();
				txtEquipo4.Text = tableCuartos.Rows[3][0].ToString();
				txtEquipo5.Text = tableCuartos.Rows[4][0].ToString();
				txtEquipo6.Text = tableCuartos.Rows[5][0].ToString();
				txtEquipo7.Text = tableCuartos.Rows[6][0].ToString();
				txtEquipo8.Text = tableCuartos.Rows[7][0].ToString();

				txtGolesEquipo1.Text = tableCuartos.Rows[0][1].ToString();
				txtGolesEquipo2.Text = tableCuartos.Rows[1][2].ToString();
				txtGolesEquipo3.Text = tableCuartos.Rows[2][1].ToString();
				txtGolesEquipo4.Text = tableCuartos.Rows[3][2].ToString();
				txtGolesEquipo5.Text = tableCuartos.Rows[4][1].ToString();
				txtGolesEquipo6.Text = tableCuartos.Rows[5][2].ToString();
				txtGolesEquipo7.Text = tableCuartos.Rows[6][1].ToString();
				txtGolesEquipo8.Text = tableCuartos.Rows[7][2].ToString();

				DataTable tableSemi = new DataTable();
				tableCuartos = torneo.clasificatoriaSemiFinalinfo(Convert.ToInt32(cbTorneo.SelectedValue));

				txtEquipo1SFinal.Text = tableCuartos.Rows[0][0].ToString();
				txtEquipo2SFinal.Text = tableCuartos.Rows[1][0].ToString();
				txtEquipo3SFinal.Text = tableCuartos.Rows[2][0].ToString();
				txtEquipo4SFinal.Text = tableCuartos.Rows[3][0].ToString();

				txtGolesEquipo1SF.Text = tableCuartos.Rows[0][1].ToString();
				txtGolesEquipo2SF.Text = tableCuartos.Rows[1][2].ToString();
				txtGolesEquipo3SF.Text = tableCuartos.Rows[2][1].ToString();
				txtGolesEquipo4SF.Text = tableCuartos.Rows[3][2].ToString();

				DataTable tableFinal = new DataTable();
				tableFinal = torneo.clasificatoriaFinalinfo(Convert.ToInt32(cbTorneo.SelectedValue));

				txtEquipo1Final.Text = tableFinal.Rows[0][0].ToString();
				txtEquipo2Final.Text = tableFinal.Rows[1][0].ToString();

				txtGolesEquipo1F.Text = tableFinal.Rows[0][1].ToString();
				txtGolesEquipo2F.Text = tableFinal.Rows[1][2].ToString();

				DataTable tableGanador = new DataTable();
				tableGanador = torneo.clasificatoriaGanador(Convert.ToInt32(cbTorneo.SelectedValue));

				txtGanador.Text = tableGanador.Rows[0][0].ToString();
			}
			catch (Exception)
			{

			}
		}

		private void btnBuscarTorneo_Click(object sender, EventArgs e)
        {
            informacionClasi();
		}

		private void btnAvanzar_Click(object sender, EventArgs e)
		{
			informacionClasi();
			if (txtEquipo1.Text == "Por Definir")
			{
				MessageBox.Show("Error", "Inicie el torneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if (txtEquipo1SFinal.Text == "Por Definir")
			{
				torneo.clasificatoriaSemiFinal(Convert.ToInt32(cbTorneo.SelectedValue));
				MessageBox.Show("Avanzado con exito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				informacionClasi();
				return;
			}
			else if (txtEquipo1Final.Text == "Por Definir")
			{
				torneo.clasificatoriaFinal(Convert.ToInt32(cbTorneo.SelectedValue));
				MessageBox.Show("Avanzado con exito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				informacionClasi();
				return;
			}
			else
			{
				MessageBox.Show("Error", "El torneo ya termino", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private String verificar()
		{
			DataTable table = new DataTable();
			table = torneo.clasificatoriaVerificar(Convert.ToInt32(cbTorneo.SelectedValue));
			if (table.Rows[0][0].ToString() == "Cuartos")
			{
				return "Cuartos";
			}
			else if (table.Rows[table.Rows.Count][0].ToString() == "SemiFinal")
			{
				return "SemiFinal";
			}
			else if (table.Rows[table.Rows.Count][0].ToString() == "Final")
			{
				return "Final";
			}
			else
			{
				return "Ninguno";
			}
			
		}
	}
}
