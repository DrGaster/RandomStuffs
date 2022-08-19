using BepInEx;
using BerryLoaderNS;
using HarmonyLib;

namespace RandomStuffs
{
	[BepInPlugin("EpicExampleModId", "Epic Example Mod", "0.0.1")]
	[BepInDependency("BerryLoader")]
	class Plugin : BaseUnityPlugin
	{
		public static BepInEx.Logging.ManualLogSource L;

		private void Awake()
		{
			L = Logger;
			L.LogInfo("hello from RandomStuffs.Plugin.Awake");
			Harmony.CreateAndPatchAll(typeof(Patches));
		}

		static class Patches
{
	[HarmonyPatch(typeof(GameDataValidator), "Check")]
	[HarmonyPrefix]

	public static bool DisableValidator() => false;
}
[HarmonyPatch(typeof(WorldManager), nameof(WorldManager.CardCapIncrease))]
[HarmonyPostfix]
static void CardCapIncrease(WorldManager __instance, GameBoard board, ref int __result)
{
  __result += __instance.GetCardCount("RandomStuffs_Compound", board) * 49; // change that last number to whatever
}
	}
}