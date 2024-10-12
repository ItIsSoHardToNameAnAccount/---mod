using Newtonsoft.Json.Linq;
using System.IO;

namespace LS.ZhuqueDan.Utility
{
    // 调用官方接口，该类暂时没用
    internal class JsonDataHandler
    {
        public void addDangFangData(string danfangPath)
        {
            string jsonString = File.ReadAllText(danfangPath);
            JObject danfangJsonData = JObject.Parse(jsonString);

            foreach (var idEntry in danfangJsonData)
            {
                string danfangId = idEntry.Key;
                JObject values = (JObject)idEntry.Value;

                JSONObject data = JSONObject.Create();
                data.AddField("id", (int)values["id"]);
                data.AddField("ItemID", (int)values["ItemID"]);
                data.AddField("name", (string)values["name"]);
                data.AddField("value1", (int)values["value1"]);
                data.AddField("num1", (int)values["num1"]);
                data.AddField("value2", (int)values["value2"]);
                data.AddField("num2", (int)values["num2"]);
                data.AddField("value3", (int)values["value3"]);
                data.AddField("num3", (int)values["num3"]);
                data.AddField("value4", (int)values["value4"]);
                data.AddField("num4", (int)values["num4"]);
                data.AddField("value5", (int)values["value5"]);
                data.AddField("num5", (int)values["num5"]);
                data.AddField("castTime", (int)values["castTime"]);

                jsonData.instance.LianDanDanFangBiao.AddField(danfangId, data);
            }

            //ZhuqueDan.Instance.Error("输出追加后的完整丹方：");
            //ZhuqueDan.Instance.Error(jsonData.instance.LianDanDanFangBiao.ToString());
        }

        public void addItem(string itemPath, string seidPath)
        {
            string jsonString = File.ReadAllText(itemPath);
            JObject values = JObject.Parse(jsonString);

            JSONObject data = JSONObject.Create();
            data.AddField("id", (int)values["id"]);
            data.AddField("ItemIcon", (int)values["ItemIcon"]);
            data.AddField("maxNum", (int)values["maxNum"]);
            data.AddField("name", (string)values["name"]);
            data.AddField("FaBaoType", (string)values["FaBaoType"]);

            JSONObject affixData = JSONObject.arr;
            foreach (var affix in values["Affix"])
            {
                affixData.Add((int)affix);
            }
            data.AddField("Affix", affixData);

            data.AddField("TuJianType", (int)values["TuJianType"]);
            data.AddField("ShopType", (int)values["ShopType"]);

            JSONObject itemFlagData = JSONObject.arr;
            foreach (var itemFlag in values["ItemFlag"])
            {
                itemFlagData.Add((int)itemFlag);
            }
            data.AddField("ItemFlag", itemFlagData);

            data.AddField("WuWeiType", (int)values["WuWeiType"]);
            data.AddField("ShuXingType", (int)values["ShuXingType"]);
            data.AddField("type", (int)values["type"]);
            data.AddField("quality", (int)values["quality"]);
            data.AddField("typePinJie", (int)values["typePinJie"]);
            data.AddField("StuTime", (int)values["StuTime"]);

            JSONObject seidData = JSONObject.arr;
            foreach (var seid in values["seid"])
            {
                seidData.Add((int)seid);
                // 目前只支持单个seid注入，如果物品涉及多个seid需要重写方法
                addSeid(seidPath, (int)seid);
            }
            data.AddField("seid", seidData);

            data.AddField("vagueType", (int)values["vagueType"]);
            data.AddField("price", (int)values["price"]);
            data.AddField("desc", (string)values["desc"]);
            data.AddField("desc2", (string)values["desc2"]);
            data.AddField("CanSale", (int)values["CanSale"]);
            data.AddField("DanDu", (int)values["DanDu"]);
            data.AddField("CanUse", (int)values["CanUse"]);
            data.AddField("NPCCanUse", (int)values["NPCCanUse"]);
            data.AddField("yaoZhi1", (int)values["yaoZhi1"]);
            data.AddField("yaoZhi2", (int)values["yaoZhi2"]);
            data.AddField("yaoZhi3", (int)values["yaoZhi3"]);

            JSONObject wuDaoData = JSONObject.arr;
            foreach (var wuDao in values["wuDao"])
            {
                wuDaoData.Add((int)wuDao);
            }
            data.AddField("wuDao", wuDaoData);

            jsonData.instance.ItemJsonData.Add((string)values["id"], data);
            
            //ZhuqueDan.Instance.Error("输出追加的物品：");
            //ZhuqueDan.Instance.Error(jsonData.instance.ItemJsonData[(string)values["id"]].ToString());
        }

        private void addSeid(string seidPath, int seidId)
        {
            string jsonString = File.ReadAllText(seidPath);
            JObject seidData = JObject.Parse(jsonString);

            foreach(var idEntry in seidData)
            {
                string itemId = idEntry.Key;
                JObject values = (JObject)idEntry.Value;

                JSONObject data = JSONObject.Create();
                data.AddField("id", (int)values["id"]);
                data.AddField("value1", (int)values["value1"]);

                jsonData.instance.ItemsSeidJsonData[seidId].AddField(itemId, data);
            }

            //ZhuqueDan.Instance.Error("输出追加的效果：");
            //ZhuqueDan.Instance.Error(jsonData.instance.ItemsSeidJsonData[seidId].ToString());
        }
    }
}
