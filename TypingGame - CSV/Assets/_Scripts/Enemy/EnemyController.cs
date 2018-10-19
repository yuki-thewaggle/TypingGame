using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private TypingSystem typingSystem = new TypingSystem();
    private QuestionSet questionSet;
    //private TextMesh sampleTextMesh;
    private TextMesh inputTextMesh;

    private string[] keys =
    {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
            "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
            "u", "v", "w", "x", "y", "z",
            "-",
    };

    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    public AudioClip deathClip;                 // The sound to play when the enemy dies.

    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.

    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    private void Start()
    {
        questionSet = GetComponent<QuestionSet>();

        //sampleTextMesh = questionSet.sampleTextMesh;
        inputTextMesh = questionSet.inputTextMesh;

        SetInputText(inputTextMesh.text);

        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void Update()
    {
        UpdateInput();

        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

    }

    private void SetInputText(string questionText)
    {
        typingSystem.SetInputString(questionText);
    }

    private void UpdateInput()
    {
        foreach (string key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                if (typingSystem.InputKey(key) == 1)
                {
                    UpdateText();
                    TakeDamage();
                }
                break;
            }

            if (typingSystem.isEnded())
            {
                Death();
                break;
            }
        }
    }

    private void UpdateText()
    {
        //sampleTextMesh.text = "<color=red>" + typingSystem.GetInputedString() + "</color>" + typingSystem.GetRestString();
        inputTextMesh.text = "<color=red>" + typingSystem.GetInputedKey() + "</color>" + typingSystem.GetRestKey();
    }

    public void TakeDamage()
    {        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        enemyAudio.Play();

        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = new Vector3 (0, 0, 0);

    }

    void Death()
    {
        //// The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }


    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        ScoreController.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }
}
