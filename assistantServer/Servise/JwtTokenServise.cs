using assistantServer.data.model;
using assistantServer.Servise.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace assistantServer.Servise
{
    public class JwtTokenServise : IJwtTokenServise
    {
        private const int TOKINE_ACTION = 24;
        public string GenerateJwtToken(User userFromDb)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_strong_secret_key_which_is_long_enough");//убрать в локальную переменую
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                    new Claim("id", userFromDb.Id.ToString()),
                    new Claim("name", userFromDb.Name),
                    new Claim("phone", userFromDb.Phone)
                    }),
                Expires = DateTime.UtcNow.AddHours(TOKINE_ACTION),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);       
                      
            return tokenHandler.WriteToken(token);
        }
        public bool CheckTimeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(token);

            if (!decodedToken.Payload.TryGetValue("exp", out var exp))
            {
                return false;
            }

            var expirationTime = DateTimeOffset.FromUnixTimeSeconds((long)exp).UtcDateTime;           
            return expirationTime > DateTime.UtcNow;            
        }
    }
}
