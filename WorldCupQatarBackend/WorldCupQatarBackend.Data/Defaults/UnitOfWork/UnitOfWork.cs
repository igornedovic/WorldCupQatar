using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Defaults.Repositories;
using WorldCupQatarBackend.Data.Interfaces.Repositories;
using WorldCupQatarBackend.Data.Interfaces.UnitOfWork;

namespace WorldCupQatarBackend.Data.Defaults.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorldCupDbContext _context;

        public UnitOfWork(WorldCupDbContext context)
        {
            _context = context;
            TeamRepository = new TeamRepository(_context);
            WorldCupRepository = new WorldCupRepository(_context);
        }
        public ITeamRepository TeamRepository { get; set; }
        public IWorldCupRepository WorldCupRepository { get; set; }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
