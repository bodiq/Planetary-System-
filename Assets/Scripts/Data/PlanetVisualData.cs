using System;
using Enums;
using UnityEngine;

namespace Data
{
    [Serializable]
    public struct PlanetVisualData
    {
        public Material planetMaterial;
        public MassClassEnum planetType;
    }
}