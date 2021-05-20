using TinyModel;

namespace TinyData.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        public User GetUserByCredentials(string username, string password);
    }
}
