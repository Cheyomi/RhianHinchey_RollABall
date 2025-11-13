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
    }


    void SetCountText() //This is the method for updating the count text displayed on screen
    {
        countText.text = "Count: " + count.ToString(); //Update the count text on screen with the current count of pickups collected
    }


    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * moveZ + camRight * moveX;

        rb.AddForce(moveDirection * speed);

        CheckGrounded();
    }

    private void OnTriggerEnter(Collider other) //When the player collides with another object (tagged as pickup or enemy)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);  //disables the pickup object
            count++;  //adds one to the count/score
            SetCountText();
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
        if (Input.GetKeyDown(KeyCode.Space)) //If the player presses the spacebar
        {
            OnJump(); //Call the jump function!
        }
    }
}
