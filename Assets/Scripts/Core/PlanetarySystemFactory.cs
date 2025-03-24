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

            var stepDistance = 1f;
            var previousOffSet = 0f;
            var currentRadius = 0f;
            var additionalRadiusOffset = 0f;

            for (var i = 0; i < planetCount; i++)
            {
                var planetMass  = mass / planetCount * Random.Range(0.00001f, 1.2f);
                mass -= planetMass;
                var planetClass = MassClassHelper.GetPlanetClassByMass(planetMass);
                currentRadius = MassClassHelper.GetPlanetRadius(planetClass);
                var planetObject = Object.Instantiate(_planetObjectPrefab, _parent);
                var planetPosition = planetObject.transform.position;
                additionalRadiusOffset = Random.Range(1f, 5f);
                var planetNewPos = new Vector3(stepDistance + previousOffSet + currentRadius + additionalRadiusOffset, planetPosition.y, planetPosition.z);
                planetObject.transform.position = planetNewPos;
                planetObject.name = planetClass.ToString();
                planetObject.Mass = planetMass;
                planetObject.MassClass = planetClass;
                
                var planetScale = planetObject.transform.localScale;
                previousOffSet = planetObject.transform.position.x + currentRadius;
                planetObject.transform.localScale = planetScale * currentRadius;
                system.AddPlanet(planetObject);
            }

            return system;
        }
    }
}