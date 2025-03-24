using System;
using System.Collections.Generic;
using Enums;

namespace ClassHelpers
{
    public static class MassClassHelper
    {
        private static readonly Dictionary<MassClassEnum, (double maxMass, float minRadius, float maxRadius)> MassData =
            new()
            {
                {MassClassEnum.Asteroidan, (0.00001, 0, 0.03f)},
                {MassClassEnum.Mercurian,  (0.1, 0.03f, 0.7f)},
                {MassClassEnum.Subterran, (0.5, 0.5f, 1.2f)},
                {MassClassEnum.Terran, (2, 0.8f, 1.9f)},
                {MassClassEnum.Superterran, (10, 1.3f, 3.3f)},
                {MassClassEnum.Neptunian, (50, 2.1f, 5.7f)},
                {MassClassEnum.Jovian, (5000, 3.5f, 27f)}
            };
        
        public static MassClassEnum GetPlanetClassByMass(double mass)
        {
            foreach (var planet in MassData)
            {
                if (mass < planet.Value.maxMass)
                {
                    return planet.Key;
                }
            }

            return MassClassEnum.Jovian;
        }

        public static float GetPercentOfMaxMass(MassClassEnum massClass, double mass)
        {
            if (MassData.TryGetValue(massClass, out var massData))
            {
                return (float)(100.0 / massData.maxMass * mass);
            }
            
            return -1f;
        }

        public static float GetPlanetRadius(MassClassEnum massClass, float percent)
        {
            if (MassData.TryGetValue(massClass, out var massData))
            {
                return massData.maxRadius + (massData.maxRadius - massData.minRadius) * (percent / 100);
            }

            return -1f;
        }
    }
}