using AppGestionConsorcio.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionFutbol.Logica
{
    internal class clsTorneo
    {
        AccesoDatos dt = new AccesoDatos();
        public void crearTorneo(int id, string nombre)
        {
            string consulta;
            consulta = "begin pro_crearTorneo (" + id + ",'" + nombre + "'); end;";
            dt.ejecutarDML(consulta);
        }

        public void agregarEquipoTor(int equipoID, int torneoID)
        {
            string consulta;
            consulta = "INSERT INTO equipotorneo VALUES(" + equipoID + "," + torneoID + ")";
            dt.ejecutarDML(consulta);
        }

        public DataTable IDsToneos()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT tor_id, tor_nombre FROM torneo";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public DataTable equiposXTorneo(int IDTorneo)
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT * FROM equipoTorneo INNER JOIN equipo on equipoTorneo.equ_id = equipo.equ_id  where tor_id = " + IDTorneo;
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public void empezarTorneo(int idTorneo, int equipo1, int equipo2, int equipo3, int equipo4, int equipo5, int equipo6, int equipo7, int equipo8)
        {
            string consulta;
            consulta = "begin pro_autoCuartos(" + idTorneo + "," + equipo1 + "," + equipo2 + "," + equipo3 + "," + equipo4 + "," + equipo5 + "," + equipo6 + "," + equipo7 + "," + equipo8 + "); end;";
            dt.ejecutarDML(consulta);
        }

		public DataTable clasificatoriaCuartos(int idTorneo)
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT EQU_NOMBRE, PAR_GOLESEQU1, PAR_GOLESEQU2 FROM EQUIPO INNER JOIN EQUIPOPARTIDO ON EQUIPOPARTIDO.EQU_ID = equipo.equ_id INNER JOIN PARTIDO ON PARTIDO.PAR_ID = EQUIPOPARTIDO.PAR_ID WHERE PAR_TIPO = 'Cuartos' AND tor_id =" + idTorneo;
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public void clasificatoriaSemiFinal(int idTorneo)
		{
			string consulta;
			consulta = "begin pro_autosemifinals(" + idTorneo + "); end;";
			dt.ejecutarDML(consulta);
		}

		public DataTable clasificatoriaSemiFinalinfo(int idTorneo)
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT EQU_NOMBRE, PAR_GOLESEQU1, PAR_GOLESEQU2 FROM EQUIPO INNER JOIN EQUIPOPARTIDO ON EQUIPOPARTIDO.EQU_ID = equipo.equ_id INNER JOIN PARTIDO ON PARTIDO.PAR_ID = EQUIPOPARTIDO.PAR_ID WHERE PAR_TIPO = 'SemiFinal' AND tor_id =" + idTorneo;
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public void clasificatoriaFinal(int idTorneo)
		{
			string consulta;
			consulta = "begin pro_autofinal(" + idTorneo + "); end;";
			dt.ejecutarDML(consulta);
		}

		public DataTable clasificatoriaFinalinfo(int idTorneo)
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT EQU_NOMBRE, PAR_GOLESEQU1, PAR_GOLESEQU2 FROM EQUIPO INNER JOIN EQUIPOPARTIDO ON EQUIPOPARTIDO.EQU_ID = equipo.equ_id INNER JOIN PARTIDO ON PARTIDO.PAR_ID = EQUIPOPARTIDO.PAR_ID WHERE PAR_TIPO = 'Final' AND tor_id =" + idTorneo;
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable clasificatoriaVerificar(int idTorneo)
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT PAR_TIPO FROM PARTIDO WHERE tor_id = " + idTorneo;
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable clasificatoriaGanador(int idTorneo)
		{
			idTorneo = idTorneo * 10 + 7;
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT EQU_NOMBRE FROM EQUIPO WHERE EQU_ID = fun_obtenerGanador("+ idTorneo + ")";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}
	}
}
