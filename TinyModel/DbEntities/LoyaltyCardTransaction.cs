using System;

namespace TinyModel.Entities
{
    public class LoyaltyCardTransaction : BaseEntity
    {
        public string CardNumber { get; set; }
        public int ClientId { get; set; }
        public decimal LoyaltyPointsEarned { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Client Client { get; set; }
    }
}
