using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnBtnAdminClicked(object sender, EventArgs e)
    {
        SistemaEmpleadosEyS.MenuAdministrador menuAdmin = new SistemaEmpleadosEyS.MenuAdministrador();
        menuAdmin.Show();
        this.Hide();
    }
}
