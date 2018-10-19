using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

    static public string[,] QuestionList { get; set; }

    private EnemyController enemyController;

    void Awake()
    {
        QuestionList = GetComponent<LoadText>().Load();
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
