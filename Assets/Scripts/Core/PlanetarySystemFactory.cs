using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class PlanetarySystemFactory : IPlanetarySystemFactory
    {
        private readonly Planet _planetObjectPrefab;
        private readonly Transform _parent;
        private readonly PlanetSystemSettings _planetSystemSettings;
        
        public PlanetarySystemFactory(Planet planetObjectPrefab, Transform parent, PlanetSystemSettings planetSystemSettings)
        {
            _planetObjectPrefab = planetObjectPrefab;
            _parent = parent;
            _planetSystemSettings = planetSystemSettings;
        }
        
        public IPlanetarySystem Create(double totalMass)
        {
            var planetarySystem = new GameObject("Planetary System");
            var system  = planetarySystem.AddComponent<PlanetarySystem>();

            GameObject previousPlanet = null;
            var center = Vector3.zero;
            var remainingMass = totalMass;
            var random = new System.Random();
            var count = 0;
            
            while (remainingMass > 0 && count < _planetSystemSettings.PlanetsCount)
            {
                var mass = GeneratePlanetMass(random, remainingMass);
                remainingMass -= mass;
                
                var planetObject = Object.Instantiate(_planetObjectPrefab, _parent);

                planetObject.Initialize(mass, previousPlanet, _planetSystemSettings, center);
                
                previousPlanet = planetObject.gameObject;
                
                system.AddPlanet(planetObject);
                count++;
            }

            return system;
        }
        
        private double GeneratePlanetMass(System.Random random, double remainingMass)
        {
            return random.NextDouble() * remainingMass;
        }
    }
}