using System;
using System.Web.UI;

namespace Revista.Componentes
{
    public partial class Avisos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void show(string Mensaje)
        {
            this.TxtAviso.Text = Mensaje;
            this.Visible = true;
            Page.ClientScript.RegisterStartupScript(
             Page.GetType(),
              "MessageBox",
              "<script language='javascript'>alert('" + Mensaje + "');</script>"
           );
        }

        

    }
}