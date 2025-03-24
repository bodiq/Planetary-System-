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
        
        public void Initialize(double mass, GameObject planetaryObject, PlanetSystemSettings planetSystemSettings, Vector3 centerPoint)
        {
            Mass = mass;
            MassClass = MassClassHelper.GetPlanetClassByMass(Mass);
            gameObject.name = MassClass.ToString();

            var radius = CalculateRadius();
            SetScale(radius);
            SetPosition(planetaryObject, planetSystemSettings, radius);
            SetVisual(planetSystemSettings);
            SetOrbitSetup(planetSystemSettings, centerPoint);
        }
        
        public void Simulate(float deltaTime)
        {
            transform.RotateAround(_center, Vector3.down, _orbitSpeed * deltaTime);
        }

        private void SetOrbitSetup(PlanetSystemSettings planetSystemSettings, Vector3 center)
        {
            _orbitSpeed = Random.Range(planetSystemSettings.MinPlanetOrbitSpeed, planetSystemSettings.MaxPlanetOrbitSpeed);
            _center = center;
        }

        private void SetVisual(PlanetSystemSettings planetSystemSettings)
        {
            if (planetSystemSettings.PlanetsVisualData.TryGetValue(MassClass, out var material))
            {
                meshRenderer.material = material;
            }
        }

        private void SetPosition(GameObject planetaryObject, PlanetSystemSettings planetSystemSettings, float radius)
        {
            var previousPlanetOffset = 0f;
            if (planetaryObject != null)
            {
                previousPlanetOffset = planetaryObject.transform.position.x + planetaryObject.transform.localScale.x;
            }
            
            var additionalRadiusOffset = Random.Range(planetSystemSettings.MinAdditionalPlanetPosOffset, planetSystemSettings.MaxAdditionalPlanetPosOffset);
            transform.position = new Vector3(previousPlanetOffset + radius + additionalRadiusOffset, transform.position.y, transform.position.z);
        }

        private float CalculateRadius()
        {
            var percentDueToMass = MassClassHelper.GetPercentOfMaxMass(MassClass, Mass);
            return MassClassHelper.GetPlanetRadius(MassClass, percentDueToMass);
        }

        private void SetScale(float radius)
        {
            transform.localScale = Vector3.one * radius;
        }
    }
}