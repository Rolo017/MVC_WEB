using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class RolesObj
    {


        [JsonProperty("IdRol")]
        public int IdRol { get; set; }

        [JsonProperty("Roles")]
        public String Roles { get; set; }


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
