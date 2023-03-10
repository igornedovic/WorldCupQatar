using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Repositories;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data.Defaults.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        private readonly WorldCupDbContext _context;

        public TeamRepository(WorldCupDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
