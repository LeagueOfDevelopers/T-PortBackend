namespace TPort.Services
{
    public interface ISmsManager
    {
        void SendMessage(string phoneNumber, string message);
    }
}