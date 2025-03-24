using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class PlanetarySimulationHandler : MonoBehaviour
    {
        [SerializeField] private Planet planetPrefab;
        [SerializeField] private PlanetSystemSettings planetSystemSettings;
    
        private IPlanetarySystem _planetSystemFactory;
    
        private void Start()
        {
            planetSystemSettings.InitializeVisualData();
            
            var factory = new PlanetarySystemFactory(planetPrefab, transform, planetSystemSettings);
            _planetSystemFactory = factory.Create(planetSystemSettings.MainPlanetarySystemMass);
        }

        private void Update()
        {
            _planetSystemFactory?.UpdatePlanets(Time.deltaTime);
        }
    }
}
