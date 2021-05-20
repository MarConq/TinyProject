using System.ComponentModel.DataAnnotations;

namespace TinyModel.DTO
{
    public class ClientDTO
    {
        public ClientDTO()
        {
            Gender = Gender.OTHER;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }
}
