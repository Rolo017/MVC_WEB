namespace JN_API.Entities
{
    public class UsuarioObj
    {

        public string Usuario { get; set; } = string.Empty;
        public string Contrasenna { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public bool CambioContrasenna { get; set; } = false;
        public int TipoUsuario { get; set; } = 0;

    }
}
