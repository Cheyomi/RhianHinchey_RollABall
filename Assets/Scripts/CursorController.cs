using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        // You can leave this empty or use it later
    }

    void Update()
    {
        if (Player != null)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }
}