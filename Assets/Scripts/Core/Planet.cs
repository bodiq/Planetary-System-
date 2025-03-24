using Enums;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class Planet : MonoBehaviour, IPlanetaryObject
    {
        public MassClassEnum MassClass { get; set; }
        public double Mass { get; set; }
    }
}