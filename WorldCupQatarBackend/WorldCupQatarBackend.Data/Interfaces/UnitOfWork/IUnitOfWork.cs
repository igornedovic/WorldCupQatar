using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Repositories;

namespace WorldCupQatarBackend.Data.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IWorldCupRepository WorldCupRepository { get; set; }
        public IGroupRepository GroupRepository { get; set; }
        public ITeamRepository TeamRepository { get; set; }
        public Task<bool> CommitAsync();
    }
}
