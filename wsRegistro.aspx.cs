using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using wsProyecto.Models;

namespace wsProyecto
{
    public partial class wsRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private async Task<bool> RegistrarAlumnoApiAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var alumno = new
                    {
                        num_control = txtNumControl.Text,
                        nombre = txtNombre.Text,
                        apellido_paterno = txtApellidoPaterno.Text,
                        apellido_materno = txtApellidoMaterno.Text,
                        usuario = txtUsuario.Text,
                        contrasena = txtPassword.Text,
                        carrera = txtCarrera.Text,
                        ubicacion_alumno = txtUbicacion.Text,
                        mail = txtEmail.Text,
                        foto = "" 
                    };

                    var json = JsonConvert.SerializeObject(alumno);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:44321/check/usuario/spinusuario", content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error si lo deseas
                return false;
            }
        }


        protected async void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool registrado = await RegistrarAlumnoApiAsync();
            if (registrado)
            {
                Response.Redirect("wsAcceso.aspx", false);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wsAcceso.aspx");
        }

        // Método para mostrar alertas en el navegador de forma segura
        private void MostrarMensaje(string mensaje)
        {
            mensaje = mensaje.Replace("'", "\\'").Replace("\r", "").Replace("\n", "");
            ClientScript.RegisterStartupScript(this.GetType(), "alerta", $"alert('{mensaje}');", true);
        }
    }
}
