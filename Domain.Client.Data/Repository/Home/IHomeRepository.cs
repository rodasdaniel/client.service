using Domain.Client.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Client.Data.Repository
{
    public interface IHomeRepository
    {
        Task<HomeEntity> GetByIdClient(long idClient);
        Task<HomeEntity> Create(HomeEntity homeEntity);
    }
}
