using System;
using Enums;
using Random = UnityEngine.Random;

namespace ClassHelpers
{
    public static class MassClassHelper
    {
        public static MassClassEnum GetPlanetClassByMass(double mass)
        {
            if (mass < 0.00001)
                return MassClassEnum.Asteroidan;
            if (mass < 0.1)
                return MassClassEnum.Mercurian;
            if (mass < 0.5)
                return MassClassEnum.Subterran;
            if (mass < 2)
                return MassClassEnum.Mercurian;
            if (mass < 10)
                return MassClassEnum.Superterran;
            if (mass < 50)
                return MassClassEnum.Neptunian;

            return MassClassEnum.Jovian;
        }

        public static float GetPlanetRadius(MassClassEnum massClass)
        {
            switch (massClass)
            {
                case MassClassEnum.Asteroidan:
                    return Random.Range(0f, 0.03f);
                case MassClassEnum.Mercurian:
                    return Random.Range(0.03f, 0.7f);
                case MassClassEnum.Subterran:
                    return Random.Range(0.5f, 1.2f);
                case MassClassEnum.Terran:
                    return Random.Range(0.8f, 1.9f);
                case MassClassEnum.Superterran:
                    return Random.Range(1.3f, 3.3f);
                case MassClassEnum.Neptunian:
                    return Random.Range(2.1f, 5.7f);
                case MassClassEnum.Jovian:
                    return Random.Range(3.5f, 27f);
                default:
                    throw new ArgumentOutOfRangeException(nameof(massClass), massClass, null);
            }
        }
    }
}