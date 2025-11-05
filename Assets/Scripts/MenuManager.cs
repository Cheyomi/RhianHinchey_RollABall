using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image creditsImage;
    public Button backButton;

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

    private void Start()
    {
        creditsImage.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}



