using HarmonyLib;
using MegaCrit.Sts2.Core.Runs;

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