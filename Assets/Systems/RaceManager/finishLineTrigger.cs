using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        Critter critter = other.GetComponent<Critter>();
        if (critter != null)
        {
            raceManager.CritterFinished(critter);
        }
    }
}
