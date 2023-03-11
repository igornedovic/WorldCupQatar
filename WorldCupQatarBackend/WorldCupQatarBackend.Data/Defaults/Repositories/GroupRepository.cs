using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Repositories;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data.Defaults.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        private readonly WorldCupDbContext _context;

        public GroupRepository(WorldCupDbContext context) : base(context)
        {
            _context = context;
        }
    }
}