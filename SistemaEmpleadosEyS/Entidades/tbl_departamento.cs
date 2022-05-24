using System;
namespace SistemaEmpleadosEyS.Entidades
{
    public class tbl_departamento
    {
        private int id_departamento;
        private string nombreDep;
        private string extension;
        private string correoDep;
        private int estado;

        public int IdDep { get => id_departamento; set => id_departamento = value; }
        public string NombreDep { get => nombreDep; set => nombreDep = value; }
        public string Extension { get => extension; set => extension = value; }
        public string CorreoDep { get => correoDep; set => correoDep = value; }
        public int Estado { get => estado; set => estado = value; }
        public tbl_departamento()
        {
        }
    }
}
