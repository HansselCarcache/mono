using System;
namespace SistemaEmpleadosEyS.Entidades
{
    public class tbl_cargoEmpleado
    {
        private int idCargosEmpleados;
        private int Cargo_idCargo;
        private int Empleados_idEmpleados;

       
        public int idCargosEmpleado { get => idCargosEmpleados; set => idCargosEmpleados = value; }
        public int idCargo { get => Cargo_idCargo; set => Cargo_idCargo = value; }
        public int idEmpleados { get => Empleados_idEmpleados; set => Empleados_idEmpleados = value; }
        public tbl_cargoEmpleado()
        {


            
        }
    }
}
