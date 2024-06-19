using System.ComponentModel.DataAnnotations;

namespace Upd8Clientes_Core.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }

        [Required]
        [StringLength(50)]        
        public string Nome { get; set; }
    }
}
