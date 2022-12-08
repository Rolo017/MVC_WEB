using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class ProductosObj
    {


        [JsonProperty("IdProducto")]
        public int IdProducto { get; set; } = 0;
        [JsonProperty("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; } = string.Empty;
        [JsonProperty("Precio")]
        public float Precio { get; set; } = float.MinValue;
        [JsonProperty("Cantidad")]
        public int Cantidad { get; set; } = 0;

        public string toJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
        //**********************************************************************
        public override string ToString()
        {
            return toJsonString();
        }


    }
}
