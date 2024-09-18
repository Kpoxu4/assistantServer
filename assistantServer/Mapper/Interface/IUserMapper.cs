using assistantServer.data.model;
using assistantServer.Models;

namespace assistantServer.Mapper.Interface
{
    public interface IUserMapper
    {
        User DbUser(RegistrationViewModel model);
    }
}
