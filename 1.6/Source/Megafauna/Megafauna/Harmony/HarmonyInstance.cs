using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;





namespace Megafauna
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.megafauna");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
           

        }

      
    }

}
