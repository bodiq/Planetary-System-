using ClassHelpers;
using Enums;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class Planet : MonoBehaviour, IPlanetaryObject
    {
        [SerializeField] private MeshRenderer meshRenderer;
        public MassClassEnum MassClass { get; set; }
        public double Mass { get; set; }

        private float _orbitSpeed;
        private Vector3 _center;
        
        public void Initialize(double mass, float previousPlanetXPos, PlanetSystemSettings planetSystemSettings, Vector3 centerPoint)
        {
            Mass = mass;
            MassClass = MassClassHelper.GetPlanetClassByMass(Mass);
            gameObject.name = MassClass.ToString();
            var currentRadius = MassClassHelper.GetPlanetRadius(MassClass);
            transform.localScale = Vector3.one * currentRadius;
            var additionalRadiusOffset = Random.Range(planetSystemSettings.MinAdditionalPlanetPosOffset, planetSystemSettings.MaxAdditionalPlanetPosOffset);
            transform.position = new Vector3(previousPlanetXPos + currentRadius + additionalRadiusOffset, transform.position.y, transform.position.z);
            _orbitSpeed = Random.Range(planetSystemSettings.MinPlanetOrbitSpeed, planetSystemSettings.MaxPlanetOrbitSpeed);
            _center = centerPoint;
            if (planetSystemSettings.PlanetsVisualData.TryGetValue(MassClass, out var material))
            {
                meshRenderer.material = material;
            }
        }

        public void Simulate(float deltaTime)
        {
            transform.RotateAround(_center, Vector3.up, _orbitSpeed * deltaTime);
        }
    }
}