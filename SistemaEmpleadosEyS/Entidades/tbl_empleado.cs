using System;
namespace SistemaEmpleadosEyS.Entidades
{
    public class tbl_empleado
    {
        private int id_empleado;
        private string cedula;
        private string nombres;
        private string apellidos;
        private DateTime fechaNac;
        private string direccion;
        private string telefono;
        private string correo;
        private string correoEmp;
        private string pin;
        private int estado;


        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public string Cedula { get => cedula; set => cedula= value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo{ get => correo; set => correo = value; }
        public string CorreoEmp { get => correoEmp; set => correoEmp = value; }
        public string Pin { get => pin; set => pin = value; }
        public int Estado { get => estado; set => estado = value; }




        public tbl_empleado()
        {
        }
    }
}
