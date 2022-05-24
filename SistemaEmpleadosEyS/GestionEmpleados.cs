using System;
using Gtk;
using SistemaEmpleadosEyS.Datos;
using SistemaEmpleadosEyS.Entidades;
namespace SistemaEmpleadosEyS
{
    public partial class GestionEmpleados : Gtk.Window
    {
        //DECLARACIONES E INSTANCIAS DE OBJETOS
        tbl_empleado tbe = new tbl_empleado();

        DT_tbl_Empleado dte = new DT_tbl_Empleado();

        MessageDialog ms = null;

        //SE EJECUTA CUANDO SE ABRE LA VENTANA
        public GestionEmpleados() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.DeleteEvent += new DeleteEventHandler(Cerrar);

            //CARGAMOS EL TREEVIEW
            this.tvEmpleado.Model = dte.listaUsuario();

            string[] titulos = { "idEmpleados", "cedula", "nombres", "apellidos", "direccion", "telefono", "correo", "correoEmp", "pin", "estado" };
            for (int i = 0; i < titulos.Length; i++)     
            {
                this.tvEmpleado.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }

        }
        protected void Cerrar(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }

       
    }
}
