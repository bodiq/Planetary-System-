using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Planetary System Settings", menuName = "ScriptableObjects/Planetary System Settings")]
    public class PlanetSystemSettings : ScriptableObject
    {
        [Range(20f, 200f)] [SerializeField] private double mainPlanetarySystemMass;
        [Range(3, 10)] [SerializeField] private int planetsCount;
        
        [SerializeField] private float minAdditionalPlanetPosOffset;
        [SerializeField] private float maxAdditionalPlanetPosOffset;

        [SerializeField] private float minPlanetOrbitSpeed;
        [SerializeField] private float maxPlanetOrbitSpeed;
        
        public double MainPlanetarySystemMass => mainPlanetarySystemMass;
        public int PlanetsCount => planetsCount;
        public float MinAdditionalPlanetPosOffset => minAdditionalPlanetPosOffset;
        public float MaxAdditionalPlanetPosOffset => maxAdditionalPlanetPosOffset;
        public float MinPlanetOrbitSpeed => minPlanetOrbitSpeed;
        public float MaxPlanetOrbitSpeed => maxPlanetOrbitSpeed;
    }
}