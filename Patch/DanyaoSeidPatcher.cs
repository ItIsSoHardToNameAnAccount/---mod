using HarmonyLib;
using LS.ZhuqueDan.Utility;

namespace LS.ZhuqueDan.Patch
{
    [HarmonyPatch(typeof(GUIPackage.item), "realizeSeid")]
    internal class DanyaoSeidPatcher
    {
        [HarmonyPrefix]
        public static bool realizeSeid60(ref int seid)
        {
            if(seid == 60)
            {
                PlayerDataHandler playerDataHandler = new PlayerDataHandler();
                playerDataHandler.setPlayerHp();
                return false;
            }
            return true;
        }
    }
}
