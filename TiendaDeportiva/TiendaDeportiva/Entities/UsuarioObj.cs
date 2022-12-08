using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class UsuarioObj
    {
        public int Cedula { get; set; } = 0;

        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Contraseña { get; set; } = string.Empty;

        public bool Activo { get; set; } = false;

        public int IdRol { get; set; } = 0;

        public string Token { get; set; } = string.Empty;



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
