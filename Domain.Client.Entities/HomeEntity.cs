using System.ComponentModel.DataAnnotations;

namespace Domain.Client.Entities
{
    public class HomeEntity
    {
        [Key]
        public long IdCliente { get; set; }
        public int IdCiudad { get; set; }
        public string Direccion { get; set; }
    }
}
