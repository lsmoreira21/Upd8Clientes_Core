using System.ComponentModel.DataAnnotations;
using static Upd8Clientes_Core.Enum.Enum;
using System.Text.Json.Serialization;

namespace Upd8Clientes_Core.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }


        public Sexo Sexo { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }

        [JsonIgnore]
        public Estado? Estado { get; set; }

        [JsonIgnore]
        public Cidade? Cidade { get; set; }
    }
}
