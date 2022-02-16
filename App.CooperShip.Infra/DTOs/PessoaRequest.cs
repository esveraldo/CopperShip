using System.ComponentModel.DataAnnotations;

namespace App.CooperShip.Infra
{
    public class PessoaRequest
    {
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [MaxLength(50, ErrorMessage = "O campo {1} é requerido.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public Guid VooId { get; set; }
    }
}
