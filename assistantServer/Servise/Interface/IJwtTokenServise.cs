using assistantServer.data.model;

namespace assistantServer.Servise.Interface
{
    public interface IJwtTokenServise
    {
        string GenerateJwtToken(User userFromDb);
        bool CheckTimeToken(string token);
    }
}
