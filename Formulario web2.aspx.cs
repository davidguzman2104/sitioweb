using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wsProyecto
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e) { }

        // CONSULTA por número de control (ImageButton5)
        protected async void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            string numControl = TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(numControl))
            {
                string url = $"https://localhost:44321/alumnos/obtener/num_control?num_control={numControl}";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();

                            var datos = JArray.Parse(json);
                            if (datos.Count > 0)
                            {
                                var alumno = datos[0];

                                TextBox2.Text = alumno["nombre"]?.ToString();
                                TextBox3.Text = alumno["apellido_paterno"]?.ToString();
                                TextBox4.Text = alumno["apellido_materno"]?.ToString();
                                TextBox5.Text = alumno["usuario"]?.ToString();
                                TextBox6.Text = alumno["contraseña"]?.ToString();
                                TextBox7.Text = alumno["carrera"]?.ToString();
                                TextBox8.Text = alumno["ubicacion_alumno"]?.ToString();
                                TextBox9.Text = alumno["mail"]?.ToString();
                                TextBox10.Text = alumno["foto"]?.ToString();
                            }
                            else
                            {
                                Response.Write("<script>alert('No se encontró ningún alumno con ese número de control.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Error al obtener los datos del servidor.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Ingresa un número de control.');</script>");
            }
        }


        // MODIFICAR alumno
        protected async void Button2_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44321/alumnos/actualizar";

            var alumno = new
            {
                num_control = TextBox1.Text,
                nombre = TextBox2.Text,
                apellido_paterno = TextBox3.Text,
                apellido_materno = TextBox4.Text,
                usuario = TextBox5.Text,
                contrasena = TextBox6.Text,
                carrera = TextBox7.Text,
                ubicacion_alumno = TextBox8.Text,
                mail = TextBox9.Text,
                foto = TextBox10.Text
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(alumno);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Éxito
                        Response.Write("<script>alert('Datos modificados correctamente');</script>");
                    }
                    else
                    {
                        // Error en la respuesta
                        string errorMsg = await response.Content.ReadAsStringAsync();
                        Response.Write($"<script>alert('Error al modificar datos: {errorMsg}');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
            }
        }


        // ELIMINAR alumno
        protected async void Button3_Click(object sender, EventArgs e)
        {
            string num_control = TextBox1.Text;

            if (!string.IsNullOrEmpty(num_control))
            {
                string url = $"https://localhost:44321/alumnos/eliminar/num_control?num_control={num_control}";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        Response.Redirect("wsAcceso.aspx");
                    }
                    else
                    {
                        string errorMsg = await response.Content.ReadAsStringAsync();
                        Response.Write($"<script>alert('Error al eliminar: {errorMsg}');</script>");
                    }
                }
            }
        }
    }
}
