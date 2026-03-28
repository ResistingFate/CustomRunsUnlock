# CustomRunsUnlock

CustomRunsUnlock lets you unlock Ascensions, Epoches, and Achievements in Custom and Daily Runs.

<img src="CustomRunsUnlock/combined_smooth_transition_8mb.gif" alt="Alt Text" width="480" />

Note the relics up top confirming the mode is daily challenge and that the ascension is lv 1, and after victory the Epoch unlocks and the next ascension is lv 2.

## What it does

Just as you could in early access release, you can now enjoy games of Custom and Daily runs without wasting a run with progressing your character stats, the timeline, or ascension level.
Use in tandem with the below mods give Custom Runs all the features of Standard Runs;
- my other mod [NeowAlwaysRewards](https://www.nexusmods.com/slaythespire2/mods/256)
- beloved [UnifiedSaveLoader](https://www.nexusmods.com/slaythespire2/mods/6) by luojies

### Works for:
Daily Runs and Custom Runs have all Standard Run features:
- Unlock epoches in the timeline
- Unlock achievements
- Unlock ascensions
- Tracks win/loss streak
- Updates card stats
- Updates ancient stats
- Works in multiplayer
- Removes the disclaimers in Custom and Daily screens

## How it works
- Used Harmony Prefix to change the input to UpdateWithRunData method in ProgressSaveManager to change it's argument serializableRun Property GameMode Standard.
- Used Harmony Postfix to set the GameMode back to what it was before.
- Used Harmony Prefix to replace AreAchievementsAndEpochsLocked in GameModeExtension to always return false.
- Used a Prefix to delete the node for the disclaimer in both in NCustomRunScreen and NDailyRunScreen.

## Installation

Place the mod in:

```text
Slay the Spire 2/
  mods/
    CustomRunsUnlock/
      CustomRunsUnlock.dll
      CustomRunsUnlock.pck
      CustomRunsUnlock.json
```

Future work
- Monitor patch order interactions with other related mods
- Add explicit Harmony ordering if needed
- Remove the warning that Daily Runs and Custom Runs do not count for game progression

## Build
- I followed Alchyr's guide with JellyBeans Rider and use their templates:
  https://github.com/Alchyr/ModTemplate-StS2/wiki
- I made a Claude.md for working with AI fors making Slay the Spire 2 mods
- I just got JellyBean Rider to make the sln from opening the .cspoj file
- Make sure to edit in .csproj the location of your Slay the Spire 2 game and your Megadot install