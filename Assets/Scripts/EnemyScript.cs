using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float detectionRange = 10f;  // Distance at which the enemy detects the player
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within the detection range, change the animation to attack
        if (distanceToPlayer < detectionRange)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            // If the player is outside the detection range, go back to idle animation
            animator.SetBool("isAttacking", false);
        }
    }
}
