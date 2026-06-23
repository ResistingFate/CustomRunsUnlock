using System;
using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.CustomRun;
using MegaCrit.Sts2.Core.Nodes.Screens.DailyRun;
using MegaCrit.Sts2.Core.Nodes.Screens.GameOverScreen;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Runs.History;
using MegaCrit.Sts2.addons.mega_text;
using MegaCrit.Sts2.Core.Runs;
using MegaCrit.Sts2.Core.Saves;
using MegaCrit.Sts2.Core.Saves.Managers;

namespace CustomRunsUnlock.CustomRunsUnlockCode;

[HarmonyPatch(typeof(GameModeExtension), nameof(GameModeExtension.AreAchievementsAndEpochsLocked))]
public static class AchievementsAndEpochsUnlockPatch
{
    public static bool Prefix(GameMode gameMode, ref bool __result)
    {
        __result = false;
        return false;
    }
}

[HarmonyPatch(typeof(ProgressSaveManager), nameof(ProgressSaveManager.UpdateWithRunData),
    new[] { typeof(SerializableRun), typeof(bool) })]
public static class AscensionEnablerPatch
{
    [HarmonyPriority(Priority.First)]
    public static void Prefix(SerializableRun serializableRun, out GameMode __state)
    {
        __state = serializableRun.GameMode;

        if (serializableRun.GameMode is GameMode.Custom or GameMode.Daily)
        {
            serializableRun.GameMode = GameMode.Standard;
        }
    }

    [HarmonyPriority(Priority.Low)]
    public static Exception? Finalizer(SerializableRun serializableRun, GameMode __state, Exception? __exception)
    {
        serializableRun.GameMode = __state;
        return __exception;
    }
}

[HarmonyPatch(typeof(NDailyRunScreen), nameof(NDailyRunScreen._Ready))]
public static class HideDailyDisclaimerPatch
{
    public static void Postfix(NDailyRunScreen __instance)
    {
        __instance.GetNodeOrNull<Control>("%Disclaimer")?.Hide();
    }
}

[HarmonyPatch(typeof(NCustomRunScreen), nameof(NCustomRunScreen._Ready))]
public static class HideCustomDisclaimerPatch
{
    public static void Postfix(NCustomRunScreen __instance)
    {
        __instance.GetNodeOrNull<Control>("%Disclaimer")?.Hide();
    }
}
