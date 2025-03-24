using ClassHelpers;
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
        
        public IPlanetarySystem Create(double mass)
        {
            var planetarySystem = new GameObject("Planetary System");
            var system  = planetarySystem.AddComponent<PlanetarySystem>();
            
            var previousOffSet = 0f;
            var center = Vector3.zero;

            for (var i = 0; i < _planetSystemSettings.PlanetsCount; i++)
            {
                var planetMass  = mass / _planetSystemSettings.PlanetsCount * Random.Range(0.00001f, 1.2f);
                mass -= planetMass;
                
                var planetObject = Object.Instantiate(_planetObjectPrefab, _parent);

                planetObject.Initialize(planetMass, previousOffSet, _planetSystemSettings, center);
                
                previousOffSet = planetObject.transform.position.x;
                
                system.AddPlanet(planetObject);
            }

            return system;
        }
    }
}