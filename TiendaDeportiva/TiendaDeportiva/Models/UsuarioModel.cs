﻿using Newtonsoft.Json;
using System.Net.Http.Headers;
using TiendaDeportiva.Entities;

namespace TiendaDeportiva.Models
{
    public class UsuarioModel
    {
        string urlPut = "https://localhost:7019/ActualizarRol?IdRol=11&Roles=Admin";
        string urlPost = "https://localhost:7019/Registrarrol?IdRol=10&Roles=admin2";
        string urlGet = "https://localhost:7019/api/Usuario/GetUsuarios";
        string urlDElete = "https://localhost:7019/Delete?Rol=1";

        public string lblmsj { get; set; }
        List<UsuarioObj> u = new List<UsuarioObj>();

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

        public List<UsuarioObj> GetUsuarios()
        {
            //IEnumerable<Carrera> A;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    return await client.GetAsync(urlGet);
                }
                );
                HttpResponseMessage message = task.Result;
                if (message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    });
                    string resultstr = task2.Result;
                    u = JsonConvert.DeserializeObject<List<UsuarioObj>>(resultstr);
                }
                else
                {

                }
            }
            return u;
        }

    }
}

