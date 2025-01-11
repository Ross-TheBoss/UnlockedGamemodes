using MelonLoader;
using BTD_Mod_Helper;
using UnlockedGamemodes;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using HarmonyLib;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(UnlockedGamemodes.UnlockedGamemodes), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace UnlockedGamemodes;

public class UnlockedGamemodes : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<UnlockedGamemodes>("UnlockedGamemodes loaded!");
    }

    [HarmonyPatch(typeof(ModeScreen), nameof(ModeScreen.Open))]
    internal static class ModeScreen_Open {
        [HarmonyPrefix]
        private static void Prefix(ModeScreen __instance){
            var hardModes = __instance.hardModes.gameObject;
            foreach (string gameMode in new string[] {"Sandbox", "Standard", "MagicOnly", "DoubleHpMoabs", "HalfCash", "AlternateBloonsRounds", "Impoppable", "Clicks"}){
                var gameModeObj = hardModes.GetComponentInChildrenByName<Transform>(gameMode).gameObject;
                var gameModeButton = gameModeObj.GetComponentInChildren<ModeButton>();
                gameModeButton.unlockMode = ""; // Remove unlock requirement
            }

            var mediumModes = __instance.mediumModes.gameObject;
            foreach (string gameMode in new string[] {"Standard", "MilitaryOnly", "Apopalypse", "Reverse", "Sandbox"}){
                var gameModeObj = mediumModes.GetComponentInChildrenByName<Transform>(gameMode).gameObject;
                var gameModeButton = gameModeObj.GetComponentInChildren<ModeButton>();
                gameModeButton.unlockMode = ""; // Remove unlock requirement
            }

            var easyModes = __instance.easyModes.gameObject;

            foreach (string gameMode in new string[] {"Sandbox", "Standard", "PrimaryOnly", "Deflation"}){
                var gameModeObj = easyModes.GetComponentInChildrenByName<Transform>(gameMode).gameObject;
                var gameModeButton = gameModeObj.GetComponentInChildren<ModeButton>();
                gameModeButton.unlockMode = ""; // Remove unlock requirement
            }
        }
    }
}