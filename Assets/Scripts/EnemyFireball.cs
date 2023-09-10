using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized* force;

        float rot = Mathf.Atan2(-direction.y, -direction.x); 
        transform.rotation = Quaternion.Euler(0,0,rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the fireball enters a trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Player has been hit by the fireball
            // Implement player death logic here
            PlayerLife playerLife = collider.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.Die();
            }

            // Destroy the fireball after hitting the player
            Destroy(gameObject);
        }
    }



}
