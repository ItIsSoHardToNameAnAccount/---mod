using BepInEx;
using HarmonyLib;

namespace LS.ZhuqueDan
{
    [BepInPlugin("LonelyStanding.MCS.ZhuqueDan", "朱雀丹", "1.0.0")]
    public class ZhuqueDan: BaseUnityPlugin
    {
        public static ZhuqueDan instance;
        private void Awake()
        {
            instance = this;
            var harmony = new Harmony("LonelyStanding.MCS.ZhuqueDan");
            harmony.PatchAll();
            Log("朱雀丹成功加载");
        }

        public void Log(string message)
        {
            Logger.LogInfo(message);
        }

        public void Error(string message)
        {
            Logger.LogError(message);
        }
    }
}
