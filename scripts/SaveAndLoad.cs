using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

namespace Save
{ 
    /// <summary>
    /// 存储类
    /// </summary>
    public class SaveAndLoad 
    {
        
        public void SaveData(Dictionary<string, int> dic)
        {
            string json = JsonMapper.ToJson(dic);
            File.WriteAllText("Assets/data.txt", json);
        }

        public Dictionary<string, int> LoadData()
        {
            string json = File.ReadAllText(Application.dataPath+"/data.txt");
            return JsonMapper.ToObject<Dictionary<string,int>>(json);
        }
    }
}