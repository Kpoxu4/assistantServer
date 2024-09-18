using assistantServer.data.model;
using assistantServer.Mapper.Interface;
using assistantServer.Models;
using System.Numerics;

namespace assistantServer.Mapper
{
    public class UserMapper : IUserMapper
    {
        public User DbUser(RegistrationViewModel model)
        {
            User user = new User 
            {
                Name = model.UserName,
                Password = model.Password,
                Phone = model.PhoneNumber
            };
            return user;
        }
    }
}
