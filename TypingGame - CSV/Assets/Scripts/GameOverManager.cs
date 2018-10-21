using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    //public PlayerHealth playerHealth;       // Reference to the player's health.
    public PlayerHealthController playerHealthController;       // Reference to the player's health.


    Animator anim;                          // Reference to the animator component.


    void Start()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        playerHealthController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>();
    }


    void Update()
    {
        // If the player has run out of health...
        if (playerHealthController.currentHealth <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
        }
    }
}
