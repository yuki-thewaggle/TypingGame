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
    //ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    //bool isDead;                                // Whether the enemy is dead.
    //bool isSinking;                             // Whether the enemy has started sinking through the floor.
    EnemyHealthController enemyHealthController;
    bool isKilled;

    private void Start()
    {
        questionSet = GetComponent<QuestionSet>();

        //sampleTextMesh = questionSet.sampleTextMesh;
        inputTextMesh = questionSet.inputTextMesh;

        SetInputText(inputTextMesh.text);

        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        enemyHealthController = GetComponent<EnemyHealthController>();
    }

    private void Update()
    {
        UpdateInput();
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
                    enemyHealthController.TakeDamage();
                }
                break;
            }

            if (typingSystem.isEnded())
            {
                if (!isKilled)
                {
                    enemyHealthController.Death();
                    enemyHealthController.StartSinking();
                    isKilled = true;
                }
                break;
            }
        }
    }

    private void UpdateText()
    {
        //sampleTextMesh.text = "<color=red>" + typingSystem.GetInputedString() + "</color>" + typingSystem.GetRestString();
        inputTextMesh.text = "<color=red>" + typingSystem.GetInputedKey() + "</color>" + typingSystem.GetRestKey();
    }
}
