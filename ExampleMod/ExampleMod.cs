using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace ShtestingMod;
//More info on creating mods can be found https://github.com/resonite-modding-group/ResoniteModLoader/wiki/Creating-Mods
public class ExampleMod : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "SHTESTING";
	public override string Author => "Redd";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/Redd56/shtesting";

	public override void OnEngineInit() {
		Harmony harmony = new Harmony("com.Redd.ShtestingMod");
		harmony.PatchAll();
	}

	//Example of how a HarmonyPatch can be formatted, Note that the following isn't a real patch and will not compile.
	[HarmonyPatch(typeof(SphericalHarmonicsHelper), "IsSupported")]
	private static class PatchIsSupported
	{
		[HarmonyPrefix]
		private static bool Prefix(ref bool __result, Type sphericalHarmonicType)
		{
			__result = sphericalHarmonicType.IsEnginePrimitive();
			return false;
		}
	}

}
