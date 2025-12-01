using UnityEngine;

public class raceTriggerZone : MonoBehaviour
{
    public GameObject eSprite;
    public GameObject BetMenu;

    private bool betMenuOpen = false;
    private bool inTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eSprite.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eSprite.SetActive(false);
            inTrigger = false;
            CloseMenu();
        }
    }

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!betMenuOpen)
            {
                OpenMenu();
                betMenuOpen=true;   
            }
            else
            {
                CloseMenu();
            }
        }
    }

    private void OpenMenu()
    {
        BetMenu.SetActive(true);
        betMenuOpen=true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CloseMenu()
    {
        BetMenu.SetActive(false);
        betMenuOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
