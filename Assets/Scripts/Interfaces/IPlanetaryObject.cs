using Enums;

namespace Interfaces
{
    public interface IPlanetaryObject
    {
        MassClassEnum MassClass { get; set; }
        double Mass { get; set; }
        
        public void Initialize(double mass, float previousPlanetXPos);
        public void Simulate(float deltaTime);
    }
}