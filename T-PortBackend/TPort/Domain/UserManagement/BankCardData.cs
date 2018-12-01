namespace TPort.Domain.UserManagement
{
    public class BankCardData
    {
        public BankCardData(long cardNumber, int cvc)
        {
            CardNumber = cardNumber;
            Cvc = cvc;
        }

        public long CardNumber { get; }
        
        public int Cvc { get; }
    }
}