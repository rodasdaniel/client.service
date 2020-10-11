using Domain.Client.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Client.Data.Repository
{
    public interface IClientRepository
    {
        Task<ClientEntity> GetById(int idType, string identification);
        Task<long> Create(ClientEntity clientEntity);
        Task<ClientEntity> GetById(long idClient);
    }
}
