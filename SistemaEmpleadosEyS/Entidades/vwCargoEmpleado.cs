using System;
namespace SistemaEmpleadosEyS.Entidades
{
    public class vwCargoEmpleado
    {
        private int idCargoEmpleado;
        private int idEmpleados;
        private string nombre;
        private int estadoE;
        private int idCargo;
        private string nombreCargo;
        private int estadoC;

        public int idcargoEmpleado { get => idCargoEmpleado; set => idCargoEmpleado = value; }
        public int idEmpleado { get => idEmpleados; set => idEmpleados = value; }
        public string name { get => nombre; set => nombre = value; }
        public int estadoEmpleado { get => estadoE; set => estadoE = value; }
        public int idcargo { get => idCargo; set => idCargo = value; }
        public string cargo { get => nombreCargo;  set => nombreCargo = value; }
        public int estadoCargo { get => estadoC; set => estadoC = value; }

        public vwCargoEmpleado()
        {
        }
    }
}
