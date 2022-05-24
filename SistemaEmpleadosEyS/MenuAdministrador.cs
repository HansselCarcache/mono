using System;
namespace SistemaEmpleadosEyS
{
    public partial class MenuAdministrador : Gtk.Window
    {
        public MenuAdministrador() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnBtnReporteClicked(object sender, EventArgs e)
        {
            SistemaEmpleadosEyS.GestionEmpleados gestion = new SistemaEmpleadosEyS.GestionEmpleados();
            gestion.Show();
        }

        protected void OnBtnCargosClicked(object sender, EventArgs e)
        {
            SistemaEmpleadosEyS.ReporteCargo reporteCargo = new SistemaEmpleadosEyS.ReporteCargo();
            reporteCargo.Show();
        }

        protected void OnBtnDepClicked(object sender, EventArgs e)
        {
            SistemaEmpleadosEyS.GestionDepartamentos gestionDepartamentos = new SistemaEmpleadosEyS.GestionDepartamentos();
            gestionDepartamentos.Show();
        }

        protected void OnBtnCarEmpleadoClicked(object sender, EventArgs e)
        {
            SistemaEmpleadosEyS.AsignarCargo asignarCargo = new SistemaEmpleadosEyS.AsignarCargo();
            asignarCargo.Show();
        }
    }
}
