using UnityEngine;
using TMPro;


//Comments are for personal educational purposes, so I can learn and understand the code
public class PlayerController : MonoBehaviour //This is the script that controls player movement
{
    //These are private variables, when it's private that means only this script can access these things
    private Rigidbody rb; //The players Rigidbody component
    private int count; //Keeps track of the count/score. (This is the amount of pickups collected)
    private float movementX; //Stores horizontal movement input
    private float movementY; //Stores vertical movement input
    private bool isGrounded; //Checks if the player is grounded (on/touching the ground)

    //When it's public, these can be accessed by other scripts and seen in the Unity Inspector!
    public float speed = 0; //This is the movement speed of the player
    public float jumpForce = 4f; //This is how high the player can jump
    public TMP_Text countText; //This is the UI text that displays the number of collected items
    public GameObject winTextObject; //This is the UI text that appears when the player wins


    // Reference to the XP system
    public XPSystem xpSystem;

    // Start is called before the first frame update.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; //Initializes the count to 0 

        SetCountText(); //A method that is called to update the count displayed on screen
        winTextObject.SetActive(false); //Hide the win text when it's not needed
    }

    // This function is called when a move input is detected.
    void OnMove(UnityEngine.InputSystem.InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; //Stores horizontal input
        movementY = movementVector.y; //Stores vertical input
    }

    void SetCountText() //This is the method for updating the count text displayed on screen
    {
        countText.text = "Count: " + count.ToString(); //Update the count text on screen with the current count of pickups collected
        if (count >= 12) //If the amount of pickups collected is  12 or more, display the win text on screen, and destroy the enemy.
        {
            winTextObject.SetActive(true); //(setting win text to be visible)
            Destroy(GameObject.FindGameObjectWithTag("Enemy")); //(destroying the enemy)
        }
    }

    //fixed update is called a fixed amount of times
    private void FixedUpdate()
    {
        //move the player based on input
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); //apply force to move the player

        CheckGrounded(); //a method that checks if the player is touching the ground
    }

    private void OnTriggerEnter(Collider other) //When the player collides with another object (tagged as pickup or enemy)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);  //disables the pickup object
            count++;  //adds one to the count/score

            //Add XP to the XP system so long as it exists
            if (xpSystem != null)
            {
                xpSystem.AddXP(10);  //This is the amount of XP rewarded (adjustable)
            }

            SetCountText();
        }

        //Checks if the player touches an enemy (lose condition)
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); //Destroys the player
            winTextObject.SetActive(true); //Set the win text to visible, but
            winTextObject.GetComponent<TMP_Text>().text = "You Lose!"; //changes the text to say "You lose!" instead
        }
    }
    
    private void CheckGrounded() //The method that checks if the player is touching the ground
    {
        RaycastHit hit; //cast a ray downwards to check if the player is on the ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f))
        {
            isGrounded = true; //if the ray hits something, player is grounded
        }
        else
        {
            isGrounded = false; //otherwise the player is in the air
        }

    }

    void OnJump() //this handles jumping when the player presses the jump button
        {
            if (isGrounded) //Only jump if the player is on the ground (Prevents double jumping)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //apply an upward force to jump
            }
        }

    void Update() //Update runs every frame
    {
        if(Input.GetKeyDown(KeyCode.Space)) //If the player presses the spacebar
        {
            OnJump(); //Call the jump function!
        }
    }
}

