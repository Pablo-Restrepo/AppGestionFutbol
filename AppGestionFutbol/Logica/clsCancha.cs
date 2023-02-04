using AppGestionConsorcio.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionFutbol.Logica
{
    internal class clsCancha
    {
        AccesoDatos dt = new AccesoDatos();

        public void crearCancha(int ID, string nombre, int IDUbi)
        {
            string consulta;
            consulta = "begin pro_crearCancha(" + ID + "," + IDUbi + ",'" + nombre + "'); end;";
            dt.ejecutarDML(consulta);
        }
    }
}
