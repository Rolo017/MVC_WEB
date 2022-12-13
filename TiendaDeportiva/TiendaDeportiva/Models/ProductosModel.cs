using Newtonsoft.Json;
using TiendaDeportiva.Entities;

namespace TiendaDeportiva.Models
{
    public class ProductosModel
    {
        string urlPut = "https://localhost:7019/ActualizarRol?IdRol=11&Roles=Admin";
        string urlPost = "https://localhost:7019/Registrarrol?IdRol=10&Roles=admin2";
        string urlGet = "https://localhost:7019/api/Productos/GetProducto";
        string urlDElete = "https://localhost:7019/Delete?Rol=1";

        public string lblmsj { get; set; }
        List<ProductosObj> p = new List<ProductosObj>();
        ProductosObj produc = new ProductosObj();

        //llamo para poder mostrar la lista de los productos en la vista
        public List<ProductosObj> GetProductos()
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
                    p = JsonConvert.DeserializeObject<List<ProductosObj>>(resultstr);
                }
                else
                {

                }
            }
            return p;
        }
        //llamo para llenar la pagina de Edit productos
        public ProductosObj GetProductos(int id)
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
                    produc = JsonConvert.DeserializeObject<ProductosObj>(resultstr);
                }
                else
                {

                }
            }
            return produc;
        }
        #region PostCursos
        public string PostProductos(ProductosObj Prod)
        {
            using (HttpClient acceso = new HttpClient())
            {

                //string urlApi = "http://localhost/SERVICE/" + "api/UsuarioApi/CreateUsuario";
                string urlApi = "https://localhost:7019/" + "api/Productos/RegistrarProducto";

                JsonContent contenido = JsonContent.Create(Prod);
                HttpResponseMessage respuesta = acceso.PostAsync(urlApi, contenido).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;

            }
        }
        #endregion
        #region PUTRoles
        public string PUTProductos(ProductosObj Prod)
        {
            using (HttpClient acceso = new HttpClient())
            {


                //string urlApi = "http://localhost/SERVICE/" + "api/UsuarioApi/CreateUsuario";
                string urlApi = "https://localhost:7019/" + "api/Productos/ActualizarProductos";

                JsonContent contenido = JsonContent.Create(Prod);
                HttpResponseMessage respuesta = acceso.PutAsync(urlApi, contenido).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;
            }
        }
        #region DeleteRoles
        public void EliminarProductos(int id)
        {
            //validacion de datos para eliminar los datos
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7019/");
                    var response = client.DeleteAsync("api/Productos/EliminarProductos?IdProducto=" + id);
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
    }
    #endregion
}

