using System;
using SistemaEmpleadosEyS.Datos;
using SistemaEmpleadosEyS.Entidades;

namespace SistemaEmpleadosEyS
{
    public partial class AgregarDepartamento : Gtk.Window
    {
        tbl_departamento tbd = new tbl_departamento();

        DT_tbl_Departamento dtb = new DT_tbl_Departamento();

        public AgregarDepartamento() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }


        }
    }


