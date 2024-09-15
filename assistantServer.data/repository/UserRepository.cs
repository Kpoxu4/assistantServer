using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace assistantServer.data.repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AssistantDbContext dbContext) : base(dbContext) { }

        public bool ExistName(string login)
             => _dbSet.Any(x => x.Name == login);
        public bool ExistPhone(string phone)
             => _dbSet.Any(x => x.Phone == phone);
        public bool IsLoginUser(User user) =>
            _dbSet.Any(x => x.Name == user.Name) && _dbSet.Any(x => x.Password == user.Password);
        
    }
}
