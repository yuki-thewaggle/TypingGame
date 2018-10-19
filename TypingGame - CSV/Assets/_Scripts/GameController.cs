using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

    static public string[,] QuestionList { get; set; }

    private EnemyController enemyController;
    private LoadText loadText;

    void Awake()
    {
        loadText = GetComponent<LoadText>();
        QuestionList = loadText.Load();
        AssetDatabase.Refresh();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        Instantiate(enemy);
        enemyController = GetComponent<EnemyController>();
    }
}
