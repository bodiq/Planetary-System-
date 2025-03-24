using ClassHelpers;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetarySystemFactory : IPlanetarySystemFactory
    {
        private readonly Planet _planetObjectPrefab;
        private readonly Transform _parent;

        public PlanetarySystemFactory(Planet planetObjectPrefab, Transform parent)
        {
            _planetObjectPrefab = planetObjectPrefab;
            _parent = parent;
        }
        
        public IPlanetarySystem Create(double mass)
        {
            var planetarySystem = new GameObject("Planetary System");
            var system  = planetarySystem.AddComponent<PlanetarySystem>();
            
            var planetCount = Random.Range(3, 8);

            var previousOffSet = 0f;

            for (var i = 0; i < planetCount; i++)
            {
                var planetMass  = mass / planetCount * Random.Range(0.00001f, 1.2f);
                mass -= planetMass;
                
                var planetObject = Object.Instantiate(_planetObjectPrefab, _parent);

                planetObject.Initialize(planetMass, previousOffSet);
                
                previousOffSet = planetObject.transform.position.x;
                
                system.AddPlanet(planetObject);
            }

            return system;
        }
    }
}