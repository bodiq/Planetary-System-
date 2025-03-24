using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetarySimulationHandler : MonoBehaviour
    {
        [SerializeField] private Planet planetPrefab;
    
        private IPlanetarySystem _planetSystemFactory;
    
        private void Start()
        {
            var factory = new PlanetarySystemFactory(planetPrefab, transform);
            _planetSystemFactory = factory.Create(100);
        }

        private void Update()
        {
            _planetSystemFactory?.UpdatePlanets(Time.deltaTime);
        }
    }
}
