using KBEngine;

namespace LS.ZhuqueDan.Utility
{
    internal class PlayerDataHandler
    {
        public void setPlayerHp()
        {
            var playerEntity = ((KBEngine.Avatar)KBEngineApp.app.player());
            int maxHp = playerEntity.HP_Max;
            int targetHp = maxHp / 10;
            int currentHp = playerEntity.HP;
            if (currentHp >= targetHp)
            {
                int value = currentHp - targetHp + 1;
                playerEntity.AllMapAddHP(-value);
            }
        }
    }
}
