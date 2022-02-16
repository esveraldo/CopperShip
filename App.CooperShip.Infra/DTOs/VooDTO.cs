using App.CooperShip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.DTOs
{
    public class VooDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string? Codigo { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string? Nota { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int Capacidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int Disponibilidade { get; set; }

        //EF
        //public ICollection<Pessoa>? Pessoas { get; set; }
    }
}
