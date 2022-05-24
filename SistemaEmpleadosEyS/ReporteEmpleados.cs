using System;
namespace SistemaEmpleadosEyS
{
    public partial class ReporteEmpleados : Gtk.Window
    {
        public ReporteEmpleados() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
