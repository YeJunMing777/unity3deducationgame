using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject SubMenuPanel;
    public Button MenuButton;
    public Button PauseButton;
    public Button CloseButton;
    public Button RestartButton;
    public Button ResumeButton; // 新增

    private bool isPaused = false;

    void Start()
    {
        SubMenuPanel.SetActive(false);

        MenuButton.onClick.AddListener(ShowSubMenu);
        PauseButton.onClick.AddListener(TogglePause);
        CloseButton.onClick.AddListener(CloseGame);
        RestartButton.onClick.AddListener(RestartGame);
        ResumeButton.onClick.AddListener(HideSubMenu); // 新增
    }

    void ShowSubMenu()
    {
        SubMenuPanel.SetActive(true);
    }

    // 新增
    void HideSubMenu()
    {
        SubMenuPanel.SetActive(false);
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    void CloseGame()
    {
        Application.Quit();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
