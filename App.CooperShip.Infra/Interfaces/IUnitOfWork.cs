using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Roolback(); 
    }
}
