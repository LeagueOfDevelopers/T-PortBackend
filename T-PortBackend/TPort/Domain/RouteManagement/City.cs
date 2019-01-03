using System;

namespace TPort.Domain.RouteManagement
{
    public class City
    {
        public City(int id, string name, string code)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        public int Id { get; }
        
        public string Name { get; }
        
        public string Code { get; }
    }
}