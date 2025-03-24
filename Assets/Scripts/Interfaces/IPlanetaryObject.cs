using Enums;

namespace Interfaces
{
    public interface IPlanetaryObject
    {
        MassClassEnum MassClass { get; set; }
        double Mass { get; set; }
    }
}