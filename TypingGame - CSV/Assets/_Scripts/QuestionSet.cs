using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSet : MonoBehaviour
{
    //public TextMesh sampleTextMesh;
    public TextMesh inputTextMesh;

    public string InputText { get; set; }

    private string sampleText;

    private void Awake()
    {
        int result = Random.Range(0, GameController.QuestionList.Length / 2);

        //sampleTextMesh.text = sampleText = GameController.QuestionList[result, 0];
        inputTextMesh.text = InputText = GameController.QuestionList[result, 1];

    }
}
