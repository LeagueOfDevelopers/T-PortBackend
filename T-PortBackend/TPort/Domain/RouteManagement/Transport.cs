using System;

namespace TPort.Domain.RouteManagement
{
    public class Transport
    {
        public Transport(string name, TransportationType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        public string Name { get; }
        
        public TransportationType Type { get; }
    }
}