using Domain.Client.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Client.Data.Model
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<ClientEntity> Cliente { get; set; }
        public DbSet<HomeEntity> Residencia { get; set; }
    }
}
