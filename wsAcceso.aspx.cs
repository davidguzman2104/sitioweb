using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace wsProyecto
{
    public partial class wsAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void btnAcceder_Click(object sender, EventArgs e)
        {
            await CargarDatosDesdeApi();
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            // Redirige a la página de registro (debes crear wsRegistro.aspx)
            Response.Redirect("wsRegistro.aspx");
        }

        private async Task CargarDatosDesdeApi()
        {
            string datosJson = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                     datosJson = @"{
                        ""usuario"":""" + txtUsuario.Text.Trim() + @""",
                        ""contrasena"":""" + txtPassword.Text.Trim() + @"""
                    }";
                    Response.Write(datosJson);


                    HttpContent contenido = new StringContent(datosJson, Encoding.UTF8, "application/json");

                    string urlApi = "https://localhost:44321/check/usuario/spvalidaracceso";

                    HttpResponseMessage respuesta = await client.PostAsync(urlApi, contenido);


                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();

                        JObject jsonResp = JObject.Parse(resultado);
                        int ban = jsonResp["ban"]?.Value<int>() ?? 0;

                        if (ban == 1)
                        {
                            Session["nomUsuario"] = jsonResp["datos"]["Alu_nombre_completo"]?.ToString();
                            Session["correoUsuario"] = jsonResp["datos"]["Alu_mail"]?.ToString();
                            Session["carreraUsuario"] = jsonResp["datos"]["Alu_Carrera"]?.ToString();
                            Session["fotoUsuario"] = jsonResp["datos"]["Alu_Foto"]?.ToString();

                            ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                         "alert('Bienvenido(a): " + Session["nomUsuario"] + "'); window.location='Formulario web1.aspx';", true);

                        }
                        else
                        {
                            Session.Clear();
                            lblMensaje.Text = "Acceso denegado. Verifica tus credenciales.";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Error de conexión con el servidor. Intenta más tarde.";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(datosJson);


                lblMensaje.Text = "Error: " + ex.Message + "<br/>" + ex.StackTrace + "<br><br>" + datosJson;
            }
        }
    }
}
