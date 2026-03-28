# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

## [1.0.0] - 2026-03-27

### Added
- Initial release of CustomRunsUnlock.
- Added Harmony-based unlocking support for non-standard runs.
- Enabled Ascension unlocks too.
- Removed the disclaimer from Daily and Custom Run screens

### Technical
- Used Harmony Prefix to change the input to UpdateWithRunData method in ProgressSaveManager to change it's argument serializableRun Property GameMode Standard.
- Used Harmony Postfix to set the GameMode back to what it was before.
- Used Harmony Prefix to replace AreAchievementsAndEpochsLocked in GameModeExtension to always return false.
- Used a Prefix to delete the node for the disclaimer in both in NCustomRunScreen and NDailyRunScreen.