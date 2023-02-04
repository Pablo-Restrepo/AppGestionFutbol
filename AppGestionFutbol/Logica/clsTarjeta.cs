using AppGestionConsorcio.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionFutbol.Logica
{
    internal class clsTarjeta
    {
        AccesoDatos dt = new AccesoDatos();

        public DataTable tipoTarjetas()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT * FROM tarjeta";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public void agregarTarjeta(int tarjeta, int cedula, int partido)
        {
            string consulta;
            consulta = "begin agregarTarjeta(" + tarjeta + "," + cedula + "," + partido + "); end;";
            dt.ejecutarDML(consulta);
        }

	}
}
