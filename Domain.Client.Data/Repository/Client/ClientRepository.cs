using Domain.Client.Entities;
using Infrastructure.Client.Data.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Client.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        #region Constructor
        private readonly ApplicationDBContext _context;
        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        #endregion 

        public async Task<long> Create(ClientEntity clientEntity)
        {
            _context.Cliente.Add(clientEntity);
            await _context.SaveChangesAsync();
            return clientEntity.IdCliente;
        }

        public async Task<ClientEntity> GetById(int idType, string identification)
        {
            return await Task.FromResult(_context.Cliente.Where(c => c.IdTipoIdentifiacion == idType
            && c.Identificacion == identification).FirstOrDefault());
        }
    }
}
