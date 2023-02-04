using AppGestionConsorcio.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionFutbol.Logica
{
    internal class clsPartido
    {
        AccesoDatos dt = new AccesoDatos();

        public DataTable idsPartidos()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT par_id, par_fecha FROM partido";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }
    }
}
