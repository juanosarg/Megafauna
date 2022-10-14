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

    [HarmonyPatch(typeof(MapTemperature))]
    [HarmonyPatch("SeasonAcceptableFor")]
    public static class Megafauna_MapTemperature_SeasonAcceptableFor_Patch
    {
        [HarmonyPostfix]
        public static void AllowAnimalSpawns(ThingDef animalRace, ref bool __result)

        {

            if (!Megafauna_Mod.settings.flagVanillaAnimals)
            {
                
                if (InternalDefOf.ME_VanillaAnimalToggles.toggleablePawns.Contains(animalRace.defName))
                {
                    __result = false;
                }

            }

            if (Megafauna_Mod.settings.pawnSpawnStates != null && Megafauna_Mod.settings.pawnSpawnStates.Keys.Contains(animalRace.defName))
            {
                if (Megafauna_Mod.settings.pawnSpawnStates[animalRace.defName])
                {

                    __result = false;
                }
               
            }


        }
    }



   

}
