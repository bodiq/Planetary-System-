using System;
using Enums;

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
    }
}