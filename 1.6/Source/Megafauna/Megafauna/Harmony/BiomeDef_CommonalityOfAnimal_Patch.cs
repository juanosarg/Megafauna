using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Verse.AI;

namespace Megafauna
{
    /*This Harmony Postfix multiplies commonality of animals in the biome
    */
    [HarmonyPatch(typeof(BiomeDef))]
    [HarmonyPatch("CommonalityOfAnimal")]
    public static class Megafauna_BiomeDef_CommonalityOfAnimal_Patch
    {
        [HarmonyPostfix]
        public static void MultiplyAlphaAnimalCommonality(PawnKindDef animalDef, ref float __result)

        {

            if (InternalDefOf.ME_ToggleableAnimals.toggleablePawns.Contains(animalDef.defName))
            {
                float TotalMultiplier = Megafauna_Mod.settings.megafaunaSpawnMultiplier;
                __result *= TotalMultiplier;

            }


        }
    }
}
