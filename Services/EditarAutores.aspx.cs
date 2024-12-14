using Newtonsoft.Json;
using PruebaCSF_FrontEnd.Models;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace PruebaCSF_FrontEnd.Services
{
    public partial class EditarAutores : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el ID del autor desde la URL
                string idParam = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int id))
                {
                    await CargarAutor(id);
                }
            }
        }

        private async Task CargarAutor(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7062/");
                    var response = await client.GetAsync($"api/Autores/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var autorJson = await response.Content.ReadAsStringAsync();
                        var autor = JsonConvert.DeserializeObject<Autor>(autorJson);

                        // Cargar los datos del autor en los controles del formulario
                        txtId.Value = autor.Id.ToString();
                        txtNombre.Text = autor.Nombres;
                        txtApellido.Text = autor.Apellidos;
                        txtFecha.Text = autor.FechaNacimiento.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo cargar el autor.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }

        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                {
                    var autor = new Autor
                    {
                        Id = int.Parse(txtId.Value),
                        Nombres = txtNombre.Text.Trim(),
                        Apellidos = txtApellido.Text.Trim(),
                        FechaNacimiento = fecha
                    };

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7062/");
                        var jsonContent = new StringContent(JsonConvert.SerializeObject(autor), Encoding.UTF8, "application/json");
                        var response = await client.PutAsync($"api/Autores/{autor.Id}", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            Response.Redirect("ListarAutores.aspx");
                        }
                        else
                        {
                            lblMensaje.Text = "Error al actualizar el autor.";
                        }
                    }
                }
                else
                {
                    lblMensaje.Text = "La fecha ingresada no es válida. Usa el formato dd/MM/yyyy.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }
    }
}
