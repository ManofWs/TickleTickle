using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool EnemyHit=false;

    public HealthBarUI healthBar; // Reference to the HealthBar script.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision involves a GameObject
        if (collision.gameObject != null)
        {
            // Get the name of the collided GameObject
            string collidedObjectName = collision.gameObject.name;

            // Print the name of the collided GameObject
            Debug.Log("Collided with: " + collidedObjectName);

            EnemyBehaviour _enemyBehaviour = collision.gameObject.GetComponent<EnemyBehaviour>();

            // Check if the enemy's health script is found
            if (_enemyBehaviour != null)
            {
                // Reduce the enemy's health by 1
                _enemyBehaviour.TakeDamage(1);

                healthBar.UpdateHealth(_enemyBehaviour.currentHealth, _enemyBehaviour.maxHealth);
            }
        }
    }
}
