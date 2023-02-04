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
    public partial class vtnReportes : Form
    {
        public vtnReportes()
        {
            InitializeComponent();
        }

        private void vtnReportes_Load(object sender, EventArgs e)
        {
            informacion();
        }

        clsTorneo torneo = new clsTorneo();
        clsJugador jugador = new clsJugador();

        private void informacion()
        {
            cbEquXTorneo.DataSource = torneo.IDsToneos();
            cbEquXTorneo.DisplayMember = "tor_nombre";
            cbEquXTorneo.ValueMember = "tor_id";

			dataGridReporte3.DataSource = jugador.reporte3();
			dataGridReporte4.DataSource = jugador.reporte4();
			dataGridReporte5.DataSource = jugador.reporte5();
			dataGridReporte6.DataSource = jugador.reporte6();
			dataGridReporte7.DataSource = jugador.reporte7();
			dataGridReporte8.DataSource = jugador.reporte8();
			dataGridReporte9.DataSource = jugador.reporte9();
			dataGridReporte10.DataSource = jugador.reporte9();
			dataGridReporte11.DataSource = jugador.reporte9();

		}

        private void btnBuscarInfo_Click(object sender, EventArgs e)
        {
            if (cbInfoGeneral.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridReporte1.DataSource = jugador.reporte1(cbInfoGeneral.Text);
        }

        private void btnBuscarXTorneo_Click(object sender, EventArgs e)
        {
            if (cbEquXTorneo.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridReporte2.DataSource = torneo.equiposXTorneo(Convert.ToInt32(cbEquXTorneo.SelectedValue));
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
			if (txtPorcentaje.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (dataGridReporte9.Rows.Count > 0)
            {
                jugador.reporte9Borrar(int.Parse(txtPorcentaje.Text));
				dataGridReporte9.DataSource = jugador.reporte9();
				MessageBox.Show("Borrados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
            else
            {
                MessageBox.Show("No hay datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void btnInhabilitarJug_Click(object sender, EventArgs e)
        {
            if (dataGridReporte10.Rows.Count > 0)
            {
                jugador.reporte10();
				dataGridReporte10.DataSource = jugador.reporte9();
				MessageBox.Show("Inhabilitados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
            else
            {
                MessageBox.Show("No hay datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAumentarCom_Click(object sender, EventArgs e)
        {
            if (dataGridReporte11.Rows.Count > 0)
            {
                jugador.aumentarComision();
				dataGridReporte11.DataSource = jugador.reporte9();
				MessageBox.Show("Aumentado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
            else
            {
                MessageBox.Show("No hay datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
