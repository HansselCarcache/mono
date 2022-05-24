using System;
using Gtk;
using SistemaEmpleadosEyS.Datos;
using SistemaEmpleadosEyS.Entidades;
namespace SistemaEmpleadosEyS
{
    public partial class GestionDepartamentos : Gtk.Window
    {
        //DECLARACIONES E INSTANCIAS DE OBJETOS
        tbl_departamento tbd = new tbl_departamento();

        DT_tbl_Departamento dtd = new DT_tbl_Departamento();

        MessageDialog ms = null;

        //SE EJECUTA CUANDO SE ABRE LA VENTANA
        public GestionDepartamentos() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.DeleteEvent += new DeleteEventHandler(Cerrar);

            //CARGAMOS EL TREEVIEW
            this.tvDepartamento.Model = dtd.listaUsuario();

            string[] titulos = { "idDepartamento", "nombreDep", "extension", "correoDep", "estado" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvDepartamento.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }

        }
        protected void Cerrar(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            tbd.NombreDep = this.txtDep.Text.Trim();
            tbd.Extension = this.txtExt.Text.Trim();
            tbd.CorreoDep = this.txtEmail.Text.Trim();


            if (dtd.guardarDepartamento(tbd))
            {
                Console.WriteLine("Se guardaron los datos sin problemas!");

            }
            else
            {
                Console.WriteLine("Ocurrió un Error");
            }


        }

        protected void OnTvDepartamentoCursorChanged(object sender, EventArgs e)
        {
            try
            {
            
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                tbd = dtd.listById(Convert.ToInt32(model.GetValue(iter, 0).ToString()));
                this.txtId.Text = tbd.IdDep.ToString();
                this.txtDep.Text = tbd.NombreDep.ToString();
                this.txtExt.Text = tbd.Extension.ToString();
                this.txtEmail.Text = tbd.CorreoDep.ToString();
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
            this.txtId.Text = "";
        }

        protected void OnBtnEditarClicked(object sender, EventArgs e)
        {
            if (txtDep.Text.Equals("") || txtExt.Text.Equals("") ||
            txtEmail.Text.Equals(""))
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
                ButtonsType.Ok, "Todos los campos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tbd.NombreDep = this.txtDep.Text.Trim();
                tbd.Extension = this.txtExt.Text.Trim();
                tbd.CorreoDep = this.txtEmail.Text.Trim();
          

                if (dtd.editarDepartamento(tbd))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "Datos actualizados");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    this.tvDepartamento.Model = dtd.listaUsuario();
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
            if (txtId.Text.Equals(""))
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                MessageType.Warning, ButtonsType.Ok, "Debe seleccionar el usuario a Eliminar");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                //Pregunta para confirmar eliminación de usuario
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.YesNo, "¿Desea eliminar al usuario?");
                ResponseType response = (ResponseType)ms.Run();
                ms.Show();

                if (response == ResponseType.Yes)
                {
                    ms.Destroy();
                    //Se obtiene el valor del id
                    tbd.IdDep = Convert.ToInt32(this.txtId.Text);
                    if (dtd.eliminarDepartamento(tbd) > 0)
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                            ButtonsType.Ok, "El usuario ha sido eliminado");
                        ms.Run();
                        ms.Destroy();
                        limpiarCampos();
                        this.tvDepartamento.Model = dtd.listaUsuario();
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Warning, ButtonsType.Ok, "Error: Verifique los datos del usuario");
                        ms.Run();
                        ms.Destroy();
                    }
                }
                else
                {
                    Console.WriteLine("F");
                    ms.Destroy();
                }


            }
        }
    }

}


