
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEmpleadosEyS
{
	public partial class ReporteCargo
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Label lbCargo;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView tvCargo;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEmpleadosEyS.ReporteCargo
			this.Name = "SistemaEmpleadosEyS.ReporteCargo";
			this.Title = global::Mono.Unix.Catalog.GetString("ReporteCargo");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEmpleadosEyS.ReporteCargo.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lbCargo = new global::Gtk.Label();
			this.lbCargo.Name = "lbCargo";
			this.lbCargo.LabelProp = global::Mono.Unix.Catalog.GetString("Reporte Cargo");
			this.vbox1.Add(this.lbCargo);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.lbCargo]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvCargo = new global::Gtk.TreeView();
			this.tvCargo.CanFocus = true;
			this.tvCargo.Name = "tvCargo";
			this.GtkScrolledWindow.Add(this.tvCargo);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w3.Position = 1;
			this.Add(this.vbox1);
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