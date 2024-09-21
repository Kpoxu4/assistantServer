namespace assistantServer.Servise.Interface
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
        bool VerifyPassword( string password, string hashedPassword);
    }
}
