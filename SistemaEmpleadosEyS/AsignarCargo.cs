using System;
using Gtk;
using SistemaEmpleadosEyS.Entidades;
using SistemaEmpleadosEyS.Datos;
using System.Collections.Generic;

namespace SistemaEmpleadosEyS
{
    public partial class AsignarCargo : Gtk.Window
    {

        tbl_cargoEmpleado tce = new tbl_cargoEmpleado();
        vwCargoEmpleado vwce = new vwCargoEmpleado();
        DT_tbl_CargoEmpleado dtce = new DT_tbl_CargoEmpleado();

        MessageDialog ms = null;


        public AsignarCargo() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            //this.DeleteEvent += new DeleteEventHandler(Cerrar);

            cargarTabla();
           

            ListStore listaEmpleado = dtce.listEmpleados();

            for (int i = 0; i < listaEmpleado.IterNChildren(); i++)
            {
                TreeIter iter;
                listaEmpleado.GetIterFromString(out iter, i.ToString());
                this.cbxEmpleado.AppendText(listaEmpleado.GetValue(iter, 1).ToString());

            }

            ListStore listaCargo = dtce.listCargos();
            for (int i = 0; i < listaCargo.IterNChildren(); i++)
            {
                TreeIter iter;
                listaCargo.GetIterFromString(out iter, i.ToString());
                this.cbxCargo.AppendText(listaCargo.GetValue(iter, 1).ToString());

            }

        }



        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {

            if (this.cbxCargo.Active == -1 || this.cbxEmpleado.Active == -1 )
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Asegurese de elegir un empleado y un cargo.");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                int idcar = getIDCargo();
                int idemp = getIDEmpleado();

                tce.idCargo = idcar;
                tce.idEmpleados = idemp;

                if (dtce.guardarCargEmpleado(tce))
                {
                    Console.WriteLine("Se guardaron los datos sin problemas!");
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "Se han guardado los datos con éxito ");
                    ms.Run();
                    ms.Destroy();
                    this.tvACargo.Model = dtce.listaCargoEmpleado();

                }
                else
                {
                    Console.WriteLine("Ocurrió un Error");
                }
            }

        }

        public void cargarTabla()
        {
            //CARGAMOS EL TREEVIEW

            this.tvACargo.Model = dtce.listaCargoEmpleado();

            string[] titulos = { "idCargoEmpleado", "idEmpleado", "Nombre", "idCargo", "nombreCargo" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvACargo.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnTvACargoCursorChanged(object sender, EventArgs e)
        {

            try
            {
                vwce.cargo = "";
                TreeSelection seleccion = (sender as TreeView).Selection;
                TreeIter iter;
                TreeModel model;
                if (seleccion.GetSelected(out model, out iter))
                {
                    vwce = dtce.listById(Convert.ToInt32(model.GetValue(iter, 0).ToString()));
                    this.txtID.Text = vwce.idcargoEmpleado.ToString();
                    this.cbxEmpleado.SetActiveIter(iter);
                    /*this.txtExt.Text = tbd.Extension.ToString();
                    this.txtEmail.Text = tbd.CorreoDep.ToString();*/
                    //Console.WriteLine(vwce.idcargoEmpleado);
                    TreeIter ti;
                    String chk;
                    cbxCargo.Model.GetIterFirst(out ti);
                   
                    do
                    {
                        chk = cbxCargo.Model.GetValue(ti, 0).ToString();
                        if (chk == vwce.cargo.ToString())
                        {
                            Console.WriteLine("Done - found"); cbxCargo.SetActiveIter(ti);
                            break;
                        }
                    }while (cbxCargo.Model.IterNext(ref ti));


                    TreeIter ti2;
                    String chk2;
                    cbxEmpleado.Model.GetIterFirst(out ti2);

                    do
                    {
                        chk2 = cbxEmpleado.Model.GetValue(ti2, 0).ToString();
                        if (chk2 == vwce.name.ToString())
                        {
                            Console.WriteLine("Done - found"); cbxEmpleado.SetActiveIter(ti2);
                            break;
                        }
                    } while (cbxEmpleado.Model.IterNext(ref ti2));

                }

            }

            catch (Exception ex)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        public void limpiarCampos()
        {
            this.txtID.Text = "";
            this.cbxCargo.Active = -1;
            this.cbxEmpleado.Active = -1;


        }



        public int getIDEmpleado()
        {
            int idemp = 0;
            ///////CONSEGUIR ID EMPLEADO/////////////
            TreeIter tree3;
            cbxEmpleado.GetActiveIter(out tree3);
            //TreeModel = cbxEmpleado.Model();
            String nombreEmpleado = (String)cbxEmpleado.Model.GetValue(tree3, 0);
            Console.WriteLine(nombreEmpleado);

            ListStore listaEmpleado = dtce.listEmpleados();
            for (int i = 0; i < listaEmpleado.IterNChildren(); i++)
            {

                TreeIter iter;

                listaEmpleado.GetIterFromString(out iter, i.ToString());
                if (nombreEmpleado.Equals(listaEmpleado.GetValue(iter, 1).ToString()))
                {
                    idemp = Int32.Parse(listaEmpleado.GetValue(iter, 0).ToString());

                    Console.WriteLine(idemp);
                }

            }
            return idemp;
        }

        public int getIDCargo()
        {
            int idcar = 0;
            ///////CONSEGUIR ID CARGO/////////////
            TreeIter tree4;
            cbxCargo.GetActiveIter(out tree4);
            //TreeModel = cbxEmpleado.Model();
            String nombreCargo = (String)cbxCargo.Model.GetValue(tree4, 0);
            Console.WriteLine(nombreCargo);

            ListStore listaCargo = dtce.listCargos();
            for (int i = 0; i < listaCargo.IterNChildren(); i++)
            {

                TreeIter iter;

                listaCargo.GetIterFromString(out iter, i.ToString());
                if (nombreCargo.Equals(listaCargo.GetValue(iter, 1).ToString()))
                {
                    idcar = Int32.Parse(listaCargo.GetValue(iter, 0).ToString());

                    Console.WriteLine(idcar);
                }

            }
            return idcar;
        }


        protected void OnBtnEditarClicked(object sender, EventArgs e)
        {
            if (this.cbxCargo.Active == -1 || this.cbxEmpleado.Active == -1 || this.txtID.Text == "")
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Asegurese que los 3 campos no estén vacíos.");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tce.idCargosEmpleado = Convert.ToInt32(this.txtID.Text.Trim());
                tce.idCargo = getIDCargo();
                tce.idEmpleados = getIDEmpleado();


                if (dtce.editarCargoEmpleado(tce))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "Datos actualizados");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    this.tvACargo.Model = dtce.listaCargoEmpleado();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok,
                        "Error al editar datos");
                    ms.Run();
                    ms.Destroy();
                }
            }

        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {

            if (this.cbxCargo.Active == -1 || this.cbxEmpleado.Active == -1 || this.txtID.Text == "")
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Asegurese que los 3 campos no estén vacíos.");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tce.idCargosEmpleado = Convert.ToInt32(this.txtID.Text.Trim());
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.YesNo, "¿Estás seguro que deseas eliminar los datos?");

                bool result = (ResponseType)ms.Run() == ResponseType.Yes;
                ms.Destroy();

                if (result)
                {
                    if (dtce.eliminarCargoEmpleado(tce))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "Datos eliminados");
                        ms.Run();
                        ms.Destroy();
                        limpiarCampos();

                        this.tvACargo.Model = dtce.listaCargoEmpleado();
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok,
                            "Error al eliminar datos");
                        ms.Run();
                        ms.Destroy();
                    }
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                           MessageType.Info, ButtonsType.Ok, "No se eliminaron los datos");
                    ms.Run();
                    ms.Destroy();
                }
            }


        }

        protected void OnBtnLimpiarClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }

}
