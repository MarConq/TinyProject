namespace TinyModel
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        ADMIN = 1,
        CARD_ISSUER = 2,
        CARD_OWNER = 3,
        GUEST = 4,
    }
}
