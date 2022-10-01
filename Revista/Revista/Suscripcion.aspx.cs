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
    public partial class Suscripcion : System.Web.UI.Page
    {
        #region Propiedades
        CtrlRevista ctrl = new CtrlRevista();
        EntSuscriptor datosSusbcritores = new EntSuscriptor();
        List<EntSuscriptor> listaSuscriptores = new List<EntSuscriptor>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            String Valor = Request.QueryString["id"];
            
           this.txtFechaAlt.Text = DateTime.Now.ToShortDateString();
            datosSusbcritores = new EntSuscriptor
            {
                Idsuscriptor = Int32.Parse(Valor),
                Numerodocumento = 0,
                Tipodocumento = "X"
            };
            listaSuscriptores = this.ctrl.ObtenerSuscriptor(datosSusbcritores);
            if (listaSuscriptores.Count() > 0)
            {
                this.datosSusbcritores = this.listaSuscriptores[0];
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntSuscripcion datos = new EntSuscripcion {
                Idasociacion = 0,
                Idsuscriptor=this.datosSusbcritores.Idsuscriptor,
                Fechaalta=DateTime.Parse(this.txtFechaAlt.Text),
                Fechafin=DateTime.Parse(this.txtFechaFin.Text),
                Motivofin=this.txtMotivo.Text
            };

            this.ctrl.AltaSuscripcion(datos);
            Response.Redirect("~/Revista/Suscriptor.aspx");
        }
    }
}