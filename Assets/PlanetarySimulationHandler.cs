using Core;
using UnityEngine;

public class PlanetarySimulationHandler : MonoBehaviour
{
    [SerializeField] private Planet planetPrefab;
    
    private void Start()
    {
        var planetarySystemFactory = new PlanetarySystemFactory(planetPrefab, transform);
        planetarySystemFactory.Create(100);
    }
}
