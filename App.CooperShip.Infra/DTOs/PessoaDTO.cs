using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.CooperShip.Infra
{
    public class PessoaDTO
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [MaxLength(50, ErrorMessage = "O campo {1} é requerido.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [ForeignKey("VooId")]
        public Guid VooId { get; set; }
    }
}
