using JN_API.Entities;
using System.Net.Http.Headers;

namespace JN_FRONT.Modelsjklñfsa
{
    public class UsuarioModel
    {

        public UsuarioObj? ValidarUsuario(UsuarioObj objeto)
        {
            using (HttpClient acceso = new HttpClient())
            {
                string urlApi = "http://localhost/SERVICE/api/Usuario/ValidarUsuario";
                JsonContent contenido = JsonContent.Create(objeto);

                HttpResponseMessage respuesta = acceso.PostAsync(urlApi, contenido).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<UsuarioObj>().Result;
                else
                    return null;
            }
        }


        public List<UsuarioObj>? GetUsuarios(string token)
        {
            using (HttpClient acceso = new HttpClient())
            {
                string urlApi = "http://localhost/SERVICE/" + "api/UsuarioApi/GetUsuarios";

                acceso.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = acceso.GetAsync(urlApi).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<UsuarioObj>>().Result;
                else
                    return null;
            }
        }

    }
}

