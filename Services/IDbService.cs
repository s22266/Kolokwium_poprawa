using System.Collections.Generic;
using System.Threading.Tasks;
using Kolokwium_poprawa.Models.DTO;

namespace Kolokwium_poprawa.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfTeam>> GetTeam(int idTeam);
    }

}
