using System;
using System.ComponentModel.DataAnnotations;

namespace TinyModel.DTO
{
    public class LoyaltyCardTransactionDTO
    {
        public int Id { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public decimal LoyaltyPointsEarned { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
