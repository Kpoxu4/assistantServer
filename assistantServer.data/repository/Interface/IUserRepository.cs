using assistantServer.data.model;

namespace assistantServer.data.repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {               
        User GetUser(string name);
        void AddTokenForUser(User user, string token);
        bool CheckUserName(string userName);

    }
}
