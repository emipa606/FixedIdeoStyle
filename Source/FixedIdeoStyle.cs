using System;
using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace FixedIdeoStyle
{
    [StaticConstructorOnStartup]
    public static class FixedIdeoStyle
    {
        static FixedIdeoStyle()
        {
            var harmony = new Harmony("me.lubar.FixedIdeoStyle");

            harmony.PatchAll();
        }
    }
}
