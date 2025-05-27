using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using wsProyecto.Models;

namespace wsProyecto
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await CargaDatosApi();
            }
            GridView1.PageIndexChanging += GridView1_PageIndexChanging;
        }

        protected async void ImageButton1_Click(object sender, EventArgs e)
        {
            await CargaDatosApi();
        }

        private async Task CargaDatosApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    clsApiStatus objRespuesta = new clsApiStatus();
                    DataTable dtFinal = new DataTable();

                    string textoBusqueda = TextBox1.Text.Trim();

                    if (string.IsNullOrWhiteSpace(textoBusqueda))
                    {
                        // Si no hay texto, obtener todos los items
                        string apiUrl = "https://localhost:44321/report/items/disponibles";
                        HttpResponseMessage respuesta = await client.GetAsync(apiUrl);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            string resultado = await respuesta.Content.ReadAsStringAsync();
                            objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);
                            JArray jsonArray = (JArray)objRespuesta.datos["Items"]; // Ajusta el nombre según la respuesta
                            DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                            dtFinal.Merge(dt);
                        }
                    }
                    else
                    {
                        string apiUrl;
                        // Verificar si el texto es numérico para buscar por ID o por nombre
                        if (int.TryParse(textoBusqueda, out int id))
                        {
                            // Buscar por id
                            string idEncoded = HttpUtility.UrlEncode(textoBusqueda);
                            apiUrl = $"https://localhost:44321/obtener/{idEncoded}";
                        }
                        else
                        {
                            // Buscar por nombre
                            string nombreEncoded = HttpUtility.UrlEncode(textoBusqueda);
                            apiUrl = $"https://localhost:44321/obtenerPorNombre/{nombreEncoded}";
                        }

                        HttpResponseMessage respuesta = await client.GetAsync(apiUrl);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            string resultado = await respuesta.Content.ReadAsStringAsync();

                            // Dependiendo de la respuesta, si es un JSON plano, deserializamos directo a DataTable
                            dtFinal = JsonConvert.DeserializeObject<DataTable>(resultado);
                        }
                    }

                    if (dtFinal != null && dtFinal.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtFinal;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        Response.Write("<script>alert('No se encontraron resultados.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error inesperado: {ex.Message}');</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            _ = CargaDatosApi(); // Recargar datos async
        }
    }
}
