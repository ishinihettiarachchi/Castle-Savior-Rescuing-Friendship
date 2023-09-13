using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float buoyancyForce = 10f; // Adjust this value as needed.

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player is in contact with the river.
        if (other.CompareTag("River"))
        {
            // Apply an upward force to simulate buoyancy.
            rb.AddForce(Vector2.up * buoyancyForce);
        }
    }
}
