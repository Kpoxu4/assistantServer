using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace assistantServer.data.repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AssistantDbContext dbContext) : base(dbContext) { }     

        public User GetUser(string name)
        {
            return _dbSet.First(x => x.Name == name);
        }

        public void AddTokenForUser(User user, string token)
        {
            var userDb = GetUser(user.Name);
            userDb.Token = token;
            _dbContext.SaveChanges();
        }

        public bool CheckUserName(string userName)
        {
            return _dbSet.Any(x => x.Name == userName);
        }
    }
}
