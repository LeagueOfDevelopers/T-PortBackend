namespace TPort.Infrastructure.DataAccess
{
    public interface ITotpTokenRepository
    {
        void SaveToken(string phoneNumber, int token);
        
        int GetToken(string phoneNumber);
    }
}