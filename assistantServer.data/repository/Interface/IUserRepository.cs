using assistantServer.data.model;

namespace assistantServer.data.repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistName(string login);
        bool ExistPhone(string phone);
        bool IsLoginUser(User user);
       
    }
}
