using AppGestionConsorcio.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionFutbol.Logica
{
    internal class clsUbicacion
    {
        AccesoDatos dt = new AccesoDatos();
        public DataTable IDsCanchas()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT ubi_id, ubi_direccion FROM ubicacion";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }

        public void crearUbicacion(int ID, string direccion, string ciudad)
        {
            string consulta;
            consulta = "begin crearUbicacion(" + ID + ",'" + direccion + "','" + ciudad + "'); end;";
            dt.ejecutarDML(consulta);
        }
    }
}
