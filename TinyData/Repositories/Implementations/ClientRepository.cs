using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TinyData.Repositories.Contracts;
using TinyModel;
using TinyModel.Context;

namespace TinyData.Repositories.Implementations
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(LocalDbContext context) : base(context)
        {

        }

        public override IEnumerable<Client> GetAll()
        {
            return _context.Clients.Include(x => x.LoyaltyCards);
        }
    }
}
