using UnityEngine;

public class Ground_Sensor : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
