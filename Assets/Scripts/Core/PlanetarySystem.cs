using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
    {
        private readonly List<IPlanetaryObject> _planetaryObjects = new ();
        public IEnumerable<IPlanetaryObject> PlanetaryObjects => _planetaryObjects;
        
        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void AddPlanet(IPlanetaryObject planet)
        {
            _planetaryObjects.Add(planet);
        }
    }
}