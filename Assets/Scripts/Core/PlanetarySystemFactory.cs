using ClassHelpers;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetarySystemFactory : IPlanetarySystemFactory
    {
        private readonly GameObject _planetObjectPrefab;
        private readonly Transform _parent;

        public PlanetarySystemFactory(GameObject planetObjectPrefab, Transform parent)
        {
            _planetObjectPrefab = planetObjectPrefab;
            _parent = parent;
        }
        
        public IPlanetarySystem Create(double mass)
        {
            var planetarySystem = new GameObject("Planetary System");
            var system  = planetarySystem.AddComponent<PlanetarySystem>();
            
            var planetCount = Random.Range(2, 6);

            for (var i = 0; i < planetCount; i++)
            {
                var planetMass  = mass / planetCount * Random.Range(0.8f, 1.2f);
                var planetClass = MassClassHelper.GetPlanetClassByMass(planetMass);
                var planetObject = Object.Instantiate(_planetObjectPrefab, _parent);
                planetObject.name = planetClass.ToString();
                var planet = planetObject.AddComponent<Planet>();
                planet.Mass = planetMass;
                planet.MassClass = planetClass;
                system.AddPlanet(planet);
            }

            return system;
        }
    }
}