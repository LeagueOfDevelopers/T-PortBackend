namespace TPort.Services
{
    public interface ITotpManager
    {
        int GenerateToken(string phoneNumber);

        bool ValidateToken(string phoneNumber, int token);
    }
}