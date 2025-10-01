using UnityEngine;
using TMPro; //Importing TextMeshPro to allow the use of TMP_Text

//Comments are for personal educational use once again

public class XPSystem : MonoBehaviour //These are public variables that will be in the Unity Inspector
{
    public int currentXP = 0; //The amount of XP the player currently has
    public int level = 1; //The player's current level, the number also shows starting level
    public int xpToNextLevel = 10; //Straight forward, this is how much XP the player needs to reach the next level

    public TMP_Text xpText;
    public TMP_Text levelText;

    void Start() //Start is called
    {
        UpdateUI(); //Update the UI (when the game starts for this)
    }

    public void AddXP(int amount) //A method created to add XP to the player
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel) //If the player's XP is greater than or equal to the required amount to level up, level up
        {
            LevelUp(); //Method called to level the player up
        }

        UpdateUI(); //Update the UI to show the new changes
    }

    void LevelUp()
    {
        level++; //Increase the players level by one
        currentXP = 0; //Reset the player's XP to 0 after leveling up
        xpToNextLevel += 5; //Increase the XP required to reach next level, basically this adds 5 to the int xpToNextLevel every time the player levels up.
        //So it gets harder to level up.
    }

    void UpdateUI()
    {
        if (xpText != null) xpText.text = "XP: " + currentXP + " / " + xpToNextLevel;
        if (levelText != null) levelText.text = "Level: " + level;
    }

}
