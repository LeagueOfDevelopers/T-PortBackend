namespace TPort.Domain.RouteManagement
{
    public class Coordinates
    {
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        
        public double Longitude { get; }
    }
}