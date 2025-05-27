using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using wsProyecto.Models;
using System.Text;
using System.Text.Json;
using static wsProyecto.Formulario_web3;

namespace wsProyecto
{
    public partial class Formulario_web3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public class clsItems
        {
            public int id_item { get; set; }
            public string nombre_item { get; set; }
            public string foto { get; set; }
            public string estado_item { get; set; }
            public string ubicacion_item { get; set; }
            public string disponibilidad_entrega { get; set; }
            public int num_control { get; set; }
            public string nombre_alumno { get; set; }
        }

        public class Datos
        {
            public List<clsItems> ObtenerItems { get; set; }
        }

        public class RespuestaAPI
        {
            public bool statusExec { get; set; }
            public string msg { get; set; }
            public int ban { get; set; }
            public Datos datos { get; set; }
        }

        private async Task cargaDatos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Construcción correcta del JSON con nombres exactos
                    string data = @"{
                    ""id_item"": " + TextBox6.Text + @",
                    ""nombre_item"": """ + TextBox1.Text + @""",
                    ""foto"": """ + TextBox2.Text + @""",
                    ""estado_item"": """ + TextBox3.Text + @""",
                    ""ubicacion_item"": """ + TextBox4.Text + @""",
                    ""disponibilidad_entrega"": """ + TextBox5.Text + @""",
                    ""num_control"": " + TextBox7.Text + @",
                    ""nombre_alumno"": """ + TextBox8.Text + @"""
                    }";


                    HttpContent contenido = new StringContent(data, Encoding.UTF8, "application/json");
                    string apiUrl = "https://localhost:44321/insertar";

                    HttpResponseMessage respuesta = await client.PostAsync(apiUrl, contenido);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        var objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        if (objRespuesta.ban == 0)
                        {
                            Response.Write("<script>alert('Item ha registrado exitosamente');</script>");
                            Response.Write("<script>document.location.href='Formulario web3.aspx';</script>");
                        }
                        else if (objRespuesta.ban == 1)
                        {
                            Response.Write("<script>alert('El id del item ya existe');</script>");
                        }
                        else if (objRespuesta.ban == 2)
                        {
                            Response.Write("<script>alert('El nombre ya existe');</script>");
                        }
                        else if (objRespuesta.ban == 3)
                        {
                            Response.Write("<script>alert('La ruta de la foto no se encuentra');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Error inesperado.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Error de conexión con el servicio');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error de la aplicación, intentar nuevamente');</script>");
            }
        }


        private async Task DeleteItem()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                      ""id"":""" + TextBox6.Text + @"""
                                    }";
                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = $"https://localhost:44321/eliminar/{TextBox6.Text}";
                    // ----------------------------------------------
                    HttpResponseMessage respuesta = await client.DeleteAsync(apiUrl);
                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();
                    // ---------------------------------------------------

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado =
                                await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        // Bandera de estatus del proceso
                        if (objRespuesta.ban == 0)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('Item Eliminado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web3.aspx';" +
                                           "</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('Error de conexión con el servicio');" +
                                       "</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>" +
                               "alert('Error de la aplicación, intentar nuevamente');" +
                               "</script>");
            }
        }
        private async Task consultaItemPorid()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string id = TextBox6.Text.Trim();
                    string apiUrl = $"https://localhost:44321/obtener/{id}";

                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();

                        // Deserializa como lista porque la API devuelve un array JSON
                        var listaItems = JsonConvert.DeserializeObject<List<clsItems>>(resultado);

                        if (listaItems != null && listaItems.Count > 0)
                        {
                            var item = listaItems[0];
                            TextBox1.Text = item.nombre_item;
                            TextBox2.Text = item.foto;
                            TextBox3.Text = item.estado_item;
                            TextBox4.Text = item.ubicacion_item;
                            TextBox5.Text = item.disponibilidad_entrega;
                            TextBox6.Text = item.id_item.ToString();
                            TextBox7.Text = item.num_control.ToString();
                            TextBox8.Text = item.nombre_alumno;
                        }
                        else
                        {
                            Response.Write("<script>alert('Item no encontrado.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al conectar con la API.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error de aplicación: {ex.Message}');</script>");
            }
        }

        private async Task updateDatos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    string data = @"{
                    ""id_item"": " + TextBox6.Text + @",
                    ""nombre_item"": """ + TextBox1.Text + @""",
                    ""foto"": """ + TextBox2.Text + @""",
                    ""estado_item"": """ + TextBox3.Text + @""",
                    ""ubicacion_item"": """ + TextBox4.Text + @""",
                    ""disponibilidad_entrega"": """ + TextBox5.Text + @""",
                    ""num_control"": " + TextBox7.Text + @",
                    ""nombre_alumno"": """ + TextBox8.Text + @"""
                    }";

                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = "https://localhost:44321/actualizar";
                    // ----------------------------------------------
                    HttpResponseMessage respuesta =
                        await client.PutAsync(apiUrl, contenido);
                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();
                    // ---------------------------------------------------

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado =
                                await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        // Bandera de estatus del proceso
                        if (objRespuesta.ban == 0)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('Usuario Actualizado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web3.aspx';" +
                                           "</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('Error de conexión con el servicio');" +
                                       "</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>" +
                               "alert('Error de la aplicación, intentar nuevamente');" +
                               "</script>");
            }
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            //Nombre 
            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                               "alert('El nombre esta vacio');" +
                               "</script>");

            }
            else
            {
                //Foto
                if (TextBox2.Text == "")
                {
                    Response.Write("<script language='javascript'>" +
                                   "alert('La foto no se a definido');" +
                                   "</script>");

                }
                else
                {
                    //estatus
                    if (TextBox3.Text == "")
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('No se ha resgitrado el Status');" +
                                       "</script>");

                    }
                    else
                    {
                        //ubicacion
                        if (TextBox4.Text == "")
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('La ubicacion no se encuentra');" +
                                           "</script>");

                        }
                        else
                        {
                            //Disponibilidad
                            if (TextBox5.Text == "")
                            {
                                Response.Write("<script language='javascript'>" +
                                               "alert('La disponibilidad no se encuentra');" +
                                               "</script>");

                            }
                            else
                            {
                                //id
                                if (TextBox6.Text == "")
                                {
                                    Response.Write("<script language='javascript'>" +
                                                   "alert('El id no se encuentra');" +
                                                   "</script>");

                                }
                                else
                                {
                                    //id
                                    if (TextBox7.Text == "")
                                    {
                                        Response.Write("<script language='javascript'>" +
                                                       "alert('El No.control esta vacio');" +
                                                       "</script>");

                                    }
                                    else
                                    {
                                        //id
                                        if (TextBox8.Text == "")
                                        {
                                            Response.Write("<script language='javascript'>" +
                                                           "alert('El nombre_alumno esta vacios');" +
                                                           "</script>");

                                        }
                                        else
                                        {
                                            //ejecucion asincrona del metodo de insercion de usuario
                                            await cargaDatos();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        protected async void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox6.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El id está vacío');" +
                "</script>");
            }
            else
            {
                await DeleteItem();
            }
        }

        protected async void ImageButtonBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox6.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El id está vacío');" +
                "</script>");
            }
            else
            {
                await consultaItemPorid();
            }
        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            //Nombre 
            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                               "alert('El nombre esta vacio');" +
                               "</script>");

            }
            else
            {
                //Foto
                if (TextBox2.Text == "")
                {
                    Response.Write("<script language='javascript'>" +
                                   "alert('La foto no se a definido');" +
                                   "</script>");

                }
                else
                {
                    //estatus
                    if (TextBox3.Text == "")
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('No se ha resgitrado el Status');" +
                                       "</script>");

                    }
                    else
                    {
                        //ubicacion
                        if (TextBox4.Text == "")
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('La ubicacion no se encuentra');" +
                                           "</script>");

                        }
                        else
                        {
                            //Disponibilidad
                            if (TextBox5.Text == "")
                            {
                                Response.Write("<script language='javascript'>" +
                                               "alert('La disponibilidad no se encuentra');" +
                                               "</script>");

                            }
                            else
                            {
                                //id
                                if (TextBox6.Text == "")
                                {
                                    Response.Write("<script language='javascript'>" +
                                                   "alert('El id no se encuentra');" +
                                                   "</script>");

                                }
                                else
                                {
                                    //id
                                    if (TextBox7.Text == "")
                                    {
                                        Response.Write("<script language='javascript'>" +
                                                       "alert('El No.control esta vacio');" +
                                                       "</script>");

                                    }
                                    else
                                    {
                                        //id
                                        if (TextBox8.Text == "")
                                        {
                                            Response.Write("<script language='javascript'>" +
                                                           "alert('El nombre_alumno esta vacios');" +
                                                           "</script>");

                                        }
                                        else
                                        {
                                            //ejecucion asincrona del metodo de insercion de usuario
                                            await updateDatos();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}