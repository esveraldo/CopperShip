using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.DTOs;
using App.CooperShip.Infra.Interfaces;
using System.Linq.Expressions;

namespace App.CooperShip.Infra.Services.Interfaces
{
    public interface IVooService
    {
        Task UpdateVoo(VooDTO vooDTO);
        Task<Voo> SelecionarPorId(Guid id);
        Task CriarVoo(VooDTO vooDTO);
    }
}
