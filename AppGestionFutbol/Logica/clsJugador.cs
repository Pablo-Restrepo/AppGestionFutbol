using AppGestionConsorcio.datos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionFutbol.Logica
{
    internal class clsJugador
    {
        AccesoDatos dt = new AccesoDatos();
        public void crearJugador(int cedula, string nombre, int sueldo, string posicion, int comision)
        {
            string consulta;
            consulta = "begin crearJugador(" + cedula + ",'" + nombre + "'," + sueldo + ",'" + posicion + "'," + comision + ", 'Activo'," + "null" + "); end;";
            dt.ejecutarDML(consulta);
        }

        public DataTable cedulasJugadores()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT jug_cedula, jug_nombre FROM jugador";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public void agregarGoles(int cedula, int goles)
        {
            string consulta;
            consulta = "begin agregarGoles(" + cedula + "," + goles + "); end;";
            dt.ejecutarDML(consulta);
        }

        public DataTable reporte1(string aux)
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT * FROM " + aux;
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

		public DataTable reporte3()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT jug_nombre, jug_numgoles AS goles_tapados FROM jugador WHERE jug_posicionjue = 'Arquero' ORDER BY jug_numgoles DESC FETCH FIRST 10 ROWS ONLY";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable reporte4()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT jug_nombre, equ_nombre, tarjetas FROM jugador\r\n        INNER JOIN (SELECT cedula, MAX(num_tarjetas) AS tarjetas FROM (SELECT jug_cedula AS cedula, COUNT(tar_id) AS num_tarjetas FROM tarjetajugador group by jug_cedula) group by cedula) ON jugador.jug_cedula = cedula\r\n        INNER JOIN equipo ON jugador.equ_id = equipo.equ_id";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable reporte5()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT par_id, par_numentradavends FROM partido ORDER BY par_numentradavends DESC FETCH FIRST 10 ROWS ONLY";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable reporte6()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT jug_nombre, goles, equ_nombre FROM jugador INNER JOIN (SELECT jug_cedula AS cedula, MAX(jug_numgoles) AS goles FROM jugador group by jug_cedula) ON jugador.jug_cedula = cedula INNER JOIN equipo ON jugador.equ_id = equipo.equ_id";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable reporte7()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT jug_nombre, sueldo, equ_nombre FROM jugador\r\n        INNER JOIN (SELECT jug_cedula AS cedula, MAX(jug_sueldo) AS sueldo FROM jugador group by jug_cedula) ON jugador.jug_cedula = cedula\r\n        INNER JOIN equipo ON jugador.equ_id = equipo.equ_id";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable reporte8()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT can_nombre, count(par_id) AS num_canchas FROM partido INNER JOIN cancha ON partido.can_id = cancha.can_id  \r\n                                      GROUP BY can_nombre ORDER BY num_canchas FETCH FIRST 10 ROWS ONLY";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}

		public DataTable reporte9()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT * FROM jugador order by jug_comision";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public void reporte9Borrar(int aux)
        {
            string consulta;
            consulta = "begin pro_borrarPorMinComision (" + aux+"); end;";
            dt.ejecutarDML(consulta);
        }

		public void reporte10()
		{
			string consulta;
			consulta = "begin pro_inhabilitarJugConTarjetas(); end;";
			dt.ejecutarDML(consulta);
		}

		public void reporte11()
		{
			string consulta;
			consulta = "begin agregarBonusPorVeterania(); end;";
			dt.ejecutarDML(consulta);
		}

        public void aumentarComision()
        {
            string consulta;
            consulta = "begin aumentarComision(); end;";
            dt.ejecutarDML(consulta);
        }
    }
}
