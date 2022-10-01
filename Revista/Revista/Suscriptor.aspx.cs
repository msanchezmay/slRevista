using Entidad;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Revista.Revista
{
    public partial class Suscriptor : System.Web.UI.Page
    {
        #region Propiedades
        CtrlRevista ctrl = new CtrlRevista();
        EntSuscriptor datosSusbcritores = new EntSuscriptor();
        List<EntSuscriptor> listaSuscriptores = new List<EntSuscriptor>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gvDatos.Visible = false;
        }

        void ListadoSuscriptores()
        {
           
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumeroDocumento.Text))
            {
                this.Avisos.show("No se proporcionado información");
            }
            else
            {
                datosSusbcritores = new EntSuscriptor
                {
                    Idsuscriptor = 0,
                    Numerodocumento = Int32.Parse(this.txtNumeroDocumento.Text),
                    Tipodocumento = this.ddlTipoDocumento.SelectedValue
                };
                listaSuscriptores = this.ctrl.ObtenerSuscriptor(datosSusbcritores);

                if (listaSuscriptores.Count() == 0)
                {
                    this.Avisos.show("No existe suscriptor con el tipo y numero de documento, ¿Desea darlo de alta?");
                    
                } else if (listaSuscriptores.Count() == 1)
                {
                    this.txtNombre.Text = listaSuscriptores[0].Nombre;
                    this.txtApellido.Text = listaSuscriptores[0].Apellido;
                    this.txtDireccion.Text = listaSuscriptores[0].Direccion;
                    this.txtMail.Text = listaSuscriptores[0].Email;
                    this.txtTelefono.Text = listaSuscriptores[0].Telefono;
                    this.txtEstado.Text = "Suscrito";
                    this.txtUsuario.Text = listaSuscriptores[0].Nombreusuario;
                    this.txtContrasenia.Text = listaSuscriptores[0].Password;
                    this.txtIdSuscriptor.Value = listaSuscriptores[0].Idsuscriptor.ToString();
                    this.txtDias.Value = listaSuscriptores[0].Dias.ToString();
                }
                else
                {
                    this.gvDatos.Visible = true;
                    this.gvDatos.DataSource = this.listaSuscriptores;
                    this.gvDatos.DataBind();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            long existe = ctrl.BuscarUsuario(this.txtUsuario.Text);
            if (existe > 0)
            {
                this.Avisos.show("El usuario ya se encuentra registrado");
                this.txtUsuario.Enabled = false;
            }
            else
            {
                datosSusbcritores = new EntSuscriptor
                {
                    Idsuscriptor = Int32.Parse(this.txtIdSuscriptor.Value),
                    Nombre = this.txtNombre.Text,
                    Apellido = this.txtApellido.Text,
                    Direccion = this.txtDireccion.Text,
                    Email = this.txtMail.Text,
                    Telefono = this.txtTelefono.Text,
                    Nombreusuario = this.txtUsuario.Text,
                    Password = this.txtContrasenia.Text,
                    Numerodocumento = Int32.Parse(this.txtNumeroDocumento.Text),
                    Tipodocumento = this.ddlTipoDocumento.SelectedValue
                };
                var alta = this.ctrl.AltaSuscriptor(datosSusbcritores);
                this.txtIdSuscriptor.Value = alta.Idsuscriptor.ToString();
                this.Avisos.show("Se ha registrado un nuevo suscriptor: " + this.txtUsuario.Text + " y contraseña: " + this.txtContrasenia.Text + ", ¿El suscriptor se realizo con exito?");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            datosSusbcritores = new EntSuscriptor
            {
                Idsuscriptor = Int32.Parse(this.txtIdSuscriptor.Value),
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                Direccion = this.txtDireccion.Text,
                Email = this.txtMail.Text,
                Telefono = this.txtTelefono.Text,
                Nombreusuario = this.txtUsuario.Text,
                Password = this.txtContraseniaUpdate.Value,
                Numerodocumento = Int32.Parse(this.txtNumeroDocumento.Text),
                Tipodocumento = this.ddlTipoDocumento.SelectedValue
            };
            var alta = this.ctrl.AltaSuscriptor(datosSusbcritores);
            this.txtIdSuscriptor.Value = alta.Idsuscriptor.ToString();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDireccion.Text = "";
            this.txtMail.Text = "";
            this.txtTelefono.Text = "";
            this.txtEstado.Text = "No Suscrito";
            this.txtUsuario.Text = "";
            this.txtContrasenia.Text = "";
            this.txtNumeroDocumento.Text = "";
            this.txtContraseniaUpdate.Value = "";
            this.txtUsuario.Enabled = true;
            datosSusbcritores = new EntSuscriptor();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDireccion.Text = "";
            this.txtMail.Text = "";
            this.txtTelefono.Text = "";
            this.txtEstado.Text = "No Suscrito";
            this.txtUsuario.Text = "";
            this.txtContrasenia.Text = "";
            this.txtNumeroDocumento.Text = "";
            this.txtContraseniaUpdate.Value = "";
            this.txtUsuario.Enabled = true;
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDatos.Rows[index];

                if (e.CommandName == "Select")
                {
                    gvDatos.SelectedIndex = index;

                    this.txtUsuario.Enabled = false;
                    datosSusbcritores = new EntSuscriptor
                    {
                        Idsuscriptor = Int32.Parse(Server.HtmlDecode(row.Cells[9].Text)),
                        Numerodocumento = Int32.Parse(Server.HtmlDecode(row.Cells[5].Text)),
                        Tipodocumento = Server.HtmlDecode(row.Cells[4].Text)
                    };
                    listaSuscriptores = this.ctrl.ObtenerSuscriptor(datosSusbcritores);
                    this.txtNombre.Text = listaSuscriptores[0].Nombre;
                    this.txtApellido.Text = listaSuscriptores[0].Apellido;
                    this.txtDireccion.Text = listaSuscriptores[0].Direccion;
                    this.txtMail.Text = listaSuscriptores[0].Email;
                    this.txtTelefono.Text = listaSuscriptores[0].Telefono;
                    this.txtEstado.Text = "Suscrito";
                    this.txtUsuario.Text = listaSuscriptores[0].Nombreusuario;
                    this.txtContraseniaUpdate.Value = listaSuscriptores[0].Password;
                    this.txtIdSuscriptor.Value = listaSuscriptores[0].Idsuscriptor.ToString();
                    this.txtDias.Value = listaSuscriptores[0].Dias.ToString();
                    this.txtContrasenia.Text = this.txtContraseniaUpdate.Value;
                    this.gvDatos.Visible = false;
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("{0} Exception caught.", er);

            }
        }

        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[9].Visible = false;
                //e.Row.Cells[3].Visible = false;
            }
            catch { }
        }

        protected void btnRegistarSubscripcion_Click(object sender, EventArgs e)
        {
            if (this.txtIdSuscriptor.Value=="0")
            {
                this.Avisos.show("No se proporcionado información");
            }if (Int32.Parse(this.txtDias.Value) > 0)
            {
                this.Avisos.show("La suscripción esta vigente");
            }
            else
            {
                Response.Redirect("~/Revista/Suscripcion.aspx?id=" + this.txtIdSuscriptor.Value);
            }
        }
    }
}