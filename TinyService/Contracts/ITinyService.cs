using System.Collections.Generic;
using TinyModel.DTO;

namespace TinyService.Contracts
{
    public interface ITinyService
    {
        string Authenticate(string username, string password);
        ClientDTO CreateClient(ClientDTO client);
        LoyaltyCardDTO IssueCard(int clientId);
        LoyaltyCardTransactionDTO CreateTransaction(int clientId, string cardNumber, decimal pointsEarned);
        List<ClientDTO> GetClients();
        List<LoyaltyCardDTO> GetCards();
        decimal GetBalance(int clientId);
    }
}
