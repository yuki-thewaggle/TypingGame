using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentController : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealthController playerHealthController;      // Reference to the player's health.
    EnemyHealthController enemyHealthController;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealthController = player.GetComponent<PlayerHealthController>();
        enemyHealthController = GetComponent<EnemyHealthController>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        if (playerHealthController.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            //nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}
