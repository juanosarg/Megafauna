using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace Megafauna
{



   

    public class Megafauna_Mod : Mod
    {

        public static Megafauna_Settings settings;

        public Megafauna_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<Megafauna_Settings>();
        }
        public override string SettingsCategory() => "Megafauna";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);

            MegafaunaToggleableSpawnDef toggleablespawndef = (from k in DefDatabase<MegafaunaToggleableSpawnDef>.AllDefsListForReading
                                                     where k.defName == "ME_ToggleableAnimals"
                                                     select k).RandomElement();


            if (settings.pawnSpawnStates == null) settings.pawnSpawnStates = new Dictionary<string, bool>();
            foreach (string defName in toggleablespawndef.toggleablePawns)
            {
                if (!settings.pawnSpawnStates.ContainsKey(defName))
                {
                    settings.pawnSpawnStates[defName] = false;
                }
            }



            settings.DoWindowContents(inRect);


        }
    }
}
