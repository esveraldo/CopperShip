using App.CooperShip.Domain.Base;
using System.Text.Json.Serialization;

namespace App.CooperShip.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public string? Nome { get; set; }
        public Guid VooId { get; set; }
        [JsonIgnore]
        public Voo? Voo { get; set; }
    }
}