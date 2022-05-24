using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEmpleadosEyS.Entidades;

namespace SistemaEmpleadosEyS.Datos
{
    public class DT_tbl_Empleado
    {
        #region atributos
        Conexion con = new Conexion();
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;
        #endregion

        public ListStore listaUsuario()
        {
            ListStore empleado_datos = new ListStore(typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int));

            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT * FROM ControlBD.Empleados;");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    empleado_datos.AppendValues(idr[0], idr[1], idr[2], idr[3], idr[4], idr[5], idr[6], idr[7], idr[8], idr[9]);
                }
                Console.WriteLine(empleado_datos);
                return empleado_datos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error lista: " + e.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
            return empleado_datos;
        }
        public DT_tbl_Empleado()
        {
        }
    }
}
