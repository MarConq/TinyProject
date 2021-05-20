using TinyModel.Entities;

namespace TinyData.Repositories.Contracts
{
    public interface ILoyaltyCardRepository : IRepository<LoyaltyCard>
    {
        LoyaltyCard GetByCardNumber(string cardNumber);
    }
}
