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

    public void EnableFullscreen()
    {
        Screen.fullScreen = true;
    }

    public void DisableFullscreen()
    {
        Screen.fullScreen = false;
    }


    public void HideCredits()
    {
        creditsImage.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
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
    }

    public void ShowSettings()
    {
        settingsImage.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
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



