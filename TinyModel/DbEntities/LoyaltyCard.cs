using System;

namespace TinyModel.Entities
{
    public class LoyaltyCard : BaseEntity
    {
        public string Number { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ValidUntil { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
