using System.Collections.Generic;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryTotpTokenRepository : ITotpTokenRepository
    {
        public InMemoryTotpTokenRepository(Dictionary<string, int> totpTokens)
        {
            _totpTokens = totpTokens;
        }
        
        public void SaveToken(string phoneNumber, int token)
        {
            if (_totpTokens.ContainsKey(phoneNumber)) 
                _totpTokens.Remove(phoneNumber);
            
            _totpTokens.Add(phoneNumber, token);
        }

        public int GetToken(string phoneNumber)
        {
            return _totpTokens.GetValueOrDefault(phoneNumber);
        }

        private readonly Dictionary<string, int> _totpTokens;
    }
}