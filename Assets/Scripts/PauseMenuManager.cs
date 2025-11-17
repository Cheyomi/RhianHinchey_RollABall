using UnityEngine;
using UnityEngine.UI;


public class PauseMenuManager : MonoBehaviour
{
    public GameObject Player;
    public Image PauseMenuImage;
    public Button ResumeButton;
    public Button MenuButton;
    public Button SettingsButton;
    public Image settingsImage;
    public Image FullscreenCheck;
    public Image FullscreenX;
    public Slider slider;
    public Button FullscreenEnableButton;
    public Button FullscreenDisableButton;
    public AudioSource musicAudio;  

    private bool cursorCurrentlyVisible = true;
    private bool isPaused = false;

    void Start()
    {
        if (musicAudio != null)
        {
            musicAudio.volume = PlayerPrefs.GetFloat("Volume", 1f);
        }

        if (slider != null)
        {
            slider.value = PlayerPrefs.GetFloat("Volume", 1f);
        }
    }


    void Update()
    {
        bool isPauseMenuActive = PauseMenuImage != null && PauseMenuImage.gameObject.activeSelf;
        bool shouldCursorBeVisible = Player == null || isPauseMenuActive;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsImage != null && settingsImage.gameObject.activeSelf)
            {
                HideSettings();
            }
            else if (PauseMenuImage != null)
            {
                bool newState = !PauseMenuImage.gameObject.activeSelf;
                PauseMenuImage.gameObject.SetActive(newState);
            }
        }

        if (cursorCurrentlyVisible != shouldCursorBeVisible)
        {
            Cursor.visible = shouldCursorBeVisible;
            cursorCurrentlyVisible = shouldCursorBeVisible;
        }

        if (isPauseMenuActive && !isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            isPaused = true;
        }
        else if (!isPauseMenuActive && isPaused)
        {
            Time.timeScale = 1f; // Resume the game
            isPaused = false;
        }



    }

    public void ResumeGame()
    {
        PauseMenuImage.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f; // Ensure time scale is reset
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void HideSettings()
    {
        if (settingsImage != null) settingsImage.gameObject.SetActive(false);
        if (FullscreenCheck != null) FullscreenCheck.gameObject.SetActive(false);
        if (FullscreenX != null) FullscreenX.gameObject.SetActive(false);

        if (slider != null) slider.gameObject.SetActive(false);
        if (FullscreenEnableButton != null) FullscreenEnableButton.gameObject.SetActive(false);
        if (FullscreenDisableButton != null) FullscreenDisableButton.gameObject.SetActive(false);
    }

    public void ShowSettings()
    {
        if (settingsImage != null) settingsImage.gameObject.SetActive(true);
        if (FullscreenCheck != null) FullscreenCheck.gameObject.SetActive(true);
        if (FullscreenX != null) FullscreenX.gameObject.SetActive(true);
        if (slider != null) slider.gameObject.SetActive(true);
        if (FullscreenEnableButton != null) FullscreenEnableButton.gameObject.SetActive(true);
        if (FullscreenDisableButton != null) FullscreenDisableButton.gameObject.SetActive(true);

        Debug.Log("Settings Opened");
    }
}