using System;
namespace SistemaEmpleadosEyS.Entidades
{
    public class tbl_cargo
    {
        private int id_cargo;
        private string nombreCargo;
        private int estado;

        public int IdCargo { get => id_cargo; set => id_cargo = value; }
        public string NombreCargo { get => nombreCargo; set => nombreCargo = value; }
        public int Estado { get => estado; set => estado = value; }
        public tbl_cargo()
        {
        }
    }
}
