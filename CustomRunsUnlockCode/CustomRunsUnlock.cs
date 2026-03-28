using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.CustomRun;
using MegaCrit.Sts2.Core.Nodes.Screens.DailyRun;
using MegaCrit.Sts2.Core.Runs;
using MegaCrit.Sts2.Core.Saves;
using MegaCrit.Sts2.Core.Saves.Managers;

namespace CustomRunsUnlock.CustomRunsUnlockCode;

[HarmonyPatch(typeof(GameModeExtension), "AreAchievementsAndEpochsLocked")]
public static class CustomRunsUnlock
{
    public static bool Prefix( GameMode gameMode, ref bool __result)
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
    public static void Prefix(SerializableRun serializableRun, GameMode? __state)
    {
        __state = serializableRun.GameMode;
        if (serializableRun.GameMode is GameMode.Custom or GameMode.Daily)
        {
            serializableRun.GameMode = GameMode.Standard;
        }
    }
    
    [HarmonyPriority(Priority.Low)]
    public static void PostFix(SerializableRun serializableRun, GameMode? __state)
    {
        if (__state.HasValue)
        {
            serializableRun.GameMode = __state.Value;
        }
    }
}

[HarmonyPatch(typeof(NDailyRunScreen), nameof(NDailyRunScreen._Ready))]
public static class HideDailyDisclaimerPatch
{
    static void Postfix(NDailyRunScreen __instance)
    {
        __instance.GetNodeOrNull<Control>("%Disclaimer")?.QueueFree(); // Deletes node, can hide with ;.Hide();
    }
}

[HarmonyPatch(typeof(NCustomRunScreen), nameof(NCustomRunScreen._Ready))]
public static class HideCustomDisclaimerPatch
{
    static void Postfix(NCustomRunScreen __instance)
    {
        __instance.GetNodeOrNull<Control>("%Disclaimer")?.QueueFree(); // Deletes node, can hide with .Hide();
    }
}