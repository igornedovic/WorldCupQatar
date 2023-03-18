using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Repositories;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data.Defaults.Repositories
{
    public class StadiumRepository : BaseRepository<Stadium>, IStadiumRepository
    {
        private readonly WorldCupDbContext _context;

        public StadiumRepository(WorldCupDbContext context) : base(context)
        {
            _context = context;
        }
    }
}