using System.Collections;
using System.Collections.Generic;
using System.IO;
using TextData;
using UnityEngine;
using UnityEngine.UI;
using Common;

namespace TextRender
{ 
    /// <summary>
    /// 数据解析类
    /// </summary>
    public class AnalysisText : MonoSingleton<AnalysisText>
    {
        public void TextRead(string path,List<Data> datas)
        {
            string[] data = new string[10];
            using (StreamReader m = File.OpenText(path))
            {
                string line;
                while ((line = m.ReadLine()) != null)
                {
                    data = line.Split(',');
                    datas.Add(new Data
                    {
                        id = int.Parse(data[0]),
                        des = data[1],
                        name = data[2],
                        BGurl = data[3],
                        bgmUrl = data[4],
                        voiceUrl = data[5],
                        playerPaint = data[6]
                    });
                }
            }
        }
    }
}