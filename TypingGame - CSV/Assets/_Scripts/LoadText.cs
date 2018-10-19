using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEditor;

public class LoadText : MonoBehaviour
{
    public string csvFileName;

    private string[] textMessage;
    private string[,] textWords;
    private int rowLength;
    private int columnLength;

    public string[,] Load()
    {
        TextAsset textAsset = new TextAsset();

        //textasset = Resources.Load(csvFileName) as TextAsset;
        textAsset = AssetDatabase.LoadAssetAtPath("Assets/Resources/"+ csvFileName + ".csv", typeof(TextAsset)) as TextAsset;
        AssetDatabase.Refresh();

        string textLines = textAsset.text;

        textMessage = textLines.Split('\r', '\n');

        textMessage = textMessage.Where(value => value != "").ToArray();
        columnLength = textMessage[0].Split(',').Length;
        rowLength = textMessage.Length;

        textWords = new string[rowLength, columnLength];

        for (var i = 0; i < rowLength; i++)
        {
            string[] tempWords = textMessage[i].Split(',');

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n];
            }
        }

        return textWords;
    }
}
