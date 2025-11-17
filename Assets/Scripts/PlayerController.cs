using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private bool isGrounded;

    public float speed = 5f;
    public float jumpForce = 5f;
    public TMP_Text countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateCountText();
    }

    void UpdateCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void Update()
    {
        if (Time.timeScale > 0f &&  Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 camFoward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camFoward.y = 0f;
        camRight.y = 0f;
        camFoward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camFoward * moveZ + camRight * moveX;

        rb.AddForce(moveDirection * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        CheckGrounded();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            UpdateCountText();
        }
    }

}
