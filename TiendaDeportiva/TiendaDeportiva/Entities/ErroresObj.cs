using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class ErroresObj
    {
        [JsonProperty("IdError")]
        public int IdError { get; set; }
        [JsonProperty("Cedula")]
        public int Cedula { get; set; }
        [JsonProperty("Error")]
        public string? Error { get; set; }

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
