using System;
namespace SistemaEmpleadosEyS
{
    public partial class EntradaSalida : Gtk.Window
    {
        public EntradaSalida() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
