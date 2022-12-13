using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class RolesObj
    {
        public int IdRol { get; set; } = 0;
        public String Roles { get; set; } = string.Empty;

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
