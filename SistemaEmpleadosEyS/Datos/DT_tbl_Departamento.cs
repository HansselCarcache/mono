using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEmpleadosEyS.Entidades;
namespace SistemaEmpleadosEyS.Datos
{
    public class DT_tbl_Departamento
    {
        #region atributos
        Conexion con = new Conexion();
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;
        #endregion

        public ListStore listaUsuario()
        {
            ListStore empleado_datos = new ListStore(typeof(int), typeof(string), typeof(string), typeof(string), typeof(int));

            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT * FROM ControlBD.Departamento;");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    empleado_datos.AppendValues(idr[0], idr[1], idr[2], idr[3], idr[4]);
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

        public bool guardarDepartamento(tbl_departamento dep)
        {
            bool guardado = false;
            int x = 0;
            sb.Clear();
            sb.Append("INSERT INTO ControlBD.Departamento");
            sb.Append("(nombreDep, extension, correoDep)");
            sb.Append("VALUES('" + dep.NombreDep + "','" + dep.Extension + "','" + dep.CorreoDep + "');");

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());
                if (x > 0)
                {
                    guardado = true;
                }
                return guardado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public Int32 eliminarDepartamento(tbl_departamento depa)
        {
            int eliminado;
            sb.Clear();
            sb.Append("DELETE FROM ControlBD.Departamento WHERE idDepartamento = "
            + depa.IdDep);

            try
            {
                con.AbrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                return eliminado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public bool editarDepartamento(tbl_departamento d)
        {
            bool editado = false;
            int x = 0;
            sb.Clear();
            sb.Append("Update ControlBD.Departamento");
            sb.Append(" set nombreDep= '" + d.NombreDep + "',");
            sb.Append(" extension= '" + d.Extension + "',");
            sb.Append(" correoDep = '" + d.CorreoDep + "'");
            sb.Append(" WHERE idDepartamento = " + d.IdDep);

            Console.WriteLine(sb.ToString());
            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());
                if (x > 0)
                {
                    editado = true;
                }
                return editado;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public tbl_departamento listById(int idDep)
        {
            tbl_departamento td = new tbl_departamento();
            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT * FROM Departamento where idDepartamento = " + idDep);
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    td.IdDep = Convert.ToInt32(idr["idDepartamento"]);
                    td.NombreDep = idr["nombreDep"].ToString();
                    td.Extension = idr["extension"].ToString();
                    td.CorreoDep = idr["correoDep"].ToString();

                }
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }
        public DT_tbl_Departamento()
        {
        }
    }
}
