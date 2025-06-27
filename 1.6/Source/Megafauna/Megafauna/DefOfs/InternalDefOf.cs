using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace Megafauna
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static MegafaunaToggleableSpawnDef ME_ToggleableAnimals;
        public static MegafaunaToggleableSpawnDef ME_VanillaAnimalToggles;




    }
}
