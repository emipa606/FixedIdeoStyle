using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace FixedIdeoStyle;

[StaticConstructorOnStartup]
public class Command_SetStyle : Command
{
    private static readonly FieldInfo cachedGraphic = AccessTools.Field(typeof(Blueprint_Build), "cachedGraphic");
    private readonly List<ThingStyleDef> styles;

    private readonly Thing thing;
    private readonly ThingDef thingDef;

    public Command_SetStyle(Thing thing, ThingDef thingDef, List<ThingStyleDef> styles)
    {
        this.thing = thing;
        this.thingDef = thingDef;
        this.styles = styles;

        defaultLabel = "Styles".Translate().CapitalizeFirst();
        icon = thingDef.uiIcon;
        iconAngle = thingDef.uiIconAngle;
        iconDrawScale = GenUI.IconDrawScale(thingDef);
        iconOffset = thingDef.uiIconOffset;
        defaultIconColor = thingDef.uiIconColor;
        defaultDesc = "ChangeStyle".Translate().CapitalizeFirst();

        var style = thing.StyleDef;
        if (style == null)
        {
            return;
        }

        defaultLabel = style.Category.LabelCap;
        icon = style.UIIcon;
    }

    public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
    {
        var result = base.GizmoOnGUI(topLeft, maxWidth, parms);

        Designator_Dropdown.DrawExtraOptionsIcon(topLeft, GetWidth(maxWidth));

        return result;
    }

    public override void ProcessInput(Event ev)
    {
        base.ProcessInput(ev);

        var options = new List<FloatMenuOption>
        {
            new FloatMenuOption("None".Translate(), delegate { SetThingStyle(null); }, thingDef)
        };

        options.AddRange(styles.Select(s =>
            new FloatMenuOption(s.Category.LabelCap, delegate { SetThingStyle(s); }, s.UIIcon, thingDef.uiIconColor)));

        Find.WindowStack.Add(new FloatMenu(options));
    }

    public void SetThingStyle(ThingStyleDef style)
    {
        thing.StyleDef = style;

        if (thing is not Blueprint_Build blueprint)
        {
            return;
        }

        cachedGraphic.SetValue(blueprint, null);
        blueprint.DirtyMapMesh(blueprint.Map);
    }
}