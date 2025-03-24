using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
    {
        private readonly List<IPlanetaryObject> _planetaryObjects = new ();
        public IEnumerable<IPlanetaryObject> PlanetaryObjects => _planetaryObjects;
        
        public void UpdatePlanets(float deltaTime)
        {
            foreach (var planet in PlanetaryObjects)
            {
                planet.Simulate(deltaTime);
            }
        }

        public void AddPlanet(IPlanetaryObject planet)
        {
            _planetaryObjects.Add(planet);
        }
    }
}