using Newtonsoft.Json;
using NuGet.Common;
using System;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using TiendaDeportiva.Controllers;
using TiendaDeportiva.Entities;

namespace TiendaDeportiva.Models
{
    public class RolesModel
    {
        string urlPut = "https://localhost:7019/ActualizarRol?IdRol=11&Roles=Admin";
        string urlPost = "https://localhost:7019/";
        string urlGet = "https://localhost:7019/GetRol";
        string urlDElete = "https://localhost:7019/Delete?Rol=1";
        public string lblmsj { get; set; }
        List<RolesObj> c = new List<RolesObj>();
        //*************************************
        #region GETCursos
        public List<RolesObj> GetRoles()
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
                    c = JsonConvert.DeserializeObject<List<RolesObj>>(resultstr);
                }
                else
                {

                }
            }
            return c;
        }
        #region PostCursos
        public string PostRoles(RolesObj c)
        {
            ////string pd = "api/Carreras/1?nombre=admin4";
            //string json = c.toJsonString();
            //using (var client = new System.Net.Http.HttpClient())
            //{
            //    var httpContent = new StringContent(urlPost, Encoding.UTF8, "application/json");

            //    client.BaseAddress = new Uri("https://localhost:7019/"); //Preguntar
            //    var putTask = client.PutAsync("Registrarrol?IdRol=" + c.IdRol + "&Roles=" + c.Roles, httpContent);
            //    putTask.Wait();
            //    var result = putTask.Result;
            //}
            using (HttpClient acceso = new HttpClient())
            {
                //string urlApi = "http://localhost/SERVICE/" + "api/UsuarioApi/CreateUsuario";
                string urlApi = "https://localhost:7019/" + "Registrarrol";
                JsonContent contenido = JsonContent.Create(c);

                HttpResponseMessage respuesta = acceso.PostAsync(urlApi, contenido).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;
            }
        }
        #endregion
        //**************************************
        #region DeleteRoles
        public void EliminarRoles(int id)
        {
            //validacion de datos para eliminar los datos
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7019/");
                    var response = client.DeleteAsync("Delete?Rol=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        lblmsj = "Se ha eliminado exitosamente.";
                    }
                    else
                    {
                        lblmsj = "No se encontro la identificacion para eliminar el curso.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsj = "Error en el registro de la carrera\n" + ex.StackTrace;
            }
        }
        #endregion
        //**


        //**************************************
        #region PUTRoles
        public void PUTRoles(RolesObj c)
        {
            //string pd = "api/Carreras/1?nombre=admin4";
            string json = c.toJsonString();
            using (var client = new System.Net.Http.HttpClient())
            {
                var httpContent = new StringContent(urlPut, Encoding.UTF8, "application/json");

                client.BaseAddress = new Uri("https://localhost:7019/");
                var putTask = client.PutAsync("ActualizarRol?IdRol" + c.Roles + "&Roles=" + c.IdRol + "&IdRol=", httpContent);
                putTask.Wait();
                var result = putTask.Result;
            }
        }
        #endregion
        //**************************************

    }
}
#endregion
//**************************************