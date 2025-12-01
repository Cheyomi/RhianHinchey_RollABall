using UnityEngine;

public class Critter : MonoBehaviour
{
    public float baseSpeed = 2f;
    public float boostMultiplier = 2f;
    public float boostChance = 0.2f;

    private float currentSpeed;
    private bool finished = false;
    private bool raceStarted = false;  // <-- NEW FLAG

    public Animator animator;

    public void StartRace()
    {
        currentSpeed = baseSpeed;
        finished = false;
        raceStarted = true;   // <-- Race has begun

        if (animator != null)
            animator.SetBool("isRunning", true);
    }

    void Update()
    {
        if (!raceStarted || finished) return;  // <-- Only move if race started

        // Random speed boost
        if (Random.value < boostChance * Time.deltaTime)
        {
            currentSpeed = baseSpeed * boostMultiplier;
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        // Move forward
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    public void FinishRace()
    {
        finished = true;
        raceStarted = false; // <-- Stop race

        if (animator != null)
            animator.SetBool("isRunning", false);
    }
}
