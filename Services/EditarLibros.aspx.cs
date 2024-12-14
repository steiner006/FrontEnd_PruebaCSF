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
    public partial class EditarLibros : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string idParam = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int id))
                {
                    await CargarLibro(id);
                }
            }
        }

        private async Task CargarLibro(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7062/");
                    var response = await client.GetAsync($"api/Libros/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var libroJson = await response.Content.ReadAsStringAsync();
                        var libro = JsonConvert.DeserializeObject<Libro>(libroJson);

                        // Cargar los datos del libro en los controles del formulario
                        txtId.Value = libro.Id.ToString();
                        txtTitulo.Text = libro.Titulo;
                        txtAutores.Text = libro.Autores;
                        txtFecha.Text = libro.AnioPublicacion.ToString("yyyy");
                        txtISBN.Text = libro.ISBN;
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo cargar el libro.";
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
                if (DateTime.TryParseExact(txtFecha.Text, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                {
                    var libro = new Libro
                    {
                        Id = int.Parse(txtId.Value),
                        Titulo = txtTitulo.Text.Trim(),
                        Autores = txtAutores.Text.Trim(),
                        AnioPublicacion = fecha.Year,
                        ISBN = txtISBN.Text.Trim()
                    };

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7062/");
                        var jsonContent = new StringContent(JsonConvert.SerializeObject(libro), Encoding.UTF8, "application/json");
                        var response = await client.PutAsync($"api/Libros/{libro.Id}", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            Response.Redirect("ListarLibros.aspx");
                        }
                        else
                        {
                            lblMensaje.Text = "Error al actualizar el libro.";
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
