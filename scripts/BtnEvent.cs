using System.Collections;
using System.Collections.Generic;
using TextRender;
using UnityEngine;
using UnityEngine.UI;
using UGUI.Framework;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

namespace Event.Btn
{ 
    
    public class BtnEvent : MonoBehaviour
    {
        GameController gameController;
        bool isAuto;
        public float autoSpeed = 1.5f;

        public GameObject SALpanel;
        public Button[] buttons;

        private void Start()
        {
            gameController = FindObjectOfType<GameController>();
            buttons = SALpanel.transform.GetChild(0).GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = "";
            }
        }

        public void ReadData()
        {
            gameController.textdes.text = "";
            if (gameController.index >= gameController.datas.Count - 1) {
        // 对话数据已经全部读取完毕，返回场景1
            SceneManager.LoadScene(1);
            return;
            }
            gameController.index++;
            gameController.ChangeDialog(gameController.index);
        }

        private void Update()
        {
            //if this have finish the read event and if it is auto mode
            if (gameController.isComplete == true && isAuto == true)
            {
                gameController.isComplete = false;
                Invoke("ReadData",autoSpeed);
            }
        }

        //next event
        public void NextBtn()
        {
            gameController.StopAllCoroutines();
            ReadData();
        }

        //auto 
        public void AutoBtn()
        {
            if (!isAuto)
            {
                isAuto = true;
            }
            else
            {
                isAuto = false;
            }
        }

        //cancel event when click the load event. it is not a good way to use now.
        public void OnBack()
        {
            SALpanel.SetActive(false);
        }
    }
}
