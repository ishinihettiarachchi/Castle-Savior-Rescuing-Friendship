using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private List<GameObject> activePowerUps = new List<GameObject>();
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            // Handle power-up collision
            // You can move the power-up here or invoke a method to handle it
            MovePowerUpWithPlayer(collision.gameObject);
        }
        
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Handle enemy collision
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
                HandlePlayerEnemyCollision();
            }
        }
    }

    private void MovePowerUpWithPlayer(GameObject powerUp)
    {
        // You can move the power-up by parenting it to the player
        powerUp.transform.parent = transform;

        // Add the power-up to the list of active power-ups
        activePowerUps.Add(powerUp);
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
    }

    
}
