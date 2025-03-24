using Enums;
using ScriptableObjects;
using UnityEngine;

namespace Interfaces
{
    public interface IPlanetaryObject
    {
        MassClassEnum MassClass { get; set; }
        double Mass { get; set; }
        
        public void Initialize(double mass, GameObject planetaryObject, PlanetSystemSettings planetSystemSettings, Vector3 centerPoint);
        public void Simulate(float deltaTime);
    }
}