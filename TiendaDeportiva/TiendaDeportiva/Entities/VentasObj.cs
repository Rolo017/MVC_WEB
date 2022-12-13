using Newtonsoft.Json;

namespace TiendaDeportiva.Entities
{
    public class VentasObj
    {
        public int IdVenta { get; set; }
        public int Cedula { get; set; }
        public int Producto { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
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
