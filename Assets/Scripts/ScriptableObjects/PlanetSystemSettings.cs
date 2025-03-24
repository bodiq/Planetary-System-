using System.Collections.Generic;
using Data;
using Enums;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Planetary System Settings", menuName = "ScriptableObjects/Planetary System Settings")]
    public class PlanetSystemSettings : ScriptableObject
    {
        [Range(1f, 200f)] [SerializeField] private double mainPlanetarySystemMass;
        [Range(3, 25)] [SerializeField] private int planetsCount;
        
        [SerializeField] private float minAdditionalPlanetPosOffset;
        [SerializeField] private float maxAdditionalPlanetPosOffset;

        [SerializeField] private float minPlanetOrbitSpeed;
        [SerializeField] private float maxPlanetOrbitSpeed;
        
        [SerializeField] private List<PlanetVisualData> planetsVisualData;
        
        public double MainPlanetarySystemMass => mainPlanetarySystemMass;
        public int PlanetsCount => planetsCount;
        public float MinAdditionalPlanetPosOffset => minAdditionalPlanetPosOffset;
        public float MaxAdditionalPlanetPosOffset => maxAdditionalPlanetPosOffset;
        public float MinPlanetOrbitSpeed => minPlanetOrbitSpeed;
        public float MaxPlanetOrbitSpeed => maxPlanetOrbitSpeed;
        
        public Dictionary<MassClassEnum, Material> PlanetsVisualData = new();

        public void InitializeVisualData()
        {
            PlanetsVisualData.Clear();

            foreach (var visualData in planetsVisualData)
            {
                PlanetsVisualData.Add(visualData.planetType, visualData.planetMaterial);
            }
        }
    }
}