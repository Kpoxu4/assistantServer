using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using assistantServer.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace assistantServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthUserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public AuthUserController (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   

        [HttpPost("login")]
        public bool Login([FromBody] LoginViewModel user)
        {           
            var dbUser = new User
            {
                Name = user.Username,
                Password = user.Password
            };
            var result = _userRepository.IsLoginUser(dbUser);



            return result;
        }
    }
}

