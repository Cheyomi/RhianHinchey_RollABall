using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image creditsImage;
    public Button backButton;

    public Image settingsImage;

    public Button FullscreenToggle;
    public Button FullscreenDisable;
    public Image FullscreenImageCheck;
    public Image FullscreenImageX;
    public Slider slider;

    public void EnableFullscreen()
    {
        Screen.fullScreen = true;
        Debug.Log ("Fullscreen Enabled");
    }

    public void DisableFullscreen()
    {
        Screen.fullScreen = false;
        Debug.Log("Fullscreen Disabled");
    }


    public void HideCredits()
    {
        creditsImage.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        Debug.Log("Back button click registered");
    }

    public void ShowCredits()
    {
            creditsImage.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
    }

    public void HideSettings()
    {
        settingsImage.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        FullscreenImageCheck.gameObject.SetActive(false);
        FullscreenImageX.gameObject.SetActive(false);

        slider.gameObject.SetActive(false);
    }

    public void ShowSettings()
    {
        settingsImage.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        FullscreenToggle.gameObject.SetActive(true);
        FullscreenDisable.gameObject.SetActive(true);
        FullscreenImageCheck.gameObject.SetActive(true);
        FullscreenImageX.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);



        Debug.Log ("Settings Opened");
    }



    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (creditsImage.gameObject.activeSelf)
            {
                HideCredits();
                HideSettings();
            }
            else
            {
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    BackToMenu();
                }
            }

        }
    }
}



