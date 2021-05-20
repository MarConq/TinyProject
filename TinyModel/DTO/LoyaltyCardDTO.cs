using System;

namespace TinyModel.DTO
{
    public class LoyaltyCardDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ValidUntil { get; set; }
        public int ClientId { get; set; }
    }
}
