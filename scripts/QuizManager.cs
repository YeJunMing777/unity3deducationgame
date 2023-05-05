using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject enemyCube;
    public GameObject enemyCube2;
    public GameObject enemyCube3;
    public GameObject playerCube;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button button11;
    public Button button12;
    public Button button13;
    public int playerHealth = 100;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionText2;
    public TextMeshProUGUI questionText3;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI messagewrong;
    public TextMeshProUGUI gameovermesage;
    public Image keyImage1;
    public Image keyImage2;
    public Image keyImage3;
    private int keysVisible = 0;
    public Slider healthSlider;
    public HealthPackController healthPack;
    public int sceneName;
    //remain enemy
    public int remainingEnemies = 3;
    private void Start()
    {
        messageText.gameObject.SetActive(false);
        messagewrong.gameObject.SetActive(false);
        gameovermesage.gameObject.SetActive(false);
        key1.gameObject.SetActive(false);
        key2.gameObject.SetActive(false);
        key3.gameObject.SetActive(false);
        keyImage1.gameObject.SetActive(false);
        keyImage2.gameObject.SetActive(false);
        keyImage3.gameObject.SetActive(false);
        healthSlider.value = (float)playerHealth / 100;
        button1.onClick.AddListener(() => OnButtonClick(button1));
        button2.onClick.AddListener(() => OnButtonClick(button2));
        button3.onClick.AddListener(() => OnButtonClick(button3));
        button4.onClick.AddListener(() => OnButtonClick(button4));
        button5.onClick.AddListener(() => OnButtonClick(button5));
        button6.onClick.AddListener(() => OnButtonClick(button6));
        button7.onClick.AddListener(() => OnButtonClick(button7));
        button8.onClick.AddListener(() => OnButtonClick(button8));
        button9.onClick.AddListener(() => OnButtonClick(button9));
        button10.onClick.AddListener(() => OnButtonClick(button10));
        button11.onClick.AddListener(() => OnButtonClick(button11));
        button12.onClick.AddListener(() => OnButtonClick(button12));
        
    }
    public  IEnumerator Showkey()
    {
        keysVisible++;
         if (keysVisible==3)
        {
            // 在摧毁 enemy 后减少 remainingEnemies 的值
           // remainingEnemies--;
            //StartCoroutine(Showkey());
            // 检查是否还有剩余的 enemy
         
                // 如果没有剩余的 enemy，则加载新场景
                SceneManager.LoadScene(sceneName);
            
        }
        switch (keysVisible)
        {
            case 1:
                keyImage1.gameObject.SetActive(true);
                
                break;
            case 2:
                keyImage2.gameObject.SetActive(true);
                
                break;
            case 3:
                keyImage3.gameObject.SetActive(true);
                
                break;
        }
        yield return null;
    }
  
    private IEnumerator ShowMessage()
    {
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        messageText.gameObject.SetActive(false);
    }
    //wrong answaer message
     private IEnumerator ShowMessage2()
    {
        messagewrong.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        messagewrong.gameObject.SetActive(false);
    }
    //game over message
     private IEnumerator ShowMessage3()
    {
        gameovermesage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gameovermesage.gameObject.SetActive(false);
    }
   public void HealPlayer(int healAmount)
    {
        playerHealth += healAmount;
        if (playerHealth > 100) // 防止血量超过最大值
        {
            playerHealth = 100;
        }
        healthSlider.value = (float)playerHealth / 100;
    }

    public void OnButtonClick(Button button)
    {
        if (button == button1) // 检查是否点击了正确的按钮
        {
            Destroy(enemyCube);
            questionText.gameObject.SetActive(false);
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            StartCoroutine(ShowMessage());
            key2.gameObject.SetActive(true);
            
        }
        else if (button == button6) // 检查是否点击了正确的按钮
        {
            Destroy(enemyCube2);
            questionText2.gameObject.SetActive(false);
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            button7.gameObject.SetActive(false);
            button8.gameObject.SetActive(false);
            StartCoroutine(ShowMessage());
            key1.gameObject.SetActive(true);
            
        }
        else if (button == button12) // 检查是否点击了正确的按钮
        {
            Destroy(enemyCube3);
            questionText3.gameObject.SetActive(false);
            button9.gameObject.SetActive(false);
            button10.gameObject.SetActive(false);
            button11.gameObject.SetActive(false);
            button12.gameObject.SetActive(false);
            StartCoroutine(ShowMessage());
            key3.gameObject.SetActive(true);
            
        }
      
        else
        {
            if (playerHealth > 10){
            playerHealth -= 10;
            StartCoroutine(ShowMessage2());
            healthSlider.value = (float)playerHealth / 100;
            }
            if (playerHealth <= 10)
            {
                Destroy(playerCube);
                StartCoroutine(ShowMessage3());
                button13.gameObject.SetActive(true);
                healthSlider.value = (float)playerHealth / 100;
            }
        }
        
        
    }

}
