using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;

namespace AppGestionConsorcio.datos
{
    class AccesoDatos
    {
        string cadenaConexion = "Data Source=localhost:1521/xe;User Id=FUTBOLBASESII;Password=oracle";
        public int ejecutarDML(string consulta)
        {
            int filasAfectadas = 0;
            OracleConnection miConexion = new OracleConnection(cadenaConexion);
            OracleCommand miComando = new OracleCommand(consulta, miConexion);
            try
            {
                miConexion.Open();
                filasAfectadas = miComando.ExecuteNonQuery();
                miConexion.Close();
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                miConexion.Close();
                MessageBox.Show("Ocurrió un error con la base de datos: " + ex.Message);
            }
            return filasAfectadas;
        }

        public DataSet ejecutarSELECT(string consulta)
        {
            DataSet ds = new DataSet();
            OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, cadenaConexion);
            miAdaptador.Fill(ds, "ResultadoDatos");
            return ds;
        }
    }
}
