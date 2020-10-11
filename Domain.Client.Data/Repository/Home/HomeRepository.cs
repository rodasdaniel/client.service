using Domain.Client.Entities;
using Infrastructure.Client.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Client.Data.Repository
{
    public class HomeRepository : IHomeRepository
    {
        #region Constructor
        private readonly ApplicationDBContext _context;
        public HomeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        #endregion 

        public async Task<HomeEntity> Create(HomeEntity homeEntity)
        {
            _context.Residencia.Add(homeEntity);
            await _context.SaveChangesAsync();
            return homeEntity;
        }

        public async Task<HomeEntity> GetByIdClient(long idClient)
        {
            return await Task.FromResult(_context.Residencia.Find(idClient));
        }
    }
}
