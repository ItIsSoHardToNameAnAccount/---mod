using HarmonyLib;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static UINPCQingJiaoSkillData;

namespace LS.ZhuqueDan.Patch
{
    [HarmonyPatch(typeof(jsonData), "init")]
    public class ItemDataPatcher
    {
        [HarmonyPostfix]
        public static void Postfix(string path, ref JSONObject jsondata)
        {
            if (path == "Effect/json/d_items.py.datas")
            {
                ZhuqueDan.instance.Log("开始注入朱雀丹丹药数据...");

                string dllPath = Assembly.GetExecutingAssembly().Location;
                string dllDirectory = Path.GetDirectoryName(dllPath);
                string danyaoPath = Path.Combine(dllDirectory, "Config", "ZhuqueDan.json");

                if (!File.Exists(danyaoPath))
                {
                    ZhuqueDan.instance.Error("读取物品文件失败！");
                    return;
                }

                JSONObject zhuqueDanData;

                string data = File.ReadAllText(danyaoPath);
                if (string.IsNullOrWhiteSpace(data))
                {
                    zhuqueDanData = new JSONObject(JSONObject.Type.OBJECT);
                    ZhuqueDan.instance.Error("丹药数据注入失败！");
                    return;
                }
                //ModResources._TextCache[danyaoPath] = data;

                zhuqueDanData = new JSONObject(data, -2, false, false);
                foreach (string text in zhuqueDanData.keys)
                {
                    jsondata.AddField(text, zhuqueDanData[text]);
                }

                ZhuqueDan.instance.Log("丹药数据注入成功。");
            }

            if(path == "Effect/json/d_LianDan.py.DanFangBiao")
            {
                ZhuqueDan.instance.Log("开始注入朱雀丹丹方数据...");

                string dllPath = Assembly.GetExecutingAssembly().Location;
                string dllDirectory = Path.GetDirectoryName(dllPath);
                string danfangPath = Path.Combine(dllDirectory, "Config", "ZhuqueDanfang.json");

                if (!File.Exists(danfangPath))
                {
                    ZhuqueDan.instance.Error("读取物品文件失败！");
                    return;
                }
                
                JSONObject zhuqueDanfangData;
                
                string data = File.ReadAllText(danfangPath);
                if (string.IsNullOrWhiteSpace(data))
                {
                    zhuqueDanfangData = new JSONObject(JSONObject.Type.OBJECT);
                    ZhuqueDan.instance.Error("丹方数据注入失败！");
                    return;
                }

                zhuqueDanfangData = new JSONObject(data, -2, false, false);
                foreach (string text in zhuqueDanfangData.keys)
                {
                    jsondata.AddField(text, zhuqueDanfangData[text]);
                }

                ZhuqueDan.instance.Log("丹方数据注入成功。");
            }
        }
    }
}
