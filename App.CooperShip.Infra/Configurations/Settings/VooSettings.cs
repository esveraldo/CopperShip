using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Configurations.Settings
{
    public class VooSettings
    {
        public const string SessionName = nameof(VooSettings);
        public Guid Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nota { get; set; }
        public int Capacidade { get; set; } = 4;
        public int Disponibilidade { get; set; } = 4;
    }
}
