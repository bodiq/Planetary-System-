using System.Collections.Generic;

namespace Interfaces
{
    public interface IPlanetarySystem
    {
        IEnumerable<IPlanetaryObject> PlanetaryObjects { get; }
        public void Update(float deltaTime);
        public void AddPlanet(IPlanetaryObject planet);
    }
}