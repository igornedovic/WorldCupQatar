using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Repositories;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data.Defaults.Repositories
{
    public class WorldCupRepository : BaseRepository<WorldCup>, IWorldCupRepository
    {
        private readonly WorldCupDbContext _context;

        public WorldCupRepository(WorldCupDbContext context) : base(context)
        {
            _context = context;
        }
    }
}