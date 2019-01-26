using System;

namespace TPort.Domain.UserManagement
{
    public class BankCard
    {
        public BankCard(string cardNumber, DateTime validity)
        {
            CardNumber = cardNumber;
            Validity = validity;
        }

        public string CardNumber { get; }
        
        public DateTime Validity { get; }
    }
}