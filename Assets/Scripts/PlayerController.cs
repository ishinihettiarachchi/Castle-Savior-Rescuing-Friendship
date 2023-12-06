using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private List<GameObject> activePowerUps = new List<GameObject>();
    [SerializeField] private AudioSource powerupSoundEffect;
    [SerializeField] AudioSource EnemyAttackSoundEffect;


    private PlayerHealth playerHealth;

    private void Start()
    {
        // Assuming the PlayerHealth script is on the same GameObject as PlayerController
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            powerupSoundEffect.Play();
            MovePowerUpWithPlayer(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            // Handle collision with the key prefab
            HandleKeyCollision(collision.gameObject);
            HandleCageCollision(); // Call HandleCageCollision here
        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check if the player has a power-up
            if (HasPowerUp())
            {
                // Make the enemy vanish when hit by the player with a power-up
                Destroy(collision.gameObject);

                // Destroy the collided power-up
                DestroyActivePowerUp();
            }
            else
            {
                // Handle normal player-enemy collision (e.g., player takes damage)
                EnemyAttackSoundEffect.Play();
                HandlePlayerEnemyCollision();
            }
        }
    }

    private void HandleKeyCollision(GameObject keyPrefab)
    {
        // You can also destroy or deactivate the key prefab if needed
        Destroy(keyPrefab);
    }

    private void HandleCageCollision()
    {
        // Destroy the cage prefab or handle it in a way that suits your game
        // For example:
        GameObject cage = GameObject.FindGameObjectWithTag("Cage");
        if (cage != null)
        {
            Destroy(cage);
        }
    }
    private void MovePowerUpWithPlayer(GameObject powerUp)
    {
        // You can move the power-up by parenting it to the player
        powerUp.transform.parent = transform;

        // Add the power-up to the list of active power-ups
        activePowerUps.Add(powerUp);
    }

 

    private void HandleCageCollision(GameObject cage)
    {
        Destroy(cage);
    }

    private bool HasPowerUp()
    {
        // Check if there is any active power-up
        return activePowerUps.Count > 0;
    }

    private void DestroyActivePowerUp()
    {
        // Destroy the most recently added power-up
        if (activePowerUps.Count > 0)
        {
            GameObject powerUp = activePowerUps[activePowerUps.Count - 1];
            activePowerUps.Remove(powerUp);
            Destroy(powerUp);
        }
    }

    private void HandlePlayerEnemyCollision()
    {
        // Implement logic to handle normal player-enemy collision
        // For example, subtract player health, play a sound, etc.
        playerHealth.TakeDamage(1);
    }
}
