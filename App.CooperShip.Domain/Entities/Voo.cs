using App.CooperShip.Domain.Base;

namespace App.CooperShip.Domain.Entities
{
    public class Voo : EntityBase
    {
        //EF
        public Voo()
        {
            Pessoas = new List<Pessoa>();
        }
        public string? Codigo { get; set; }
        public string? Nota { get; set; }
        public int Capacidade { get; set; } = 0;
        public int Disponibilidade { get; set; }

        //EF
        public ICollection<Pessoa>? Pessoas { get; set; }

        public void DecrementaDisponibilidade()
        {
            Disponibilidade -= 1;
        }

        public bool TemDisponibilidade()
        {
            return Disponibilidade > 0;
       }

    }
}
