using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace FixedIdeoStyle;

[HarmonyPatch(typeof(GenConstruct), nameof(GenConstruct.CanConstruct), typeof(Thing), typeof(Pawn), typeof(bool),
    typeof(bool))]
internal static class GenConstruct_CanConstruct_Patch
{
    private static readonly List<string> tmpIdeoMemberNames = new List<string>();

    public static void Postfix(ref bool __result, Thing t, Pawn p)
    {
        if (!__result)
        {
            return;
        }

        if (t is not Frame frame || frame.Faction != Faction.OfPlayer)
        {
            return;
        }

        if (frame.def.entityDefToBuild is not ThingDef thingDef)
        {
            return;
        }

        var frameStyle = frame.StyleDef;
        var builderStyle = p.Ideo?.GetStyleFor(thingDef);

        if (frameStyle == builderStyle)
        {
            return;
        }

        __result = false;

        tmpIdeoMemberNames.Clear();
        foreach (var ideo in Find.IdeoManager.IdeosListForReading)
        {
            if (ideo.GetStyleFor(thingDef) == frameStyle)
            {
                tmpIdeoMemberNames.Add(ideo.memberName);
            }
        }

        if (tmpIdeoMemberNames.Any())
        {
            JobFailReason.Is("OnlyMembersCanBuild".Translate(tmpIdeoMemberNames.ToCommaList(true)));
        }
    }
}