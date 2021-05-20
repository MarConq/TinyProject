using TinyData.Repositories.Contracts;
using TinyModel.Context;
using TinyModel.Entities;

namespace TinyData.Repositories.Implementations
{
    public class LoyaltyCardTransactionRepository : BaseRepository<LoyaltyCardTransaction>, ILoyaltyCardTransactionRepository
    {
        public LoyaltyCardTransactionRepository(LocalDbContext context) : base(context)
        {
        }
    }
}