using System.Linq;
using TinyData.Repositories.Contracts;
using TinyModel.Context;
using TinyModel.Entities;

namespace TinyData.Repositories.Implementations
{
    public class LoyaltyCardRepository : BaseRepository<LoyaltyCard>, ILoyaltyCardRepository
    {
        public LoyaltyCardRepository(LocalDbContext context) : base(context)
        {

        }

        public LoyaltyCard GetByCardNumber(string cardNumber)
        {
            return dbSet.FirstOrDefault(x => x.Number == cardNumber);
        }
    }
}
