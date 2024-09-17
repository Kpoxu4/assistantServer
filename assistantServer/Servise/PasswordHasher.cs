using assistantServer.data.model;
using assistantServer.Servise.Interface;

namespace assistantServer.Servise
{
    public class PasswordHasher : IPasswordHasher
    {                       
        private const int SALT_WORK_FACTOR = 10;
        public string GeneratePassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, SALT_WORK_FACTOR);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
