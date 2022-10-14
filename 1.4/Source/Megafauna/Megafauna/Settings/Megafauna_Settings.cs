using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Megafauna
{
    public class Megafauna_Settings : ModSettings

    {
        public const float megafaunaSpawnMultiplierBase = 1;
        public float megafaunaSpawnMultiplier = megafaunaSpawnMultiplierBase;
        public bool flagVanillaAnimals = true;

        private static Vector2 scrollPosition = Vector2.zero;
        public Dictionary<string, bool> pawnSpawnStates = new Dictionary<string, bool>();
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref pawnSpawnStates, "pawnSpawnStates", LookMode.Value, LookMode.Value, ref pawnKeys, ref boolValues);
            Scribe_Values.Look(ref megafaunaSpawnMultiplier, "megafaunaSpawnMultiplier", megafaunaSpawnMultiplierBase, true);
            Scribe_Values.Look(ref flagVanillaAnimals, "flagVanillaAnimals", true, true);

        }
        private List<string> pawnKeys;
        private List<bool> boolValues;

        public void DoWindowContents(Rect inRect)
        {

            List<string> keys = pawnSpawnStates.Keys.ToList().OrderByDescending(x => x).ToList();
            Listing_Standard ls = new Listing_Standard();

            

            Rect rect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect rect2 = new Rect(0f, 0f, inRect.width - 30f, ((keys.Count / 2) + 10) * 24);
            Widgets.BeginScrollView(rect, ref scrollPosition, rect2, true);

           

            ls.ColumnWidth = rect2.width / 2.1f;
            ls.Begin(rect2);

            ls.Label("ME_MegafaunaSpawnMultiplier".Translate() + ": " + megafaunaSpawnMultiplier, -1, "ME_MegafaunaSpawnMultiplierTooltip".Translate());
            megafaunaSpawnMultiplier = (float)Math.Round(ls.Slider(megafaunaSpawnMultiplier, 0.1f, 5f), 2);

            if(ls.ButtonText("ME_Reset".Translate()))
            {
                megafaunaSpawnMultiplier = megafaunaSpawnMultiplierBase;

            }



            ls.CheckboxLabeled("ME_allowVanillaAnimals".Translate(), ref flagVanillaAnimals, null);
            for (int num = keys.Count - 1; num >= 0; num--)
            {
                if (num == (keys.Count/2) ) { ls.NewColumn(); }
                bool test = pawnSpawnStates[keys[num]];
                if (DefDatabase<PawnKindDef>.GetNamedSilentFail(keys[num]) == null)
                {
                    pawnSpawnStates.Remove(keys[num]);
                }
                else
                {
                    ls.CheckboxLabeled("ME_DisableAnimal".Translate(PawnKindDef.Named(keys[num]).LabelCap), ref test);
                    pawnSpawnStates[keys[num]] = test;
                }
            }

            ls.End();
            Widgets.EndScrollView();
            base.Write();


        }


    }

   

}
