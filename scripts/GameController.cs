using System.Collections;
using System.Collections.Generic;
using System.IO;
using TextData;
using UnityEngine;
using UnityEngine.UI;

namespace TextRender
{
    public class GameController : MonoBehaviour
    {
        public List<Data> datas;
        public int id;
        public Text textname;
        public Text textdes;
        public Image BG;
        public AudioClip bgm;
        public AudioClip voice;
        public Sprite[] paint;

        public Image CG;

        public bool isComplete;

        //csv path
        string path = "Assets/text.csv";
        //dialogue index
        public int index = 0;
        private void Start()
        {
            datas = new List<Data>();
            //read csv
            AnalysisText.Instance.TextRead(path,datas);

            textdes.text = "";
            paint = new Sprite[2];
            ChangeDialog(index);
        }

        public void ChangeDialog(int index)
        {
            LoadDialog(index);
            textname.text = datas[index].name;//name
            BG.sprite = Resources.Load<Sprite>(datas[index].BGurl);//background
            StartCoroutine(printtext(datas[index].des));//display text
            AudioManager.Instance.PlaySource(bgm,voice);//display bgm
            VisibleSprite();//display thesprite
        }

        public void LoadDialog(int index)
        {
            bgm = Resources.Load<AudioClip>("Soundtrack/" + datas[index].bgmUrl);//get bgm
            voice = Resources.Load<AudioClip>("voice/" + datas[index].voiceUrl);//get sound track
            if (datas[index].playerPaint == null)
                return;
            else if (!datas[index].playerPaint.Contains("/"))
                paint[0] = Resources.Load<Sprite>("Paint/" + datas[index].playerPaint);//load first cg
            else
            {
                string[] temp = datas[index].playerPaint.Split('/');
                paint[0] = Resources.Load<Sprite>(temp[0]);//load first cg
                paint[1] = Resources.Load<Sprite>(temp[1]);//load second cg
            }
        }

        //display image
        public void VisibleSprite()
        {
            if (paint[0] == null)
                CG.gameObject.SetActive(false);
            else
            {
                if(CG.IsActive() == false)
                    CG.gameObject.SetActive(true);
                CG.sprite = paint[0];
            }
                
        }

       //print text 
        
        IEnumerator printtext(string des)
        {
            int i = 0;
            while (i <= des.Length - 1)
            {
                textdes.text += des[i].ToString();
                i++;
                if (i >= des.Length)
                {
                    i = 0;
                    isComplete = true;
                    StopAllCoroutines();
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}