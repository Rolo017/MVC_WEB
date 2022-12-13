using Newtonsoft.Json;
using TiendaDeportiva.Entities;

namespace TiendaDeportiva.Models
{
    public class VentasModel
    {
        string urlPut = "https://localhost:7019/ActualizarRol?IdRol=11&Roles=Admin";
        string urlPost = "https://localhost:7019/Registrarrol?IdRol=10&Roles=admin2";
        string urlGet = "https://localhost:7019/api/Ventas/GetVentas";
        string urlGetProc = "https://localhost:7019/api/Productos/GetProducto";
        string urlDElete = "https://localhost:7019/Delete?Rol=1";

        public string lblmsj { get; set; }
        List<VentasObj> ventO = new List<VentasObj>();
        VentasObj ventE = new VentasObj();

        ProductosObj produc = new ProductosObj();

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
                    ventO = JsonConvert.DeserializeObject<List<VentasObj>>(resultstr);
                }
                else
                {

                }
            }
            return ventO;
        }

        public VentasObj GetVentas(int id)
        {
            //IEnumerable<Carrera> A;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    return await client.GetAsync(urlGet + "/" + id.ToString());
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
                    ventE = JsonConvert.DeserializeObject<VentasObj>(resultstr);
                }
                else
                {

                }
            }
            return ventE;
        }

        public ProductosObj GetProductos(int id)
        {
            //IEnumerable<Carrera> A;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    return await client.GetAsync(urlGetProc + "/" + id.ToString());
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
                    produc = JsonConvert.DeserializeObject<ProductosObj>(resultstr);
                }
                else
                {

                }
            }
            return produc;
        }

        public string PostVentas(VentasObj ven)
        {
            using (HttpClient acceso = new HttpClient())
            {
                //string urlApi = "http://localhost/SERVICE/" + "api/UsuarioApi/CreateUsuario";
                string urlApi = "https://localhost:7019/" + "api/Ventas/RegistrarVenta";

                JsonContent contenido = JsonContent.Create(ven);
                HttpResponseMessage respuesta = acceso.PostAsync(urlApi, contenido).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;
            }
        }

        public string PutVentas(VentasObj ven)
        {
            using (HttpClient acceso = new HttpClient())
            {


                //string urlApi = "http://localhost/SERVICE/" + "api/UsuarioApi/CreateUsuario";
                string urlApi = "https://localhost:7019/" + "api/Ventas/ActualizarVentas";

                JsonContent contenido = JsonContent.Create(ven);
                HttpResponseMessage respuesta = acceso.PutAsync(urlApi, contenido).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;
            }
        }

        public void EliminarVentas(int id)
        {
            //validacion de datos para eliminar los datos
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7019/");
                    var response = client.DeleteAsync("api/Ventas/DeleteVentas?IdVenta=" + id);
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
    }
}