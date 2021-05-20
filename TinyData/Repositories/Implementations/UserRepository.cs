using System.Linq;
using TinyModel;
using TinyModel.Context;

namespace TinyData.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(LocalDbContext context): base(context)
        {

        }

        public User GetUserByCredentials(string username, string password)
        {
            return dbSet.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        }
    }
}
