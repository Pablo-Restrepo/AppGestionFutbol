using AppGestionConsorcio.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionFutbol.Logica
{
    internal class clsEquipo
    {
        AccesoDatos dt = new AccesoDatos();

        public void crearEquipo(int ID, string nombre, string representa)
        {
            string consulta;
            consulta = "begin crearEquipo(" + ID + ",'" + nombre + "','" + representa + "'); end;";
            dt.ejecutarDML(consulta);
        }

        public DataTable IDsEquipos()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT equ_id, equ_nombre FROM equipo";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public void agregarJugador(int equipo, int jugador)
        {
            string consulta;
            consulta = "UPDATE JUGADOR SET EQU_ID = " + equipo + "WHERE JUG_CEDULA = " + jugador;
            dt.ejecutarDML(consulta);
        }
    }
}
