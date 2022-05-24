using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gtk;
using SistemaEmpleadosEyS.Entidades;

namespace SistemaEmpleadosEyS.Datos
{
    public class DT_tbl_CargoEmpleado
    {

        #region atributos
        Conexion con = new Conexion();
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;
        #endregion
        public DT_tbl_CargoEmpleado()
        {
        }

        public ListStore listaCargoEmpleado()
        {
            ListStore cargoEmpleado_datos = new ListStore(typeof(int), typeof(int), typeof(String), typeof(int), typeof(String));

            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT idCargosEmpleados, idEmpleados, nombre, idCargo, nombreCargo FROM ControlBD.vwCargoEmpleado ORDER BY idCargosEmpleados;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    cargoEmpleado_datos.AppendValues(idr[0], idr[1], idr[2], idr[3], idr[4]);
                }
                Console.WriteLine(cargoEmpleado_datos);
                return cargoEmpleado_datos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error lista cargoEmpleado: " + e.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
            return cargoEmpleado_datos;
        }

        public ListStore listEmpleados()
        {
            ListStore Empleado_datos = new ListStore(typeof(int), typeof(String));

            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT idEmpleados, CONCAT(nombres,' ',apellidos) FROM ControlBD.Empleados WHERE estado<>3;");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Empleado_datos.AppendValues(idr[0], idr[1]);
                }
                Console.WriteLine(Empleado_datos);
                return Empleado_datos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error lista Empleado: " + e.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
            return Empleado_datos;
        }

        public ListStore listCargos()
        {
            ListStore Cargo_datos = new ListStore(typeof(int), typeof(String));

            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT idCargo, nombreCargo FROM ControlBD.Cargo where estado<>3;");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Cargo_datos.AppendValues(idr[0], idr[1]);
                }
                Console.WriteLine(Cargo_datos);
                return Cargo_datos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error lista Empleado: " + e.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
            return Cargo_datos;
        }

        public bool guardarCargEmpleado(tbl_cargoEmpleado tce)
        {
            bool guardado = false;
            int x = 0;
            sb.Clear();
            sb.Append("INSERT INTO ControlBD.`Cargos Empleados`");
            sb.Append("(Cargo_idCargo, Empleados_idEmpleados)");
            sb.Append("VALUES('" + tce.idCargo + "','" + tce.idEmpleados + "');");

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

        public vwCargoEmpleado listById(int idCE)
        {
            vwCargoEmpleado vwce = new vwCargoEmpleado();
            sb.Clear();
            sb.Append("Use ControlBD;");
            sb.Append("SELECT * FROM vwCargoEmpleado where idCargosEmpleados = " + idCE);
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    vwce.idcargoEmpleado = Convert.ToInt32(idr["idCargosEmpleados"]);
                    vwce.name = (idr["nombre"]).ToString();
                    vwce.cargo = (idr["nombreCargo"]).ToString();


                }
                return vwce;
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

        public bool editarCargoEmpleado(tbl_cargoEmpleado ce)
        {
            bool editado = false;
            int x = 0;
            sb.Clear();
            sb.Append("Update ControlBD.`Cargos Empleados`");
            sb.Append(" set Cargo_idCargo= " + ce.idCargo + ",");
            sb.Append(" Empleados_idEmpleados= " + ce.idEmpleados + " ");
            sb.Append(" WHERE idCargosEmpleados = " + ce.idCargosEmpleado);

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

        public bool eliminarCargoEmpleado(tbl_cargoEmpleado ce)
        {
            bool eliminado = false;
            int x = 0;
            sb.Clear();
            sb.Append("DELETE FROM ControlBD.`Cargos Empleados` WHERE idCargosEmpleados = " + ce.idCargosEmpleado);


            Console.WriteLine(sb.ToString());
            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());
                if (x > 0)
                {
                    eliminado = true;
                }
                return eliminado;

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
    }
}
