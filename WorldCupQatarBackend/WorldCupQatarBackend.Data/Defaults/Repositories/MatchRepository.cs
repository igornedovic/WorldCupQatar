using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Repositories;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data.Defaults.Repositories
{
    public class MatchRepository : BaseRepository<Match>, IMatchRepository
    {
        private readonly WorldCupDbContext _context;

        public MatchRepository(WorldCupDbContext context) : base(context)
        {
            _context = context;
        }
    }
}