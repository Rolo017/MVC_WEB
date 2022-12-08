using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class VentasObj
    {
        [JsonProperty("ID_venta")]
        public int ID_Venta { get; set; }
        [JsonProperty("Cedula")]
        public int Cedula { get; set; }
        [JsonProperty("Producto")]
        public int Producto { get; set; }
        [JsonProperty("Precio")]
        public float Precio { get; set; }
        [JsonProperty("Cantidad")]
        public int Cantidad { get; set; }
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

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
