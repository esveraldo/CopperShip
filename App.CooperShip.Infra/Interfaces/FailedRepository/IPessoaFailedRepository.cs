using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Intefaces.FailedRepository
{
    public interface IPessoaFailedRepository : IBaseRepository<Pessoa>
    {
        Task AdicionarAoVoo(PessoaDTO pessoaDTO);
    }
}
