using System.ComponentModel.DataAnnotations;

namespace Domain.Client.Entities
{
    public class ClientEntity
    {
        [Key]
        public long IdCliente { get; set; }
        public int IdTipoIdentifiacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public decimal CupoTotal { get; set; }
        public decimal CupoDisponible { get; set; }
    }
}
