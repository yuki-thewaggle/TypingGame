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

    private void Start()
    {
        questionSet = GetComponent<QuestionSet>();

        //sampleTextMesh = questionSet.sampleTextMesh;
        inputTextMesh = questionSet.inputTextMesh;

        SetInputText(inputTextMesh.text);
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
                }
                break;
            }

            if (typingSystem.isEnded())
            {
                Destroy(gameObject);
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
