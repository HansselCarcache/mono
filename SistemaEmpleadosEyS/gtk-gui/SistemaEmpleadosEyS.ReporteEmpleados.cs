
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEmpleadosEyS
{
	public partial class ReporteEmpleados
	{
		private global::Gtk.VBox vbox3;

		private global::Gtk.Label lbReporte;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView treeview2;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEmpleadosEyS.ReporteEmpleados
			this.Name = "SistemaEmpleadosEyS.ReporteEmpleados";
			this.Title = global::Mono.Unix.Catalog.GetString("ReporteEmpleados");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEmpleadosEyS.ReporteEmpleados.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.lbReporte = new global::Gtk.Label();
			this.lbReporte.Name = "lbReporte";
			this.lbReporte.LabelProp = global::Mono.Unix.Catalog.GetString("Reporte de Empleados");
			this.vbox3.Add(this.lbReporte);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.lbReporte]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeview2 = new global::Gtk.TreeView();
			this.treeview2.CanFocus = true;
			this.treeview2.Name = "treeview2";
			this.GtkScrolledWindow.Add(this.treeview2);
			this.vbox3.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.GtkScrolledWindow]));
			w3.Position = 1;
			this.Add(this.vbox3);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
