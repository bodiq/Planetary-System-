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
        public void Initialize(double mass, float previousPlanetXPos)
        {
            Mass = mass;
            gameObject.name = MassClass.ToString();
            MassClass = MassClassHelper.GetPlanetClassByMass(Mass);
            transform.localScale = Vector3.one;
            var currentRadius = MassClassHelper.GetPlanetRadius(MassClass);
            var additionalRadiusOffset = Random.Range(1f, 6f);
            transform.position = new Vector3(previousPlanetXPos + currentRadius + additionalRadiusOffset, transform.position.y, transform.position.z);
        }

        public void Simulate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}