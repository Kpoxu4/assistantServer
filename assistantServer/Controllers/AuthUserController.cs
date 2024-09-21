using assistantServer.data.model;
using assistantServer.data.repository.Interface;
using assistantServer.Mapper.Interface;
using assistantServer.Models;
using assistantServer.Servise.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace assistantServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthUserController : ControllerBase
    {
        public const string AUTH_METHOD = "Assistant";
        private readonly IUserRepository  _userRepository;       
        private readonly IJwtTokenServise _jwtTokenServise;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserMapper _userMapper;

        public AuthUserController(IUserRepository userRepository,                                   
                                  IJwtTokenServise jwtTokenServise,
                                  IPasswordHasher passwordHasher,
                                  IUserMapper userMapper)
        {
            _userRepository = userRepository;            
            _jwtTokenServise = jwtTokenServise;
            _passwordHasher = passwordHasher;
            _userMapper = userMapper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            if (user.Username == null || user.Password == null)
            {

                return BadRequest(new { error = "Поля должны быть заполнены" });
            }
            var userDb = _userRepository.GetUser(user.Username);

            if (userDb == null)
            {
                return Unauthorized(new { error = "Такого имени не существует." });

            }
            var isLogin = _passwordHasher.VerifyPassword(user.Password, userDb.Password);

            if (!isLogin)
            {
                return Unauthorized(new { error = "Пароль не верный." });
            }
                                               
            var tokenString = _jwtTokenServise.GenerateJwtToken(userDb);
            _userRepository.AddTokenForUser(userDb, tokenString);   

            return Ok(new { token = tokenString });
        }

        [HttpPost("registration")]
        public IActionResult Registration([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "Неверные данные. Пожалуйста, проверьте введенные значения." });
            }

            if (_userRepository.CheckUserName(model.UserName))
            {
                return BadRequest(new { error = "Надо придумать другое имя" });
            }

            model.Password = _passwordHasher.GeneratePassword(model.Password);            

            var dbUser = _userMapper.DbUser(model);      
            _userRepository.Create(dbUser);            

            return Ok();
        }        
    }
}


