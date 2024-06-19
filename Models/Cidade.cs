using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Upd8Clientes_Core.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        [JsonIgnore]
        public Estado? Estado { get; set; }
    }    
}
