using Newtonsoft.Json;
using TiendaDeportiva.Entities;

namespace TiendaDeportiva.Models
{
    public class VentasModel
    {
        string urlPut = "https://localhost:7019/ActualizarRol?IdRol=11&Roles=Admin";
        string urlPost = "https://localhost:7019/Registrarrol?IdRol=10&Roles=admin2";
        string urlGet = "https://localhost:7019/GetVentas";
        string urlDElete = "https://localhost:7019/Delete?Rol=1";

        public string lblmsj { get; set; }
        List<VentasObj> v = new List<VentasObj>();
        public List<VentasObj> GetVentas()
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
                    v = JsonConvert.DeserializeObject<List<VentasObj>>(resultstr);
                }
                else
                {

                }
            }
            return v;
        }
    }
}
