using AutoMapper;
using TinyModel;
using TinyModel.DTO;
using TinyModel.Entities;

namespace TinyApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<LoyaltyCard, LoyaltyCardDTO>();
            CreateMap<LoyaltyCardDTO, LoyaltyCard>();
            CreateMap<LoyaltyCardTransaction, LoyaltyCardTransactionDTO>();
            CreateMap<LoyaltyCardTransactionDTO, LoyaltyCardTransaction>();
        }
    }
}
