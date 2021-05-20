using System;
using System.Collections.Generic;
using TinyModel.Entities;

namespace TinyModel
{
    public class Client: BaseEntity
    {
        public Client()
        {
            RegistrationDate = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual List<LoyaltyCard> LoyaltyCards { get; set; }
        public virtual List<LoyaltyCardTransaction> LoyaltyCardTransactions { get; set; }
    }

    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER
    }
}
