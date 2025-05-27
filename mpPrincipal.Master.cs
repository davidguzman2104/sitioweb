using System;
using System.Web.UI;

namespace wsCheckUsuario
{
    public partial class mpPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validación de sesión
            if (Session["nomUsuario"] == null ||
                Session["fotoUsuario"] == null ||
                Session["correoUsuario"] == null)
            {
                // Acceso denegado
                Response.Write("<script language='javascript'>" +
                    "alert('¡Acceso Denegado!');" + "</script>");

                Response.Write("<script language='javascript'>" +
                    "document.location.href='wsAcceso.aspx';" + "</script>");
                return;
            }

            // Actualización de etiquetas
            Label6.Text = $"{Session["nomUsuario"]} ({Session["correoUsuario"]}) - {Session["carreraUsuario"]}";

            // Foto de perfil
            image3.ImageUrl = Session["fotoUsuario"].ToString();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            // Cierre de sesión
            Session.Clear();
            Response.Write("<script language='javascript'>" +
              "alert('¡Sesión Cerrada Exitosamente!');" + "</script>");

            Response.Write("<script language='javascript'>" +
                "document.location.href='wsAcceso.aspx';" + "</script>");
        }
    }
}
