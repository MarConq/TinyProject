using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyApi.Helpers;
using TinyData.Repositories;
using TinyData.Repositories.Contracts;
using TinyModel;
using TinyModel.DTO;
using TinyModel.Entities;
using TinyService.Contracts;
using TinyService.Helpers;

namespace TinyService.Implementations
{
    public class TinyService : ITinyService
    {
        private IMapper _mapper;
        private IUserRepository _userRepository;
        private IClientRepository _clientRepository;
        private ILoyaltyCardRepository _loyaltyCardRepository;
        private ILoyaltyCardTransactionRepository _loyaltyCardTransactionRepository;
        public TinyService(IMapper mapper, IUserRepository userRepository, IClientRepository clientRepository,
            ILoyaltyCardRepository loyaltyCardRepository, ILoyaltyCardTransactionRepository loyaltyCardTransactionRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _loyaltyCardRepository = loyaltyCardRepository;
            _loyaltyCardTransactionRepository = loyaltyCardTransactionRepository;
        }
        public string Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByCredentials(username, PasswordHelper.HashPassword(password));

            if (user == null) throw new Exception("Wrong credentials");

            return JwtHelper.Encode(JwtHelper.ContextFromUser(user));
        }

        public ClientDTO CreateClient(ClientDTO client)
        {
            try
            {
                client.Id = 0;
                var mappedModel = _mapper.Map<Client>(client);
                var addedClient = _clientRepository.Insert(mappedModel);
                return _mapper.Map<ClientDTO>(addedClient);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public LoyaltyCardTransactionDTO CreateTransaction(int clientId, string cardNumber, decimal pointsEarned)
        {
            var client = _clientRepository.GetById(clientId);

            if (client == null) throw new Exception($"Client with id #{clientId} not found");

            var card = _loyaltyCardRepository.GetByCardNumber(cardNumber);

            if (card == null) throw new Exception($"Loyalty card with No #{cardNumber} not found");

            LoyaltyCardTransaction dbTransaction = new LoyaltyCardTransaction
            {
                ClientId = client.Id,
                CardNumber = card.Number,
                CreatedAt = DateTime.UtcNow,
                LoyaltyPointsEarned = pointsEarned
            };

            try
            {
                return _mapper.Map<LoyaltyCardTransactionDTO>(_loyaltyCardTransactionRepository.Insert(dbTransaction));
            }
            catch (Exception)
            {
                return null;
            }

        }

        public decimal GetBalance(int clientId)
        {
            return _loyaltyCardTransactionRepository.Find(x => x.ClientId == clientId).Sum(x => x.LoyaltyPointsEarned);
        }

        public List<LoyaltyCardDTO> GetCards()
        {
            return _mapper.Map<List<LoyaltyCardDTO>>(_loyaltyCardRepository.GetAll());
        }

        public List<ClientDTO> GetClients()
        {
            return _mapper.Map<List<ClientDTO>>(_clientRepository.GetAll());
        }

        public LoyaltyCardDTO IssueCard(int clientId)
        {
            var client = _clientRepository.GetById(clientId);

            if (client == null) throw new Exception($"Client with id #{clientId} not found");

            LoyaltyCard card = new LoyaltyCard
            {
                ClientId = client.Id,
                IssuedAt = DateTime.UtcNow,
                ValidUntil = DateTime.UtcNow.AddMonths(Constants.LOYALTY_CARD_VALID_MONTHS),
                Number = Guid.NewGuid().ToString()
            };

            try
            {
                return _mapper.Map<LoyaltyCardDTO>(_loyaltyCardRepository.Insert(card));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
