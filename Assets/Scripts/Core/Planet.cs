using ClassHelpers;
using Enums;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class Planet : MonoBehaviour, IPlanetaryObject
    {
        public MassClassEnum MassClass { get; set; }
        public double Mass { get; set; }

        private float _orbitSpeed;
        
        public void Initialize(double mass, float previousPlanetXPos)
        {
            Mass = mass;
            MassClass = MassClassHelper.GetPlanetClassByMass(Mass);
            gameObject.name = MassClass.ToString();
            var currentRadius = MassClassHelper.GetPlanetRadius(MassClass);
            transform.localScale = Vector3.one * currentRadius;
            var additionalRadiusOffset = Random.Range(1f, 6f);
            transform.position = new Vector3(previousPlanetXPos + currentRadius + additionalRadiusOffset, transform.position.y, transform.position.z);
            _orbitSpeed = Random.Range(5f, 15f);
        }

        public void Simulate(float deltaTime)
        {
            transform.RotateAround(Vector3.zero, Vector3.up, _orbitSpeed * deltaTime);
        }
    }
}