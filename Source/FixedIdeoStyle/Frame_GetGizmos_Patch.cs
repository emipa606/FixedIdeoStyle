using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace FixedIdeoStyle;

[HarmonyPatch(typeof(Frame), nameof(Frame.GetGizmos))]
internal static class Frame_GetGizmos_Patch
{
    public static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> __result, Frame __instance)
    {
        foreach (var gizmo in __result)
        {
            yield return gizmo;
        }

        var styleGizmo = FixedIdeoStyle.ChangeStyleGizmo(__instance, __instance.def.entityDefToBuild as ThingDef);
        if (styleGizmo != null)
        {
            yield return styleGizmo;
        }
    }
}