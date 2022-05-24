using System;
using Gtk;
using SistemaEmpleadosEyS.Datos;
using SistemaEmpleadosEyS.Entidades;
namespace SistemaEmpleadosEyS
{
    public partial class ReporteCargo : Gtk.Window
    {
        //DECLARACIONES E INSTANCIAS DE OBJETOS
        tbl_cargo tbc = new tbl_cargo();

        DT_tbl_Cargo dtc = new DT_tbl_Cargo();

        MessageDialog ms = null;

        //SE EJECUTA CUANDO SE ABRE LA VENTANA
        public ReporteCargo() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.DeleteEvent += new DeleteEventHandler(Cerrar);

            //CARGAMOS EL TREEVIEW
            this.tvCargo.Model = dtc.listaUsuario();

            string[] titulos = { "idCargo", "nombreCargo", "estado" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvCargo.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }

        }
        protected void Cerrar(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }


    }
}
