using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    public Critter[] critters;      // Assign all 4 critters
    public GameObject betMenu;      // UI panel
    public int playerBetIndex;      // Index of critter player bets on
    public int nutsReward = 10;     // Amount player wins
    public int playerNuts = 0;      // Existing player nuts

    private bool raceStarted = false;

    public void PlaceBet(int critterIndex)
    {
        playerBetIndex = critterIndex;
        StartRace();
        betMenu.SetActive(false); // Close bet menu
    }

    void StartRace()
    {
        raceStarted = true;

        // Reset positions if needed
        foreach (Critter c in critters)
        {
            c.StartRace();
        }
    }

    public void CritterFinished(Critter critter)
    {
        if (!raceStarted) return;

        raceStarted = false;

        // Stop all critters
        foreach (Critter c in critters)
        {
            c.FinishRace();
        }

        // Check if player won
        int winnerIndex = System.Array.IndexOf(critters, critter);
        if (winnerIndex == playerBetIndex)
        {
            playerNuts += nutsReward;
            Debug.Log("You won the bet! Nuts: " + playerNuts);
        }
        else
        {
            Debug.Log("You lost the bet!");
        }
    }
}
